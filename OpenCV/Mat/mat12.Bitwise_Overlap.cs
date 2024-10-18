using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            masks = Cv2.Split(logoTh);

            // 채널 수 확인
            if (masks.Length < 3)
            {
                throw new Exception("로고 이미지는 최소한 3채널이어야 합니다.");
            }

            // 전경 통과 마스크
            Mat mask1 = new Mat();
            Cv2.BitwiseOr(masks[0], masks[1], mask1);
            Mat mask3 = new Mat();
            Cv2.BitwiseOr(masks[2], mask1, mask3);

            // 배경 통과 마스크
            Mat maskBackground = new Mat();
            Cv2.BitwiseNot(mask3, maskBackground);

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
            Cv2.BitwiseAnd(new Mat(image, roi), new Mat(image, roi), background, maskBackground);

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
