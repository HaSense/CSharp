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
        public static void HomogenOp(Mat img, Mat dst, int maskSize)
        {
            Point h_m = new Point(maskSize / 2, maskSize / 2);

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    byte max = 0;

                    for (int u = 0; u < maskSize; u++)
                    {
                        for (int v = 0; v < maskSize; v++)
                        {
                            int y = i + u - h_m.Y;
                            int x = j + v - h_m.X;
                            byte difference = (byte)Math.Abs(img.At<byte>(i, j) - img.At<byte>(y, x));
                            if (difference > max) max = difference;
                        }
                    }

                    dst.At<byte>(i, j) = max;
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
