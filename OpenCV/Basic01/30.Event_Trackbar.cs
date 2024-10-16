using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackBarApp
{
    internal class Program
    {
        private static string title = "트랙바 이벤트";
        private static Mat image;
        static void Main(string[] args)
        {
            int value = 130;
            image = new Mat(300, 400, MatType.CV_8UC1, new Scalar(120));

            Cv2.NamedWindow(title, WindowFlags.AutoSize);
            Cv2.CreateTrackbar("밝기값", title, ref value, 255, OnChange);

            Cv2.ImShow(title, image);
            Cv2.WaitKey(0);
        }
        private static void OnChange(int value, IntPtr userdata)
        {
            int add_value = value - 130;
            Console.WriteLine($"추가 화소값 {add_value}");

            //Mat tmp = image + add_value;
            Mat tmp = new Mat();
            Cv2.Add(image, new Scalar(add_value), tmp); // Mat에 스칼라 값 더하기
            Cv2.ImShow(title, tmp);
        }
    }
}
