using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalHist_Level6_Equlize
{
    internal class Program
    {
        static void CalcHisto(Mat image, out Mat hist, Vec3i bins, Vec3f range)
        {
            int[] histSize = { bins.Item0, bins.Item1, bins.Item2 };
            Rangef[] ranges = {
            new Rangef(0, range.Item0),
            new Rangef(0, range.Item1),
            new Rangef(0, range.Item2)
            };
            int[] channels = { 0, 1, 2 };

            hist = new Mat();
            Cv2.CalcHist(new Mat[] { image }, channels, null, hist, image.Channels(), histSize, ranges);
        }

        static void DrawHisto(Mat hist, out Mat histImg, Size size)
        {
            histImg = new Mat(size, MatType.CV_8UC1, new Scalar(255));
            float bin = (float)histImg.Cols / hist.Rows;
            Cv2.Normalize(hist, hist, 0, size.Height, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                float idx1 = i * bin;
                float idx2 = (i + 1) * bin;
                Point pt1 = new Point(idx1, 0);
                Point pt2 = new Point(idx2, (int)hist.At<float>(i));

                if (pt2.Y > 0)
                    Cv2.Rectangle(histImg, pt1, pt2, Scalar.Black, -1);
            }
            Cv2.Flip(histImg, histImg, FlipMode.X);
        }

        static Mat CreateHist(Mat img, out Mat hist)
        {
            Mat histImg;
            Point3i histSize = new Point3i(256, 0, 0);
            Point3f ranges = new Point3f(256, 0, 0);
            CalcHisto(img, out hist, histSize, ranges);
            DrawHisto(hist, out histImg, new Size(256, 200));

            return histImg;
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("c:\\Temp\\img\\equalize_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 로드하지 못했습니다.");

            Mat hist;
            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            Mat histImg1 = CreateHist(image, out hist);

            //자체 평활화 //////////////////////////////////////////
            Mat accumHist = Mat.Zeros(hist.Size(), hist.Type());

            accumHist.Set<float>(0, hist.At<float>(0));
            for (int i = 1; i < accumHist.Rows; i++)
                accumHist.Set<float>(i, accumHist.At<float>(i - 1) + hist.At<float>(i));

            Cv2.Normalize(accumHist, accumHist, 0, 255, NormTypes.MinMax);
            accumHist.ConvertTo(accumHist, MatType.CV_8U);
            Cv2.LUT(image, accumHist, dst1);
            ///////////////////////////////////////////////////////////
            //OpenCV 메소드이용 평활화
            Cv2.EqualizeHist(image, dst2);

            Mat histImg2 = CreateHist(dst1, out hist);
            Mat histImg3 = CreateHist(dst2, out hist);

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1", dst1);
            Cv2.ImShow("dst2", dst2);
            Cv2.ImShow("histImg1", histImg1);
            //Cv2.ImShow("histImg2", histImg2);
            Cv2.ImShow("histImg3", histImg3);

            Cv2.WaitKey();
        }
    }
}
