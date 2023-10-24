using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mat_BrightDark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat image = new Mat("c:\\Temp\\img\\bright.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("영상을 읽지 못 했습니다.");
                Environment.Exit(1);
            }

            Mat dst1 = image + 100;
            Mat dst2 = image - 100;
            Mat dst3 = new Mat(image.Size(), image.Type(), Scalar.All(255)) - image;

            Mat dst4 = new Mat(image.Size(), image.Type());
            Mat dst5 = new Mat(image.Size(), image.Type());

            for (int i = 0; i < image.Rows; i++)
            {
                for (int j = 0; j < image.Cols; j++)
                {
                    dst4.At<byte>(i, j) = (byte)(Math.Min(image.At<byte>(i, j) + 100, 255));
                    dst5.At<byte>(i, j) = (byte)(255 - image.At<byte>(i, j));
                }
            }

            Cv2.ImShow("원 영상", image);
            Cv2.ImShow("dst1 - 밝게", dst1);
            Cv2.ImShow("dst2 - 어둡게", dst2);
            Cv2.ImShow("dst3 - 반전", dst3);
            Cv2.ImShow("dst4 - 밝게", dst4);
            Cv2.ImShow("dst5 - 반전", dst5);
            Cv2.WaitKey();
        }
    }
}
