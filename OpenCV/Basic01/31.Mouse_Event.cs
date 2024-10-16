using OpenCvSharp;

namespace Event_Mouse
{
    internal class Program
    {
        private static void onMouse(MouseEventTypes @event, int x, int y, MouseEventFlags flags, IntPtr userdata)
        {
            switch (@event)
            {
                case MouseEventTypes.LButtonDown:
                    Console.WriteLine("마우스 왼쪽 버튼이 눌러졌습니다.");
                    break;
                case MouseEventTypes.RButtonDown:
                    Console.WriteLine("마우스 오른쪽 버튼이 눌러졌습니다.");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Mat image = new Mat(200, 300, MatType.CV_8UC3, new Scalar(255, 255, 255));

            Cv2.ImShow("마우스 이벤트1", image);

            Cv2.SetMouseCallback("마우스 이벤트1", onMouse);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
        
    }
}
