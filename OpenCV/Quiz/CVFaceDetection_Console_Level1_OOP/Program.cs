using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVFaceDetectionOOP_V1_OOP
{
    // 분류기 로더 클래스 정의
    public class CascadeLoader
    {
        private readonly string basePath;

        // 생성자: 분류기 파일의 기본 경로 설정
        public CascadeLoader(string basePath)
        {
            this.basePath = basePath;
        }

        // 분류기 파일을 로드하는 메서드
        public void LoadCascade(CascadeClassifier cascade, string fileName)
        {
            string fullPath = this.basePath + fileName;
            if (!cascade.Load(fullPath))
            {
                throw new Exception("분류기를 로드하는 중 오류가 발생했습니다.");
            }
        }
    }

    // 얼굴 및 눈 검출기 클래스 정의
    public class FaceDetector
    {
        private readonly CascadeClassifier faceClassifier;
        private readonly CascadeClassifier eyeClassifier;

        // 생성자: 얼굴 및 눈 분류기 초기화
        public FaceDetector(CascadeLoader loader, string faceCascadePath, string eyeCascadePath)
        {
            this.faceClassifier = new CascadeClassifier();
            this.eyeClassifier = new CascadeClassifier();

            loader.LoadCascade(this.faceClassifier, faceCascadePath);
            loader.LoadCascade(this.eyeClassifier, eyeCascadePath);
        }

        // 얼굴 및 눈을 검출하고 이미지에 그리는 메서드
        public void DetectAndDrawFaces(Mat image, Mat grayImage)
        {
            // 얼굴 검출
            Rect[] faces = this.faceClassifier.DetectMultiScale(grayImage, 1.1, 2, HaarDetectionTypes.DoCannyPruning);

            foreach (Rect face in faces)
            {
                // 얼굴 영역을 추출
                Mat faceROI = grayImage[face];
                // 눈 검출
                Rect[] eyes = this.eyeClassifier.DetectMultiScale(faceROI);

                foreach (Rect eye in eyes)
                {
                    // 눈 중심 계산
                    Point center = new Point(face.X + eye.X + eye.Width / 2, face.Y + eye.Y + eye.Height / 2);
                    // 눈 위치에 원 그리기
                    Cv2.Circle(image, center, 5, Scalar.Green, 2);
                }
                // 얼굴 영역에 사각형 그리기
                Cv2.Rectangle(image, face, Scalar.Red, 2);
            }
        }
    }

    // 이미지 전처리 클래스 정의
    public static class ImageProcessor
    {
        // 명암도 변환 및 히스토그램 평활화를 수행하는 메서드
        public static Mat PreprocessImage(Mat image)
        {
            Mat gray = new Mat();
            // 컬러 이미지를 흑백영상으로 변환
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
            
            Cv2.EqualizeHist(gray, gray); //히스토그램 평활화
            
            return gray;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string faceCascadePath = "haarcascade_frontalface_alt2.xml"; // 얼굴 검출용 분류기 파일 경로
            string eyeCascadePath = "haarcascade_eye.xml"; // 눈 검출용 분류기 파일 경로
            string imagePath = "c:/Temp/opencv/face/w/59.jpg";

            // 분류기 로더 초기화
            CascadeLoader cascadeLoader = new CascadeLoader("C:/APIs/opencv/src/opencv-4.10.0/data/haarcascades/");
            // 얼굴 및 눈 검출기 초기화
            FaceDetector faceDetector = new FaceDetector(cascadeLoader, faceCascadePath, eyeCascadePath);

            // 이미지를 컬러 모드로 불러오기
            Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);
            if (image.Empty()) //그림 불러오기 에러처리
            {
                Console.WriteLine("이미지를 불러오는데 장애가 발생했어요~!");
                return;
            }

            // 이미지 전처리 (명암도 변환 및 히스토그램 평활화)
            Mat gray = ImageProcessor.PreprocessImage(image);
            // 얼굴과 눈 검출 및 결과 이미지에 그리기
            faceDetector.DetectAndDrawFaces(image, gray);

            Cv2.ImShow("얼굴과 눈찾기", image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
