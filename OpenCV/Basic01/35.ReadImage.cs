

using OpenCvSharp;

namespace ReadImage
{
    class ImageUtil
    {
        public void PrintMatInfo(string name, Mat img)
        {
            string str;
            int depth = img.Depth();

            if (depth == MatType.CV_8U) str = "CV_8U";
            else if (depth == MatType.CV_8S) str = "CV_8S";
            else if (depth == MatType.CV_16U) str = "CV_16U";
            else if (depth == MatType.CV_16S) str = "CV_16S";
            else if (depth == MatType.CV_32S) str = "CV_32S";
            else if (depth == MatType.CV_32F) str = "CV_32F";
            else if (depth == MatType.CV_64F) str = "CV_64F";
            else str = "Unknown";

            Console.WriteLine($"{name}: depth({depth}) channels({img.Channels()}) -> 자료형: {str}C{img.Channels()}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename1 = @"C:/Temp/opencv/read_gray.jpg";
            Mat gray2gray = Cv2.ImRead(filename1, ImreadModes.Grayscale);
            Mat gray2color = Cv2.ImRead(filename1, ImreadModes.Color);

            if (gray2gray.Empty() || gray2color.Empty())
            {
                Console.WriteLine("이미지를 불러오는 데 실패했습니다.");
                return;
            }

            // ROI 영역 설정 (100, 100 위치의 1x1 픽셀)
            Rect roi = new Rect(100, 100, 1, 1);
            Console.WriteLine("행렬 좌표 (100,100) 화소값");
            Console.WriteLine($"gray2gray: {gray2gray.SubMat(roi).Dump()}");
            Console.WriteLine($"gray2color: {gray2color.SubMat(roi).Dump()}\n");

            ImageUtil iu =new ImageUtil(); 
            iu.PrintMatInfo("gray2gray", gray2gray);
            iu.PrintMatInfo("gray2color", gray2color);

            Cv2.ImShow("gray2gray", gray2gray);
            Cv2.ImShow("gray2color", gray2color);
            Cv2.WaitKey(0);
        }
    }
}
