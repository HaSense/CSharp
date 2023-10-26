using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histrogram_Streching
{
    internal class Program
    {
        static void CalcHisto(Mat image, out Mat hist, int bins, int rangeMax = 256)
        {
            int[] histSize = { bins };
            Rangef[] ranges = { new Rangef(0, rangeMax) };
            int[] channels = { 0 };

            hist = new Mat();
            Cv2.CalcHist(new Mat[] { image }, channels, null, hist, 1, histSize, ranges);
        }

        static void DrawHisto(Mat hist, out Mat histImg, Size size )
        {
            histImg = new Mat(size, MatType.CV_8U, new Scalar(255));
            float bin = (float)histImg.Cols / hist.Rows;
            Cv2.Normalize(hist, hist, 0, size.Height, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                float idx1 = i * bin;
                float idx2 = (i + 1) * bin;
                Point pt1 = new Point((int)idx1, 0);
                Point pt2 = new Point((int)idx2, (int)hist.At<float>(i));

                if (pt2.Y > 0)
                    Cv2.Rectangle(histImg, pt1, pt2, Scalar.Black, -1);
            }
            Cv2.Flip(histImg, histImg, FlipMode.X);
        }

        static int SearchValueIdx(Mat hist, int bias = 0)
        {
            for (int i = 0; i < hist.Rows; i++)
            {
                int idx = Math.Abs(bias - i);
                if (hist.At<float>(idx) > 0) return idx;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("c:\\Temp\\img\\histo_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 로드할 수 없습니다.");
                return;
            }

            Mat hist, histDst, histImg, histDstImg;
            int histSize = 64, ranges = 256;
            CalcHisto(image, out hist, histSize, ranges);

            float binWidth = (float)ranges / histSize;
            int lowValue = (int)(SearchValueIdx(hist, 0) * binWidth);
            int highValue = (int)(SearchValueIdx(hist, hist.Rows - 1) * binWidth);
            Console.WriteLine($"high_value = {highValue}");
            Console.WriteLine($"low_value = {lowValue}");

            int dValue = highValue - lowValue;
           // Mat dst = new Mat();
           // Cv2.Multiply((image - lowValue), new Mat(image.Size(), MatType.CV_8U, new Scalar(255.0 / dValue)), dst);

            Mat dst = new Mat();
            // 이미지의 각 픽셀 값에서 최소값(lowValue)을 빼는 연산
            // 이는 이미지의 화소 값을 "lowValue"만큼 하향 시키는 것과 동일
            // 예를 들면, 최소 밝기 값을 0으로 만들기 위해 전체 이미지를 어둡게 만드는 효과를 가진다.
            Cv2.Subtract(image, new Scalar(lowValue), dst);
            // 빼기 연산 후, 결과 이미지의 화소 값을 스트레칭(stretching)한다.
            // 여기서 스트레칭이란, 이미지의 화소 값 범위를 조절하는 것을 의미한다.
            // (255.0 / dValue)는 스트레칭 비율을 의미하며, 이미지의 화소 값 범위를 [lowValue, highValue]에서 [0, 255]로 맞추기 위한 값이다.
            Cv2.Multiply(dst, new Scalar(255.0 / dValue), dst);
            // 255보다 큰 화소 값들을 255로 제한(클리핑)한다. 
            // 이렇게 함으로써, 이미지의 화소 값이 255를 초과하는 경우를 방지한다.
            Cv2.Threshold(dst, dst, 255, 255, ThresholdTypes.Trunc);
            // 0보다 작은 화소 값들을 0으로 제한(클리핑)한다.
            // 이렇게 함으로써, 이미지의 화소 값이 0 미만인 경우를 방지한다.
            Cv2.Threshold(dst, dst, 0, 0, ThresholdTypes.Tozero);

            CalcHisto(dst, out histDst, histSize, ranges);
            DrawHisto(hist, out histImg, new Size(256, 200));
            DrawHisto(histDst, out histDstImg, new Size(256, 200));

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst-stretching", dst);
            Cv2.ImShow("img_hist", histImg);
            Cv2.ImShow("dst_hist", histDstImg);
            Cv2.WaitKey();
        }
    }
}
