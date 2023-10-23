using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluringApp
{
    internal class Program
    {
        static void Filter(Mat img, out Mat dst, Mat mask)
        {
            dst = new Mat(img.Size(), MatType.CV_32F, Scalar.All(0));
            //Point h_m = mask.Size() / 2;
            Point h_m = new Point(mask.Width / 2, mask.Height / 2);

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    float sum = 0;

                    for (int u = 0; u < mask.Rows; u++)
                    {
                        for (int v = 0; v < mask.Cols; v++)
                        {
                            int y = i + u - h_m.Y;
                            int x = j + v - h_m.X;
                            sum += mask.At<float>(u, v) * img.At<byte>(y, x);
                        }
                    }

                    dst.Set<float>(i, j, sum);
                }
            }
        }

        static void Main(string[] args)
        {
            string path = "C:\\Temp\\img\\newjeans.png";
            Mat src = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (src.Empty())
                throw new Exception("Failed to load image");

            float[] data1 =
            {
                1/9f, 1/9f, 1/9f,
                1/9f, 1/9f, 1/9f,
                1/9f, 1/9f, 1/9f
            };
            float[] data2 =
            {
                1/25f, 1/25f, 1/25f, 1/25f, 1/25f,
                1/25f, 1/25f, 1/25f, 1/25f, 1/25f,
                1/25f, 1/25f, 1/25f, 1/25f, 1/25f,
                1/25f, 1/25f, 1/25f, 1/25f, 1/25f,
                1/25f, 1/25f, 1/25f, 1/25f, 1/25f
            };

            //Mat mask = new Mat(3, 3, MatType.CV_32F, data1);
            Mat mask = new Mat(5, 5, MatType.CV_32F, data2);

            Filter(src, out Mat blur, mask);

            blur.ConvertTo(blur, MatType.CV_8U);

            Cv2.ImShow("src", src);
            Cv2.ImShow("blur", blur);

            Cv2.WaitKey();
        }
    }
}
