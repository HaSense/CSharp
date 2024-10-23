using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertCMYK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Mat BGR_img = Cv2.ImRead(@"c:/Temp/opencv/color_model.jpg", ImreadModes.Color);
            if (BGR_img.Empty())
            {
                throw new System.Exception("이미지를 읽을 수 없습니다.");
            }
           
            Scalar white = new Scalar(255, 255, 255);

            // CMY 이미지 생성 (white - BGR_img)
            Mat CMY_img = new Mat();
            Cv2.Subtract(white, BGR_img, CMY_img);

            // CMY 채널 분리
            Mat[] CMY_arr = Cv2.Split(CMY_img);
           
            Cv2.ImShow("BGR_img", BGR_img);
            Cv2.ImShow("CMY_img", CMY_img);
            Cv2.ImShow("Yellow", CMY_arr[0]);
            Cv2.ImShow("Magenta", CMY_arr[1]);
            Cv2.ImShow("Cyan", CMY_arr[2]);

            Cv2.WaitKey(0);
        }
    }
}
