using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphologyErosion
{
    internal class Program
    {
        // 마스크 원소와 마스크 범위 입력화소 간의 일치 여부 체크
        static bool CheckMatch(Mat img, Point start, Mat mask, bool mode = false)
        {
            for (int u = 0; u < mask.Rows; u++)
            {
                for (int v = 0; v < mask.Cols; v++)
                {
                    Point pt = new Point(v, u);
                    int m = mask.At<byte>(pt.Y, pt.X);  // 마스크 계수
                    int p = img.At<byte>(start.Y + pt.Y, start.X + pt.X);  // 해당 위치 입력화소

                    bool ch = (p == 255);  // 일치 여부 비교
                    if (m == 1 && ch == mode) return false;
                }
            }
            return true;
        }

        static void Erosion(Mat img, Mat dst, Mat mask)
        {
            dst.SetTo(0);   //좌표의 모든 값을 0으로 채움
            
            if (mask.Empty())
                mask = Mat.Ones(3, 3, MatType.CV_8UC1);

            Point maskCenterCoord = new Point(mask.Cols / 2, mask.Rows / 2);

            // mask의 중심 좌표를 기준으로 이미지를 순회
            // (이미지의 가장자리는 mask가 벗어나지 않도록 하기 위해 mask의 중심을 기준으로 순회 시작 및 종료)
            for (int i = maskCenterCoord.Y; i < img.Rows - maskCenterCoord.Y; i++)
            {
                for (int j = maskCenterCoord.X; j < img.Cols - maskCenterCoord.X; j++)
                {
                    // 현재 픽셀을 중심으로 마스크를 적용할 시작 좌표 계산
                    Point start = new Point(j, i) - maskCenterCoord;
                    // 이미지의 해당 부분과 마스크가 일치하는지 확인
                    bool check = CheckMatch(img, start, mask, false);
                    // 일치하면 결과 이미지의 해당 픽셀을 255로 설정, 그렇지 않으면 0으로 설정
                    dst.Set<byte>(i, j, check ? (byte)255 : (byte)0);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("C:\\Temp\\img\\morph_test1.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat thImg = new Mat();
            //128이상의 픽셀값이면 모두 255로 변환하라!! 128보다 작으면? 모두 0으로 변환 즉, 0과 255로 이진화하라.
            Cv2.Threshold(image, thImg, 128, 255, ThresholdTypes.Binary);

            var mask = new Mat(3, 3, MatType.CV_8UC1, new byte[] { 0, 1, 0, 1, 1, 1, 0, 1, 0 });

            Mat dst1 = image.Clone(); //전달할 때 크기를 설정 후 전달.
            Mat dst2 = new Mat();
            Erosion(thImg, dst1, mask); //침식연산 - 우리가 만든 함수
            Cv2.MorphologyEx(thImg, dst2, MorphTypes.Erode, mask); //OpenCV에 있는 침식연산 앞으로 이 함수를 사용하세요.

            Cv2.ImShow("image", image);
            Cv2.ImShow("이진 영상", thImg);
            Cv2.ImShow("User_erosion", dst1);
            Cv2.ImShow("OpenCV_erosion", dst2);

            Cv2.WaitKey();
        }
    }
}
