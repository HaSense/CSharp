using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceOperationEdge
{
    internal class Program
    {
        static void DifferOp(Mat img, out Mat dst, int maskSize)
        {
            dst = new Mat(img.Size(), MatType.CV_8U, Scalar.All(0));
            Point h_m = new Point(maskSize / 2, maskSize / 2);

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    List<byte> mask = new List<byte>();

                    for (int u = 0; u < maskSize; u++)
                    {
                        for (int v = 0; v < maskSize; v++)
                        {
                            int y = i + u - h_m.Y;
                            int x = j + v - h_m.X;
                            mask.Add(img.At<byte>(y, x));
                        }
                    }

                    byte max = 0;
                    for (int k = 0; k < mask.Count / 2; k++)
                    {
                        int start = mask[k];
                        int end = mask[mask.Count - k - 1];

                        byte difference = (byte)Math.Abs(start - end);
                        if (difference > max) max = difference;
                    }

                    dst.Set<byte>(i, j, max);
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/edge_test.jpg";
            Mat src = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (src.Empty())
                throw new Exception("Failed to load image");

            Mat edge;
            DifferOp(src, out edge, 3);

            // 결과 출력
            Cv2.ImShow("src", src);
            Cv2.ImShow("edge", edge);

            Cv2.WaitKey();
        }
    }
}
