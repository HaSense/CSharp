using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVSharpMouseQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = new Mat(new Size(500, 300), MatType.CV_8UC3, new Scalar(255, 255, 255));

            Cv2.ImShow("마우스 이벤트 퀴즈", src);
            Cv2.SetMouseCallback("마우스 이벤트 퀴즈", OnMouse);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
        private static void OnMouse(MouseEventTypes @event, int x, int y, MouseEventFlags flags, IntPtr userdata)
        {
            switch (@event)
            {
                case MouseEventTypes.LButtonDown:
                    Console.WriteLine("마우스 왼쪽버튼 누르기");
                    break;
                case MouseEventTypes.RButtonDown:
                    Console.WriteLine("마우스 오른쪽버튼 누르기");
                    break;
                case MouseEventTypes.RButtonUp:
                    Console.WriteLine("마우스 오른쪽버튼 떼기");
                    break;
                case MouseEventTypes.LButtonDoubleClick:
                    Console.WriteLine("마우스 왼쪽버튼 더블클릭");
                    break;
            }
        }
    }
}
