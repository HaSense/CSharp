using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcHist_Color
{
    internal class Program
    {
        // Hue 채널에 대한 히스토그램을 계산하는 함수
        static void CalcHisto(Mat image, out Mat hist, int bins, int rangeMax = 256)
        {
            int[] histSize = { bins };            // 히스토그램 계급 개수
            Rangef[] ranges = { new Rangef(0, rangeMax) };  // 히스토그램 범위
            int[] channels = { 0 };                // 채널 목록

            hist = new Mat();
            Cv2.CalcHist(new[] { image }, channels, null, hist, 1, histSize, ranges);
        }

        // hue 채널에 대한 색상 팔레트 행렬 생성
        static Mat MakePalette(int rows)
        {
            Mat hsv = new Mat(rows, 1, MatType.CV_8UC3);
            for (int i = 0; i < rows; i++)
            {
                byte hue = (byte)((float)i / rows * 180);
                hsv.At<Vec3b>(i, 0) = new Vec3b(hue, 255, 255);
            }

            //hsv.CvtColor(ColorConversionCodes.HSV2BGR); // C++처럼만 하면 변환이 안됨!!!
            //return hsv;                               //복사본을 만들어 출력
            Mat bgrPalette = new Mat();
            Cv2.CvtColor(hsv, bgrPalette, ColorConversionCodes.HSV2BGR);
            return bgrPalette;
        }

        // Hue 히스토그램을 그려주는 함수
        static void DrawHistHue(Mat hist, out Mat histImg, Size size)
        {
            Mat hsvPalette = MakePalette(hist.Rows);
            histImg = new Mat(size, MatType.CV_8UC3, new Scalar(255, 255, 255));
            float bin = (float)histImg.Cols / hist.Rows;
            Cv2.Normalize(hist, hist, 0, histImg.Rows, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                float start_x = i * bin;
                float end_x = (i + 1) * bin;
                Point pt1 = new Point((int)start_x, 0);
                Point pt2 = new Point((int)end_x, (int)hist.At<float>(i));

                //Scalar color = hsvPalette.At<Vec3b>(i, 0);
                Vec3b colorVec = hsvPalette.At<Vec3b>(i, 0);
                Scalar color = new Scalar(colorVec.Item2, colorVec.Item1, colorVec.Item0);

                Cv2.Rectangle(histImg, pt1, pt2, color, -1);
            }
            Cv2.Flip(histImg, histImg, FlipMode.X);
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("C:\\Temp\\img\\pixel_test.jpg", ImreadModes.Color);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 로드할 수 없습니다.");
                return;
            }

            Mat hsvImg = new Mat();
            Cv2.CvtColor(image, hsvImg, ColorConversionCodes.BGR2HSV);
            Mat[] hsvChannels = Cv2.Split(hsvImg);

            Mat histHue, histHueImg;
            CalcHisto(hsvChannels[0], out histHue, 18, 180);
            Size size = new Size(256, 200);
            DrawHistHue(histHue, out histHueImg, size);

            Cv2.ImShow("hist_hue_img", histHueImg);
            Cv2.ImShow("image", image);
            Cv2.WaitKey();
        }
    }
}
