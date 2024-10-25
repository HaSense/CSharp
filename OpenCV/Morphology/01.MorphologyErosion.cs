using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MopologyErosion
{
    class CVUtils
    {
        public bool CheckMatch(Mat img, Point start, Mat mask, int mode = 0)
        {
            for (int u = 0; u < mask.Rows; u++)
            {
                for (int v = 0; v < mask.Cols; v++)
                {
                    Point pt = new Point(v, u);
                    byte m = mask.Get<byte>(u, v); // 마스크 계수
                    byte p = img.Get<byte>(start.Y + u, start.X + v); // 해당 위치 입력화소

                    bool ch = (p == 0); // 일치 여부 비교 (검은 바탕에 하얀 글씨)
                    if (m == 1 && ch == (mode == 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Erosion(Mat img, Mat dst, Mat mask)
        {
            dst.Create(img.Size(), MatType.CV_8UC1);
            dst.SetTo(new Scalar(0));
            if (mask.Empty())
            {
                mask = Mat.Ones(3, 3, MatType.CV_8UC1);
            }

            Point h_m = new Point(mask.Cols / 2, mask.Rows / 2);

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    Point start = new Point(j, i) - h_m;
                    bool check = CheckMatch(img, start, mask, 0);
                    dst.Set<byte>(i, j, (byte)(check ? 255 : 0));
                }
            }
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"C:/Temp/opencv/morph_test1.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                throw new System.Exception("이미지를 로드할 수 없습니다.");
            }

            Mat thImg = new Mat();
            Mat dst1 = new Mat();
            Mat dst2 = new Mat();

            Cv2.Threshold(image, thImg, 128, 255, ThresholdTypes.Binary);

            Mat mask = new Mat(3, 3, MatType.CV_8UC1);
            byte[,] values = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };
            for (int i = 0; i < mask.Rows; i++)
            {
                for (int j = 0; j < mask.Cols; j++)
                {
                    mask.Set(i, j, values[i, j]);
                }
            }

            CVUtils cvUtils = new CVUtils();
            cvUtils.Erosion(thImg, dst1, mask);
            Cv2.MorphologyEx(thImg, dst2, MorphTypes.Erode, mask);

            Cv2.ImShow("image", image);
            Cv2.ImShow("이진 영상", thImg);
            Cv2.ImShow("User_erosion", dst1);
            Cv2.ImShow("OpenCV_erosion", dst2);

            Cv2.WaitKey();
        }
    }
}
