using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ColorCannyEdgeWinForm
{
    public partial class Form1 : Form
    {
        private Mat image, gray, edge;
        private int th = 50; // 캐니 에지 낮은 임계값
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "C:/Temp/opencv/smoothing.jpg";
            image = Cv2.ImRead(path, ImreadModes.Color);

            if (image.Empty())
            {
                MessageBox.Show("이미지를 불러올 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            gray = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

            pictureBox1.Image = BitmapConverter.ToBitmap(image);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            th = trackBar1.Value;
            edge = new Mat();

            // 가우시안 블러링 및 캐니 에지 수행
            Cv2.GaussianBlur(gray, edge, new OpenCvSharp.Size(3, 3), 0.7);
            Cv2.Canny(edge, edge, th, th * 2, 3);

            Mat colorEdge = new Mat();
            image.CopyTo(colorEdge, edge); // 에지 영역만 복사

            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(colorEdge);
        }

    }
}
