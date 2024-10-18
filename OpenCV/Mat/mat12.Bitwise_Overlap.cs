using OpenCvSharp;
using System;


namespace ConsoleApp65
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 파일 경로
            string imagePath = @"C:/Temp/opencv/bit_test.jpg";
            string logoPath = @"C:/Temp/opencv/logo.jpg";

            // 이미지 읽기
            Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);
            Mat logo = Cv2.ImRead(logoPath, ImreadModes.Color);

            // 예외 처리
            if (image.Empty() || logo.Empty())
            {
                throw new Exception("이미지를 불러올 수 없습니다.");
            }

            // 결과 행렬 선언
            Mat logoTh = new Mat();
            Mat[] masks;

            // 로고 영상 이진화
            Cv2.Threshold(logo, logoTh, 70, 255, ThresholdTypes.Binary);

            // 로고 영상 채널 분리 (분리된 채널 수 확인)
            masks = Cv2.Split(logoTh); //알파채널이 분리가 안됨

            // 채널 수 확인
            if (masks.Length < 3)
            {
                throw new Exception("로고 이미지는 최소한 3채널이어야 합니다.");
                //확인해 보면 3개만 분리되고 mask[3]이 분리되어 나오지 않음!!!
                //masks.Length를 4로 해보고나 masks.Length == 3으로 해보면 확인할 수 있음
            }

            // 전경 통과 마스크
            Mat mask1 = new Mat();
            Cv2.ImShow("mask0", masks[0]);
            Cv2.ImShow("mask1", masks[1]);
            Cv2.ImShow("mask2", masks[2]);
            //Cv2.ImShow("mask3", masks[3]); //분리되지 않으면 당연히 안나옵니다. 
            
            Cv2.BitwiseOr(masks[0], masks[1], mask1);
            Mat mask3 = new Mat();
            Cv2.BitwiseOr(masks[2], mask1, mask3);
            Cv2.ImShow("3개 mask합성", mask3);

            // 배경 통과 마스크
            Mat notMask = new Mat(mask1.Size(), MatType.CV_8UC1, new Scalar(255));
            Cv2.BitwiseNot(mask3, notMask);
            Cv2.ImShow("원본로고", logo);
            Cv2.ImShow("bitwiseNot", notMask);

            // 영상 중심 좌표 계산
            Point center1 = new Point(image.Width / 2, image.Height / 2);  // 이미지 중심 좌표
            Point center2 = new Point(logo.Width / 2, logo.Height / 2);    // 로고 중심 좌표
            Point start = new Point(center1.X - center2.X, center1.Y - center2.Y); // 시작 좌표

            // 로고가 위치할 관심 영역 설정
            Rect roi = new Rect(start, logo.Size());

            // 비트 곱과 마스킹을 이용한 관심 영역의 복사
            Mat background = new Mat();
            Mat foreground = new Mat();
            Cv2.BitwiseAnd(logo, logo, foreground, mask3);
            Cv2.BitwiseAnd(new Mat(image, roi), new Mat(image, roi), background, notMask);

            // 전경과 배경 합성
            Mat dst = new Mat();
            Cv2.Add(background, foreground, dst);

            // 합성된 이미지를 원본 이미지의 관심영역에 복사
            dst.CopyTo(new Mat(image, roi));

            // 결과 이미지 출력
            Cv2.ImShow("background", background);
            Cv2.ImShow("foreground", foreground);
            Cv2.ImShow("dst", dst);
            Cv2.ImShow("image", image);
            Cv2.WaitKey(0);
        }
    }
}
