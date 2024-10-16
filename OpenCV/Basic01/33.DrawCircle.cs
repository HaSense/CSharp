using OpenCvSharp;

namespace DrawCircle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scalar orange = new Scalar(0, 165, 255);
            Scalar blue = new Scalar(255, 0, 0);
            Scalar magenta = new Scalar(255, 0, 255);

            Mat image = new Mat(300, 500, MatType.CV_8UC3, new Scalar(255, 255, 255));

            Size size = image.Size();
            Point center = new Point(size.Width / 2, size.Height / 2);

            Point pt1 = new Point(70, 50);
            Point pt2 = new Point(350, 220);

            Cv2.Circle(image, center, 100, blue);
            Cv2.Circle(image, pt1, 80, orange, 2);
            Cv2.Circle(image, pt2, 60, magenta, -1);

            int font = (int)HersheyFonts.HersheyComplex;
            Cv2.PutText(image, "center_blue", center, HersheyFonts.HersheyComplex, 1.2, blue);
            Cv2.PutText(image, "pt1_orange", pt1, HersheyFonts.HersheyComplex, 0.8, orange);
            //Cv2.PutText(image, "pt2_magenta", pt2 + Point(2, 2), HersheyFonts.HersheyComplex, 0.5, new Scalar(0, 0, 0), 2);
            Point newPt2 = new Point(pt2.X + 2, pt2.Y + 2);
            Cv2.PutText(image, "pt2_magenta", newPt2, HersheyFonts.HersheyComplex, 0.5, new Scalar(0, 0, 0), 2);
            Cv2.PutText(image, "pt2_magenta", pt2, HersheyFonts.HersheyComplex, 0.5, magenta, 1);

            Cv2.ImShow("원그리기", image);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
