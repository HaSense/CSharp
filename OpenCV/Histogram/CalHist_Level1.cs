using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalHist_Level1
{
    internal class Program
    {
        static void CalcHisto(Mat image, out Mat hist, int bins, int rangeMax = 256)
        {
            hist = new Mat(bins, 1, MatType.CV_32F, new Scalar(0));
            float gap = rangeMax / (float)bins;

            for (int i = 0; i < image.Rows; i++)
            {
                for (int j = 0; j < image.Cols; j++)
                {
                    int idx = (int)(image.At<byte>(i, j) / gap);
                    hist.Set<float>(idx, hist.At<float>(idx) + 1);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("c:\\Temp\\img\\pixel_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 로드할 수 없습니다.");
                return;
            }

            Mat hist;
            CalcHisto(image, out hist, 256);   // 히스토그램 계산

            //Console.Write(hist.Dump());
            for (int i = 0; i < hist.Rows; i++)
            {
                Console.Write(hist.At<float>(i) + ", ");
            }
            Console.WriteLine();

            Cv2.ImShow("image", image);
            Cv2.WaitKey();
        }
    }
}


/*

226, 73, 106, 124, 180, 218, 239, 300, 335, 404, 447, 473, 482, 533, 605, 640, 669, 670, 728, 680, 652, 615, 691, 586, 604, 587, 557, 567, 541, 520, 561, 502, 493, 507, 461, 485, 459, 455, 445, 433, 393, 456, 374, 361, 375, 378, 368, 354, 332, 326, 313, 355, 321, 327, 271, 299, 285, 278, 268, 274, 271, 246, 263, 248, 240, 216, 251, 242, 236, 244, 262, 207, 227, 207, 231, 233, 233, 221, 224, 204, 240, 238, 232, 216, 237, 238, 223, 253, 255, 243, 265, 271, 265, 301, 372, 389, 484, 507, 416, 374, 337, 280, 261, 246, 254, 213, 226, 215, 212, 194, 197, 220, 191, 194, 187, 200, 170, 171, 148, 150, 177, 151, 136, 145, 123, 119, 127, 120, 122, 118, 131, 114, 126, 100, 132, 89, 115, 101, 96, 99, 89, 98, 90, 110, 117, 102, 115, 106, 102, 131, 141, 159, 243, 227, 225, 238, 292, 345, 351, 322, 381, 339, 397, 546, 396, 370, 441, 399, 442, 824, 972, 1234, 1059, 625, 526, 326, 246, 249, 228, 237, 208, 209, 180, 238, 229, 219, 205, 241, 249, 264, 285, 335, 411, 656, 771, 815, 736, 618, 537, 495, 576, 569, 486, 527, 420, 401, 422, 360, 303, 295, 268, 206, 196, 134, 168, 150, 169, 136, 142, 131, 129, 129, 118, 121, 130, 133, 116, 119, 122, 129, 123, 129, 132, 120, 127, 137, 124, 133, 158, 155, 152, 170, 148, 146, 152, 144, 135, 140, 146, 166, 176, 170, 181, 177, 276, 944,

*/
