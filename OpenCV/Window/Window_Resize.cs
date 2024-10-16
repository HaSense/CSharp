using OpenCvSharp;

namespace CV_Window_Resize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat image = new Mat(300, 400, MatType.CV_8UC1, new Scalar(255));
            string title1 = "창 크기변경1 - AUTOSIZE";
            string title2 = "창 크기변경2 - NORMAL";

            Cv2.NamedWindow(title1, WindowFlags.AutoSize);
            Cv2.NamedWindow(title2, WindowFlags.Normal);

            Cv2.ResizeWindow(title1, 500, 200);
            Cv2.ResizeWindow(title2, 500, 200);

            Cv2.ImShow(title1, image);
            Cv2.ImShow(title2, image);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }
    }
}
