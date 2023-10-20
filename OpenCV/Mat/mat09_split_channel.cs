using OpenCvSharp;

namespace OpenCVSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = new Mat("abc.jpg", ImreadModes.Color);
            if (image.Empty())
            {
                throw new System.Exception("이미지를 찾을 수 없거나 불러올 수 없습니다.");
            }

            Mat[] bgr = Cv2.Split(image);

            Window windowImage = new Window("image", image);
            Window windowBlue = new Window("blue 채널", bgr[0]);
            Window windowGreen = new Window("green 채널", bgr[1]);
            Window windowRed = new Window("red 채널", bgr[2]);

            Cv2.WaitKey(0);
        }
    }
}
