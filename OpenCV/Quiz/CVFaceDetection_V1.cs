using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVFaceDetection
{
    internal class Program
    {
        static void LoadCascade(CascadeClassifier cascade, string fname)
        {
            string path = @"C:/APIs/opencv/src/opencv-4.10.0/data/haarcascades/";  // 검출기 폴더
            string fullName = path + fname;

            if (!cascade.Load(fullName))
            {
                throw new Exception("분류기를 로드하는 중 오류가 발생했습니다.");
            }
        }

        static Mat Preprocessing(Mat image)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY); // 명암도 영상변환
            Cv2.EqualizeHist(gray, gray); // 히스토그램 평활화
            return gray;
        }

        static Point2d CalcCenter(Rect obj) // 사각형 중심 계산
        {
            Point2d c = new Point2d(obj.Width / 2.0, obj.Height / 2.0);
            Point2d center = new Point2d(obj.X + c.X, obj.Y + c.Y);
            return center;
        }

        static void Main(string[] args)
        {
            CascadeClassifier faceCascade = new CascadeClassifier();
            CascadeClassifier eyeCascade = new CascadeClassifier();


            LoadCascade(faceCascade, "haarcascade_frontalface_alt2.xml");
            LoadCascade(eyeCascade, "haarcascade_eye.xml");

            string imagePath = @"c:/Temp/opencv/face/w/59.jpg";
            Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 불러오는데 장애가 발생했어요~!");
                return;
            }

            Mat gray = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

            // 히스토그램 평활화는 필요에 따라 적용
            // Cv2.EqualizeHist(gray, gray);

            //캐니에지를 적용해 엣지가 잘 검출되지 않는 영역은 얼굴로 인식하지 않도록 필터링
            //속도도 빠르고 좋은 메소드지만 간혹 얼굴검출이 잘 안될 수도 있어서 주의바람!!!
            Rect[] faces = faceCascade.DetectMultiScale(gray, 1.1, 2, HaarDetectionTypes.DoCannyPruning);  

            foreach (Rect face in faces)
            {
                Mat faceROI = gray[face];
                Rect[] eyes = eyeCascade.DetectMultiScale(faceROI);

                if (eyes.Length > 0)
                {
                    // 여러 개의 눈이 검출될 수 있으므로 반복문으로 처리
                    foreach (Rect eye in eyes)
                    {
                        Point center = new Point(face.X + eye.X + eye.Width / 2, face.Y + eye.Y + eye.Height / 2);
                        Cv2.Circle(image, center, 5, Scalar.Green, 2);
                    }
                }

                Cv2.Rectangle(image, face, Scalar.Red, 2);
            }

            Cv2.ImShow("얼굴과 눈찾기", image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}

