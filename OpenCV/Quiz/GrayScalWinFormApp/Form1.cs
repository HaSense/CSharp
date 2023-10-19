using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrayScalWinFormApp
{
    
    public partial class Form1 : Form
    {
        private Mat src;
        private Mat grayImg, colorImg;

        public Form1()
        {
            InitializeComponent();
        }
        //흑백영상 출력
        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            string path = "src.jpg";

            using (src = new Mat(path, ImreadModes.Color))
            {
                // 원본 이미지의 복사본을 만듭니다.
                Mat copyColorImg = src.Clone();

                grayImg = new Mat();
                Cv2.CvtColor(copyColorImg, grayImg, ColorConversionCodes.BGR2GRAY);

                Bitmap bmp = BitmapConverter.ToBitmap(grayImg);
                pictureBox1.Image = bmp;
            }
        }
        //컬러 영상 출력
        private void btnColor_Click(object sender, EventArgs e)
        {
            string path = "src.jpg";

            using (src = new Mat(path, ImreadModes.Color))
            {
                // 원본 이미지의 복사본을 만듭니다.
                colorImg = src.Clone();

                Bitmap bmp = BitmapConverter.ToBitmap(colorImg);
                pictureBox1.Image = bmp;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)pictureBox1.Image;
            // 이미지를 저장할 경로와 파일 이름을 지정합니다.
            string savePath = "CV.jpeg";
            // 이미지를 JPEG 형식으로 저장합니다.
            bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("이미지가 저장되었습니다", "Save");
            
        }

    }
}
