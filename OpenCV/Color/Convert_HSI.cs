using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertHSI
{
    class CVUtils
    {
        public void Bgr2Hsi(Mat img, out Mat hsv)
        {
            hsv = new Mat(img.Size(), MatType.CV_32FC3);

            for (int i = 0; i < img.Rows; i++)
            {
                for (int j = 0; j < img.Cols; j++)
                {
                    float B = img.At<Vec3b>(i, j)[0];
                    float G = img.At<Vec3b>(i, j)[1];
                    float R = img.At<Vec3b>(i, j)[2];

                    float s = 1 - 3 * Math.Min(R, Math.Min(G, B)) / (R + B + G);
                    float v = (R + G + B) / 3.0f;

                    float tmp1 = ((R - G) + (R - B)) * 0.5f;
                    float tmp2 = (float)Math.Sqrt((R - G) * (R - B) + (G - B) * (G - B));
                    //float angle = (float)Math.Acos(tmp1 / tmp2) * (180f / Math.PI);
                    float angle = (float)(Math.Acos(tmp1 / tmp2) * (180.0 / Math.PI));
                    float h = (B <= G) ? angle : 360 - angle;

                    hsv.Set(i, j, new Vec3f(h / 2, s * 255, v));
                }
            }
            hsv.ConvertTo(hsv, MatType.CV_8U);
        }
    }
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Mat BGR_img = Cv2.ImRead("c:/Temp/opencv/color_space.jpg", ImreadModes.Color);
            if (BGR_img.Empty())
            {
                throw new Exception("이미지를 읽을 수 없습니다.");
            }

            Mat HSI_img = new Mat();
            Mat HSV_img = new Mat();
            Mat[] hsi = new Mat[3];
            Mat[] hsv = new Mat[3];

            CVUtils cvUtils = new CVUtils();
            cvUtils.Bgr2Hsi(BGR_img, out HSI_img);

            // OpenCV 함수를 이용하여 HSV로 변환
            Cv2.CvtColor(BGR_img, HSV_img, ColorConversionCodes.BGR2HSV);

            // HSI 및 HSV 채널 분리
            Cv2.Split(HSI_img, out hsi);
            Cv2.Split(HSV_img, out hsv);

            // 이미지 출력
            Cv2.ImShow("BGR_img", BGR_img);
            Cv2.ImShow("Hue", hsi[0]);                      
            Cv2.ImShow("Saturation", hsi[1]);
            Cv2.ImShow("Intensity", hsi[2]);
            Cv2.ImShow("OpenCV_Hue", hsv[0]);               // OpenCV 제공 함수 이용
            Cv2.ImShow("OpenCV_Saturation", hsv[1]);
            Cv2.ImShow("OpenCV_Value", hsv[2]);

            Cv2.WaitKey();
        }
    }
}
