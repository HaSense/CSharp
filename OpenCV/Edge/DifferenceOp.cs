using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceOp
{
    //차연산자를 통한 에지 검출


    internal class Program
    {
        //Mask 기반 차분 연산을 통한 에지검출 프로그램
        static void DifferOp(Mat img, Mat dst, int maskSize)
        {
            dst.Create(img.Size(), MatType.CV_8UC1);
            dst.SetTo(0);

            // 마스크의 중심 좌표 계산
            Point maskCenter = new Point(maskSize / 2, maskSize / 2);

            for (int i = maskCenter.Y; i < img.Rows - maskCenter.Y; i++)
            {
                for (int j = maskCenter.X; j < img.Cols - maskCenter.X; j++)
                {
                    List<byte> mask = new List<byte>();

                    for (int u = 0; u < maskSize; u++)
                    {
                        for (int v = 0; v < maskSize; v++)
                        {
                            int y = i + u - maskCenter.Y;
                            int x = j + v - maskCenter.X;

                            byte pixelValue = img.At<byte>(y, x);
                            mask.Add(pixelValue);
                        }
                    }

                    byte maxDifference = 0;
                    for (int k = 0; k < mask.Count / 2; k++)
                    {
                        byte start = mask[k];
                        byte end = mask[mask.Count - k - 1];
                        byte difference = (byte)System.Math.Abs(start - end);

                        if (difference > maxDifference)
                            maxDifference = difference;
                    }

                    dst.Set<byte>(i, j, maxDifference);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("C:\\Temp\\img\\edge_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                System.Console.WriteLine("이미지를 불러오지 못했습니다.");
                return;
            }

            Mat edge = new Mat();
            DifferOp(image, edge, 3);

            Cv2.ImShow("image", image);
            Cv2.ImShow("edge", edge);
            Cv2.WaitKey();
        }
    }
}
