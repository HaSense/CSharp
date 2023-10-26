using OpenCvSharp;
using System;

namespace CalHist_Level6_Equlize
{
    internal class Program
    {
        // 이미지의 히스토그램을 계산하는 함수
        static void CalcHisto(Mat image, out Mat hist, Vec3i bins, Vec3f range)
        {
            // 각 채널 별 계급 개수 설정
            int[] histSize = { bins.Item0, bins.Item1, bins.Item2 };

            // 각 채널의 화소 범위 설정
            Rangef[] ranges = {
                new Rangef(0, range.Item0),
                new Rangef(0, range.Item1),
                new Rangef(0, range.Item2)
            };

            // 사용할 채널 목록 (0, 1, 2 채널)
            int[] channels = { 0, 1, 2 };

            hist = new Mat();

            // 히스토그램 계산
            Cv2.CalcHist(new Mat[] { image }, channels, null, hist, image.Channels(), histSize, ranges);
        }

        // 히스토그램을 그리는 함수
        static void DrawHisto(Mat hist, out Mat histImg, Size size)
        {
            // 히스토그램 이미지 초기화 (흰색 배경)
            histImg = new Mat(size, MatType.CV_8UC1, new Scalar(255));

            // 바(bar)의 폭 계산
            float bin = (float)histImg.Cols / hist.Rows;

            // 히스토그램 정규화 (0 ~ size.Height 사이의 값으로)
            Cv2.Normalize(hist, hist, 0, size.Height, NormTypes.MinMax);

            // 히스토그램 그리기
            for (int i = 0; i < hist.Rows; i++)
            {
                float idx1 = i * bin;
                float idx2 = (i + 1) * bin;
                Point pt1 = new Point(idx1, 0);
                Point pt2 = new Point(idx2, (int)hist.At<float>(i));

                if (pt2.Y > 0)
                    Cv2.Rectangle(histImg, pt1, pt2, Scalar.Black, -1); // 검은색 바 그리기
            }

            // 이미지 상하 반전 (y축을 기준으로)
            Cv2.Flip(histImg, histImg, FlipMode.X);
        }

        // 히스토그램 계산과 그리기를 한 번에 수행하는 함수
        static Mat CreateHist(Mat img, out Mat hist)
        {
            Mat histImg;
            Point3i histSize = new Point3i(256, 0, 0); // 히스토그램 크기 설정
            Point3f ranges = new Point3f(256, 0, 0);   // 히스토그램 범위 설정
            CalcHisto(img, out hist, histSize, ranges); // 히스토그램 계산
            DrawHisto(hist, out histImg, new Size(256, 200)); // 히스토그램 그리기

            return histImg;
        }

        static void Main(string[] args)
        {
            // 이미지 로드 (흑백 이미지로)
            Mat image = Cv2.ImRead("c:\\Temp\\img\\equalize_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 로드하지 못했습니다.");

            Mat hist;
            Mat dst1 = new Mat();
            Mat dst2 = new Mat();

            // 원본 이미지의 히스토그램 생성
            Mat histImg1 = CreateHist(image, out hist);

            // 누적 히스토그램 초기화
            Mat accumHist = Mat.Zeros(hist.Size(), hist.Type());

            // 누적 히스토그램 계산
            accumHist.Set<float>(0, hist.At<float>(0));
            for (int i = 1; i < accumHist.Rows; i++)
                accumHist.Set<float>(i, accumHist.At<float>(i - 1) + hist.At<float>(i));

            // 누적 히스토그램 정규화
            Cv2.Normalize(accumHist, accumHist, 0, 255, NormTypes.MinMax);
            accumHist.ConvertTo(accumHist, MatType.CV_8U);

            // Look-Up Table을 이용한 히스토그램 평활화
            Cv2.LUT(image, accumHist, dst1);

            // OpenCV의 EqualizeHist 메소드를 사용한 히스토그램 평활화
            Cv2.EqualizeHist(image, dst2);

            // 평활화된 결과의 히스토그램 생성
            Mat histImg2 = CreateHist(dst1, out hist);
            Mat histImg3 = CreateHist(dst2, out hist);

            // 이미지와 히스토그램 표시
            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1", dst1);
            Cv2.ImShow("dst2", dst2);
            Cv2.ImShow("histImg1", histImg1);
            Cv2.ImShow("histImg2", histImg2);
            Cv2.ImShow("histImg3", histImg3);

            Cv2.WaitKey(); 
        }
    }
}
