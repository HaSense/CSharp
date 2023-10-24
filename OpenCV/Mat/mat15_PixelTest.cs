using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatAt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat image = new Mat("c:\\Temp\\img\\pixel_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("영상을 읽지 못 했습니다.");
                Environment.Exit(1);
            }

            Rect roi = new Rect(135, 95, 20, 15);
            Mat roi_img = image.SubMat(roi);
            Console.WriteLine("[roi_img] =");

            for (int i = 0; i < roi_img.Rows; i++)
            {
                for (int j = 0; j < roi_img.Cols; j++)
                {
                    Console.Write($"{roi_img.At<byte>(i, j),5}");
                }
                Console.WriteLine();
            }

            image.Rectangle(roi, Scalar.White, 1);
            Cv2.ImShow("image", image);
            Cv2.WaitKey();
        }
    }
    
}
