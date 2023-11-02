using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* AffineTransform 코드를 객체지향 코드로 변환 */

namespace AffineTransformOOP
{
    // ITransform: 변환 인터페이스 (Interface Segregation Principle)
    public interface ITransform
    {
        Mat Apply(Mat image);
    }

    // AffineTransformer: 어파인 변환을 적용하는 클래스 (Single Responsibility Principle)
    public class AffineTransformer : ITransform
    {
        private readonly Mat _map;

        public AffineTransformer(Mat map)
        {
            _map = map;
        }

        // Apply: 이미지에 어파인 변환을 적용하여 결과를 반환한다.
        public Mat Apply(Mat image)
        {
            var dst = new Mat(image.Size(), MatType.CV_8UC1);
            var helper = new AffineHelper();
            helper.AffineTransform(image, dst, _map);
            return dst;
        }
    }
    // AffineHelper: 어파인 변환과 관련된 보조 메서드를 제공하는 클래스
    internal class AffineHelper
    {
        // BilinearValue: 양선형 보간을 통해 픽셀 값을 반환한다.
        public byte BilinearValue(Mat img, double x, double y)
        {
            if (x >= img.Cols - 1) x--;
            if (y >= img.Rows - 1) y--;

            Point pt = new Point((int)x, (int)y);
            int A = img.At<byte>(pt.Y, pt.X);
            int B = img.At<byte>(pt.Y + 1, pt.X);
            int C = img.At<byte>(pt.Y, pt.X + 1);
            int D = img.At<byte>(pt.Y + 1, pt.X + 1);

            double alpha = y - pt.Y;
            double beta = x - pt.X;

            int P = A + (int)Math.Round(alpha * (B - A) + beta * (C - A + alpha * (D - B - C + A)));
            return (byte)P;
        }

        // AffineTransform: 이미지에 어파인 변환을 적용한다.
        public void AffineTransform(Mat img, Mat dst, Mat map)
        {
            Rect imgRect = new Rect(new Point(0, 0), img.Size());

            Mat invMap = new Mat();
            Cv2.InvertAffineTransform(map, invMap);

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    Point3d targetPoint = new Point3d(j, i, 1);
                    Mat sourcePointMat = invMap * new Mat(3, 1, MatType.CV_64FC1, new double[] { targetPoint.X, targetPoint.Y, targetPoint.Z });
                    Point2d sourcePoint = new Point2d(sourcePointMat.At<double>(0), sourcePointMat.At<double>(1));

                    if (imgRect.Contains(sourcePoint.ToPoint()))
                        dst.At<byte>(i, j) = BilinearValue(img, sourcePoint.X, sourcePoint.Y);
                }
            }
        }
    }
    //이미지 로딩 및 기본설정 담당 클래스
    public class ImageConfig
    {
        public Mat Image { get; private set; }
        public Point2f[] SourcePoints { get; private set; }
        public Point2f[] TargetPoints { get; private set; }

        public ImageConfig(string imagePath)
        {
            Image = new Mat(imagePath, ImreadModes.Grayscale);
            if (Image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            SourcePoints = new Point2f[] { new Point2f(10, 200), new Point2f(200, 150), new Point2f(280, 280) };
            TargetPoints = new Point2f[] { new Point2f(10, 10), new Point2f(250, 10), new Point2f(280, 280) };
        }
    }
    //회전 설정을 위한 클래스
    public class RotationConfig
    {
        public Point Center { get; private set; }
        public double Angle { get; private set; }
        public double Scale { get; private set; }

        public RotationConfig()
        {
            Center = new Point(200, 100);
            Angle = 30.0;
            Scale = 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var imgConfig = new ImageConfig("C:\\Temp\\img\\affine_test3.jpg");
            var rotConfig = new RotationConfig();

            Mat affMap = Cv2.GetAffineTransform(imgConfig.SourcePoints, imgConfig.TargetPoints);
            Mat rotMap = Cv2.GetRotationMatrix2D(rotConfig.Center, rotConfig.Angle, rotConfig.Scale);

            ITransform affineTransform = new AffineTransformer(affMap);
            ITransform rotationTransform = new AffineTransformer(rotMap);

            Mat dst1 = affineTransform.Apply(imgConfig.Image);
            Mat dst2 = rotationTransform.Apply(imgConfig.Image);

            Mat dst3 = new Mat(imgConfig.Image.Size(), MatType.CV_8UC1);
            Mat dst4 = new Mat(imgConfig.Image.Size(), MatType.CV_8UC1);

            Cv2.WarpAffine(imgConfig.Image, dst3, affMap, imgConfig.Image.Size(), InterpolationFlags.Linear);
            Cv2.WarpAffine(imgConfig.Image, dst4, rotMap, imgConfig.Image.Size(), InterpolationFlags.Linear);

            Cv2.CvtColor(imgConfig.Image, imgConfig.Image, ColorConversionCodes.GRAY2BGR);
            Cv2.CvtColor(dst1, dst1, ColorConversionCodes.GRAY2BGR);

            Scalar color = new Scalar(0, 0, 255);
            for (int i = 0; i < 3; i++)
            {
                Cv2.Circle(imgConfig.Image, (Point)imgConfig.SourcePoints[i], 3, color, 2);
                Cv2.Circle(dst1, (Point)imgConfig.TargetPoints[i], 3, color, 2);
            }

            Cv2.ImShow("원본 이미지", imgConfig.Image);
            Cv2.ImShow("어파인 변환 이미지", dst1);
            Cv2.ImShow("회전 이미지", dst2);
            Cv2.ImShow("OpenCV 어파인 변환 이미지", dst3);
            Cv2.ImShow("OpenCV 회전 이미지", dst4);

            Cv2.WaitKey();
        }
    }
}
