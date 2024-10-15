using OpenCvSharp;

namespace OpenCVDraw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scalar blue = new Scalar(255, 0, 0);
            Scalar red = new Scalar(0, 0, 255);
            Scalar green = new Scalar(0, 255, 0);
            Scalar white = new Scalar(255, 255, 255);
            Scalar yellow = new Scalar(0, 255, 255);

            Mat image = new Mat(400, 600, MatType.CV_8UC3, white);
            Point pt1 = new Point(50, 130);
            Point pt2 = new Point(200, 300);
            Point pt3 = new Point(300, 150);
            Point pt4 = new Point(400, 50);
            Rect rect = new Rect(pt3, new Size(200, 150));

            //라인
            Cv2.Line(image, pt1, pt2, red, 1, LineTypes.AntiAlias);
            Cv2.Line(image, pt3, pt4, green, 2, LineTypes.AntiAlias);
            Cv2.Line(image, pt3, pt4, green, 3, LineTypes.Link8, 1);
            //사각형 그리기
            Cv2.Rectangle(image, rect, blue, 2, LineTypes.AntiAlias);
            Cv2.Rectangle(image, rect, blue, -1, LineTypes.Link4, 1);
            Cv2.Rectangle(image, pt1, pt2, red, 3);

            //출력
            Cv2.ImShow("image", image);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
