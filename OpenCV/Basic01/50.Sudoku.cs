using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 파일 경로
            string imagePath = @"c:/temp/opencv/sudoku.png";

            // 이미지를 그레이스케일로 읽기
            Mat src = Cv2.ImRead(imagePath, ImreadModes.Grayscale);
            Cv2.ImShow("src", src);

            // Otsu의 이진화 적용
            Mat dst = new Mat();
            Cv2.Threshold(src, dst, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
            Cv2.ImShow("dst", dst);

            // 적응형 이진화 (Mean C)
            Mat dst2 = new Mat();
            Cv2.AdaptiveThreshold(src, dst2, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 51, 7);
            Cv2.ImShow("dst2", dst2);

            // 적응형 이진화 (Gaussian C)
            Mat dst3 = new Mat();
            Cv2.AdaptiveThreshold(src, dst3, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 51, 7);
            Cv2.ImShow("dst3", dst3);

            // 대기 및 창 닫기
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
