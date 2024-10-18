using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSumAvg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 읽기
            Mat image = Cv2.ImRead(@"c:/Temp/opencv/sum_test.jpg", ImreadModes.Color);
            if (image.Empty())
            {
                throw new Exception("이미지를 읽을 수 없습니다.");
            }

            // 마스크 생성
            Mat mask = new Mat(image.Size(), MatType.CV_8U, Scalar.All(0));
            Cv2.Rectangle(mask, new Rect(20, 40, 70, 70), Scalar.All(255), -1);

            // 전체 이미지의 합계 계산
            Scalar sumValue = Cv2.Sum(image);
            Console.WriteLine($"[sum_value] = {sumValue}");

            // 전체 이미지의 평균 계산
            Scalar meanValue1 = Cv2.Mean(image);
            Console.WriteLine($"[mean_value1] = {meanValue1}");

            // 마스크 영역의 평균 계산
            Scalar meanValue2 = Cv2.Mean(image, mask);
            Console.WriteLine($"[mean_value2] = {meanValue2}\n");

            // 전체 이미지의 평균 및 표준 편차 계산
            Mat mean = new Mat();
            Mat stddev = new Mat();
            Cv2.MeanStdDev(image, mean, stddev);
            Console.WriteLine($"[mean] = {mean.At<double>(0, 0)}");
            Console.WriteLine($"[stddev] = {stddev.At<double>(0, 0)}\n");

            // 마스크 영역의 평균 및 표준 편차 계산
            Cv2.MeanStdDev(image, mean, stddev, mask);
            Console.WriteLine($"[mean (masked)] = {mean.At<double>(0, 0)}");
            Console.WriteLine($"[stddev (masked)] = {stddev.At<double>(0, 0)}");

            // 이미지와 마스크 출력
            Cv2.ImShow("image", image);
            Cv2.ImShow("mask", mask);
            Cv2.WaitKey();
        }
    }
}
