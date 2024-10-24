using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeningDirect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/filter_sharpen.jpg";
            Mat src = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (src.Empty())
                throw new Exception("Failed to load image");

            float[] data1 =
            {
                0, -1, 0,
                -1, 5, -1,
                0, -1, 0
            };

            float[] data2 =
            {
                -1, -1, -1,
                -1, 9, -1,
                -1, -1, -1
            };

            Mat mask1 = new Mat(3, 3, MatType.CV_32F);
            Mat mask2 = new Mat(3, 3, MatType.CV_32F);

            // data1 값을 mask1에 설정
            for (int i = 0; i < mask1.Rows; i++)
            {
                for (int j = 0; j < mask1.Cols; j++)
                {
                    mask1.Set<float>(i, j, data1[i * mask1.Cols + j]);
                }
            }

            // data2 값을 mask2에 설정
            for (int i = 0; i < mask2.Rows; i++)
            {
                for (int j = 0; j < mask2.Cols; j++)
                {
                    mask2.Set<float>(i, j, data2[i * mask2.Cols + j]);
                }
            }

            Mat sharpen1 = new Mat();
            Mat sharpen2 = new Mat();

            Cv2.Filter2D(src, sharpen1, MatType.CV_32F, mask1);
            Cv2.Filter2D(src, sharpen2, MatType.CV_32F, mask2);

            // 결과를 CV_8U로 변환
            sharpen1.ConvertTo(sharpen1, MatType.CV_8U);
            sharpen2.ConvertTo(sharpen2, MatType.CV_8U);

            Cv2.ImShow("sharpen1", sharpen1);
            Cv2.ImShow("sharpen2", sharpen2);
            Cv2.ImShow("src", src);

            Cv2.WaitKey();
        }
    }
}
