using OpenCvSharp;

namespace MatFlip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String path = @"C:/Temp/opencv/flip_test.jpg";
            Mat image = new Mat(path, ImreadModes.Color);
            if (image.Empty())
            {
                Console.WriteLine("경로나 이미지에 문제가 있습니다.");
            }

            Mat x_axis = new Mat();
            Mat y_axis = new Mat();
            Mat xy_axis = new Mat();
            Mat rep_img = new Mat();
            Mat trans_img = new Mat();
            
            Cv2.Flip(image, x_axis, FlipMode.X);
            Cv2.Flip(image, y_axis, FlipMode.Y);
            Cv2.Flip(image, xy_axis, FlipMode.XY);

            Cv2.Repeat(image, 2, 2, rep_img);
            Cv2.Transpose(image, trans_img);

            Cv2.ImShow("image", image);
            Cv2.ImShow("x_axis", x_axis);
            Cv2.ImShow("y_axis", y_axis);
            Cv2.ImShow("xy_axis", xy_axis);
            Cv2.ImShow("rep_img", rep_img);
            Cv2.ImShow("trans_img", trans_img);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }
    }
}
