using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalHist_Level2
{
    internal class Program
    {
        // 직접 히스토그램을 계산하는 함수
        static void CalcHisto(Mat image, out Mat hist, int bins, int rangeMax = 256)
        {
            hist = new Mat(bins, 1, MatType.CV_32F, new Scalar(0));
            float gap = rangeMax / (float)bins;

            for (int i = 0; i < image.Rows; i++)
            {
                for (int j = 0; j < image.Cols; j++)
                {
                    int idx = (int)(image.At<byte>(i, j) / gap);
                    hist.Set<float>(idx, hist.At<float>(idx) + 1);
                }
            }
        }

        // OpenCV의 calcHist 함수를 이용해 히스토그램을 계산하는 함수
        static void CalcHistoUsingOpenCV(Mat image, out Mat hist, int bins, int rangeMax = 256)
        {
            int[] histSize = { bins };            // 히스토그램 계급 개수
            Rangef[] ranges = { new Rangef(0, rangeMax) };  // 채널 화소값 범위
            int[] channels = { 0 };                // 채널 목록

            hist = new Mat();
            Cv2.CalcHist(new[] { image }, channels, null, hist, 1, histSize, ranges);
        }

        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("c:\\Temp\\img\\pixel_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 로드할 수 없습니다.");
                return;
            }

            Mat hist;
            CalcHistoUsingOpenCV(image, out hist, 256);

            // 히스토그램 화소값 출력
            for (int i = 0; i < hist.Rows; i++)
            {
                Console.Write(hist.At<float>(i) + ", ");
            }
            Console.WriteLine();

            Cv2.ImShow("image", image);
            Cv2.WaitKey();
        }
    }
}
