using OpenCvSharp;

namespace Draw_Ellipse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scalar orange = new Scalar(0, 165, 255);
            Scalar blue = new Scalar(255, 0, 0);
            Scalar magenta = new Scalar(255,0,255);

            Mat image = new Mat(300, 700, MatType.CV_8UC3, new Scalar(255, 255, 255));

            Point pt1 = new Point(120, 150);
            Point pt2 = new Point(550, 150);

            Cv2.Circle(image, pt1, 1, new Scalar(0), 1);
            Cv2.Circle(image, pt2, 1, new Scalar(0), 1);

            //타원 그리기
            Cv2.Ellipse(image, pt1, new Size(100, 60), 0, 0, 360, orange, 2);
            Cv2.Ellipse(image, pt1, new Size(100, 60), 0, 30, 270, blue, 4);

            //호 그리기
            Cv2.Ellipse(image, pt2, new Size(100, 60), 30, 0, 360, orange, 2);
            Cv2.Ellipse(image, pt2, new Size(100, 60), 30, -30, 160, magenta, 4);

            Cv2.ImShow("타원 및 호 그리기", image);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
