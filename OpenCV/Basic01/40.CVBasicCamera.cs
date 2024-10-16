using OpenCvSharp;

namespace CVBasicCamera
{
    class StringUtil
    {
        public void PutString(Mat frame, string text, Point pt, double value)
        {
            text += value.ToString();
            Point shade = new Point(pt.X + 2, pt.Y + 2);
            int font = (int)HersheyFonts.HersheySimplex;

            // 그림자 효과 
            Cv2.PutText(frame, text, shade, (HersheyFonts)font, 0.7, Scalar.Black, 2);

            // 실제 텍스트 
            Cv2.PutText(frame, text, pt, (HersheyFonts)font, 0.7, new Scalar(120, 200, 90), 2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 웹캠 연결
            VideoCapture capture = new VideoCapture(0);
            if (!capture.IsOpened())
            {
                Console.WriteLine("카메라가 연결되지 않았습니다.");
                return;
            }

            // 카메라 속성 출력
            Console.WriteLine("너비: " + capture.Get(VideoCaptureProperties.FrameWidth));
            Console.WriteLine("높이: " + capture.Get(VideoCaptureProperties.FrameHeight));
            Console.WriteLine("노출: " + capture.Get(VideoCaptureProperties.Exposure));
            Console.WriteLine("밝기: " + capture.Get(VideoCaptureProperties.Brightness));

            Mat frame = new Mat();
            while(true)
            {
                // 카메라에서 프레임 읽기
                capture.Read(frame);
                if (frame.Empty())
                    break;

                // 노출 정보 출력
                StringUtil su = new StringUtil();
                su.PutString(frame, "EXPOS: ", new Point(10, 40), capture.Get(VideoCaptureProperties.Exposure));
                
                Cv2.ImShow("카메라 영상보기", frame);

                // 키 입력 대기 (30ms)
                if (Cv2.WaitKey(30) >= 0)
                    break;
            }
            Cv2.DestroyAllWindows();
        }
    }
}
