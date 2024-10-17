using OpenCvSharp;

namespace WriteImage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat img8 = Cv2.ImRead(@"C:/Temp/opencv/read_color.jpg", ImreadModes.Color);
            if (img8.Empty())
            {
                Console.WriteLine("이미지를 불러오는 데 실패했습니다.");
                return;
            }

            int[] paramsJpg = { (int)ImwriteFlags.JpegQuality, 50 };  // JPEG 품질 50으로 설정
            int[] paramsPng = { (int)ImwriteFlags.PngCompression, 9 };  // PNG 압축 레벨 9로 설정
                                                                        // JPEG와 PNG 저장 파라미터 설정
            
            //out 폴더를 미리 만들어 주세요. 폴더생성과 예외처리를 넣으면 길어져서 생략해 봅니다.
            Cv2.ImWrite(@"C:/Temp/opencv/out/write_test1.jpg", img8); // 기본 설정으로 JPG 저장
            Cv2.ImWrite(@"C:/Temp/opencv/out/write_test2.jpg", img8, paramsJpg); // 품질 50으로 JPG 저장
            Cv2.ImWrite(@"C:/Temp/opencv/out/write_test.png", img8, paramsPng); // 압축 레벨 9로 PNG 저장
            Cv2.ImWrite(@"C:/Temp/opencv/out/write_test.bmp", img8); // BMP로 저장

            Console.WriteLine("이미지 저장이 완료되었습니다.");
        }
    }
}
