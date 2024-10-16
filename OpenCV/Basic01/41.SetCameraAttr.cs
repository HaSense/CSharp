using OpenCvSharp;

namespace SetCameraAttribute
{
    internal class Program
    {
        private static Mat frame = new Mat();
        private static VideoCapture capture = new VideoCapture(0);
        private static int zoomFactor = 1; // 줌 기본값
        private static int focusFactor = 40; // 포커스 기본값

        private static void ZoomBar(int value, IntPtr userdata)
        {
            zoomFactor = value;
        }
        private static void FocusBar(int value, IntPtr userdata)
        {
            focusFactor = value;
        }

        static void Main(string[] args)
        {
            capture.Open(0);
            if (!capture.IsOpened())
            {
                Console.WriteLine("카메라가 연결되지 않았습니다.");
                return;
            }

            // 카메라 속성 설정
            capture.Set(VideoCaptureProperties.FrameWidth, 800);
            capture.Set(VideoCaptureProperties.FrameHeight, 600);
            capture.Set(VideoCaptureProperties.AutoFocus, 0); // 수동 포커스 설정
            capture.Set(VideoCaptureProperties.Brightness, 200);

            // 창 및 트랙바 생성
            string title = "카메라 속성변경";
            Cv2.NamedWindow(title);
            Cv2.CreateTrackbar("Zoom", title, ref zoomFactor, 5, ZoomBar);
            Cv2.CreateTrackbar("Focus", title, ref focusFactor, 40, FocusBar);

            while (true)
            {
                capture.Read(frame); 
                if (frame.Empty())
                    break;

                //트랙바와 Focus
                capture.Set(VideoCaptureProperties.Zoom, zoomFactor);
                capture.Set(VideoCaptureProperties.Focus, focusFactor);

                // 줌 적용된 이미지
                ShowZoomedImage(zoomFactor);

                // 30ms 간격으로 키 입력 대기, 아무 키나 누르면 종료
                if (Cv2.WaitKey(30) >= 0)
                    break;
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }

        // 줌을 적용하여 이미지 크롭 및 확대하는 함수
        private static void ShowZoomedImage(int zoomLevel)
        {
            // 줌 레벨이 1보다 작거나 같으면 원본 표시
            if (zoomLevel <= 1)
            {
                Cv2.ImShow("카메라 속성변경", frame);
                return;
            }
            // 중앙 부분을 크롭하여 줌 효과 적용
            int newWidth = frame.Width / zoomLevel;
            int newHeight = frame.Height / zoomLevel;
            int x = (frame.Width - newWidth) / 2;
            int y = (frame.Height - newHeight) / 2;

            Rect roi = new Rect(x, y, newWidth, newHeight);
            Mat zoomedFrame = new Mat(frame, roi);

            // 크롭한 이미지를 다시 원래 크기로 확대
            Cv2.Resize(zoomedFrame, zoomedFrame, new Size(frame.Width, frame.Height));

            // 결과 이미지를 동일한 창에 표시
            Cv2.ImShow("카메라 속성변경", zoomedFrame);
        }
    }
}
