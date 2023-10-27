using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomogenityOp
{
    internal class Program
    {
        /* 픽셀간의 균일도 또는 유사도를 이용하여 경계(에지)를 구하는 프로그램 입니다. */
        
        public static void HomogenOp(Mat img, Mat dst, int maskSize)
        {
            // 마스크의 중심 좌표 계산
            Point maskCenter = new Point(maskSize / 2, maskSize / 2);

            for (int i = maskCenter.Y; i < img.Rows - maskCenter.Y; i++)
            {
                for (int j = maskCenter.X; j < img.Cols - maskCenter.X; j++)
                {
                    byte maxDifference = 0;

                    // 주변 픽셀과의 차이 계산
                    for (int u = 0; u < maskSize; u++)
                    {
                        for (int v = 0; v < maskSize; v++)
                        {
                            int y = i + u - maskCenter.Y;
                            int x = j + v - maskCenter.X;
                            byte difference = (byte)Math.Abs(img.At<byte>(i, j) - img.At<byte>(y, x));
                            if (difference > maxDifference) maxDifference = difference;
                        }
                    }

                    dst.At<byte>(i, j) = maxDifference;
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = new Mat("c:\\Temp\\img\\edge_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("이미지가 출력되지 않았습니다.");
                return;
            }

            Mat edge = new Mat(image.Size(), MatType.CV_8U, new Scalar(0));
            HomogenOp(image, edge, 3);

            Cv2.ImShow("image", image);
            Cv2.ImShow("edge-homogenOp", edge);
            Cv2.WaitKey();
        }
    }
}
