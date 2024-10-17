using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixChannel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 채널 0, 1, 2 생성 (각각의 값: 10, 20, 30)
            Mat ch0 = new Mat(new Size(4, 3), MatType.CV_8UC1, new Scalar(10));
            Mat ch1 = new Mat(new Size(4, 3), MatType.CV_8UC1, new Scalar(20));
            Mat ch2 = new Mat(new Size(4, 3), MatType.CV_8UC1, new Scalar(30));
            Mat ch_012 = new Mat();

            // 벡터로 병합
            List<Mat> vec_012 = new List<Mat> { ch0, ch1, ch2 };
            Cv2.Merge(vec_012.ToArray(), ch_012);

            // ch_13: 2채널, ch_2: 1채널
            Mat ch_13 = new Mat(ch_012.Size(), MatType.CV_8UC2);
            Mat ch_2 = new Mat(ch_012.Size(), MatType.CV_8UC1);

            Mat[] outMats = { ch_13, ch_2 };
            int[] from_to = { 0, 0, 2, 1, 1, 2 };

            // mixChannels 함수 사용
            Cv2.MixChannels(new Mat[] { ch_012 }, outMats, from_to);

            // 결과 출력
            Console.WriteLine("[ch_123] = ");
            Console.WriteLine(ch_012.Dump());
            Console.WriteLine();

            Console.WriteLine("[ch_13] = ");
            Console.WriteLine(ch_13.Dump());
            Console.WriteLine();

            Console.WriteLine("[ch_2] = ");
            Console.WriteLine(ch_2.Dump());
        }
    }
}
