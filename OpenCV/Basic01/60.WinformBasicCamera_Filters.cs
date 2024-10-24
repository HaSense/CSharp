using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFomBasicCamera
{
    public partial class Form1 : Form
    {
        private VideoCapture capture;  // 카메라 캡처 객체
        private Mat frame;             // 현재 프레임을 저장할 객체
        private bool isRunning = false;  // 카메라가 실행 중인지 확인하는 변수
        private enum CVMode { COLOR, BLACK, BGR, BLUR, SAPEN, SOBEL};     // 컬러 모드인지 확인하는 변수
        private CVMode currentMode = CVMode.COLOR;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);  // 카메라 장치 연결
            frame = new Mat();
            capture.Set(VideoCaptureProperties.FrameWidth, 640);  // 프레임 너비 설정
            capture.Set(VideoCaptureProperties.FrameHeight, 480); // 프레임 높이 설정

            btnStart_Click(sender, e);

        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (isRunning)  // 이미 카메라가 실행 중이면
            {
                isRunning = false;  // 실행 중 상태를 false로 변경
                btnStart.Text = "카메라 시작";  // 버튼 텍스트 변경
                return;
            }

            btnStart.Text = "카메라 멈춤";  // 버튼 텍스트 변경
            isRunning = true;  // 실행 중 상태를 true로 변경

            while (isRunning)  // 카메라가 실행 중이면
            {
                if (capture.IsOpened())  // 카메라가 연결되어 있으면
                {
                    capture.Read(frame);  // 프레임 읽기

                    switch(currentMode)
                    {
                        case CVMode.COLOR:
                            //
                            break;
                        case CVMode.BLACK:
                            Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);  
                            break;
                        case CVMode.BGR:
                            Cv2.CvtColor(frame, frame, ColorConversionCodes.RGB2BGR);
                            break;
                        case CVMode.BLUR:
                            Cv2.GaussianBlur(frame, frame, new OpenCvSharp.Size(25, 25), 0);
                            break;
                        case CVMode.SAPEN:
                            float[,] mask = new float[,]
                            {
                                {0, -1, 0 },
                                {-1, 5, -1 },
                                {0, -1, 0 },
                            };
                            Mat kernel = new Mat(3, 3, MatType.CV_32F);
                            for(int i=0; i<kernel.Rows; i++)
                            {
                                for(int j=0; j<kernel.Cols; j++)
                                {
                                    kernel.Set(i, j, mask[i, j]);
                                }
                            }
                            Cv2.Filter2D(frame, frame, frame.Depth(), kernel);
                            break;
                        case CVMode.SOBEL:
                            Mat gradX = new Mat();
                            Mat gradY = new Mat();
                            Mat absGradX = new Mat();
                            Mat absGradY = new Mat();
                            
                            Cv2.Sobel(frame, gradX, MatType.CV_16S, 1, 0, 3);
                            Cv2.Sobel(frame, gradY, MatType.CV_16S, 0, 1, 3);

                            //절대값 변환
                            Cv2.ConvertScaleAbs(gradX, absGradX);
                            Cv2.ConvertScaleAbs(gradY, absGradY);

                            //x축 y축 경계 결과 합침
                            Cv2.AddWeighted(absGradX, 0.6, absGradY, 0.6, 0, frame);
                            break;
                    }

                    ///////////////
                    Mat[] channels = Cv2.Split(frame);
                    for (int i = 0; i < channels.Length; i++)
                    {
                        double minVal, maxVal;
                        Cv2.MinMaxIdx(channels[i], out minVal, out maxVal);
                        double ratio = (maxVal - minVal) / 320.0;
                        Cv2.Subtract(channels[i], new Scalar(minVal), channels[i]);
                        Cv2.Divide(channels[i], new Scalar(ratio), channels[i]);
                        channels[i].ConvertTo(channels[i], MatType.CV_8U);
                    }

                    Mat dst = new Mat();
                    Cv2.Merge(channels, dst);
                    ///////////////
                    pictureBox1.Image = BitmapConverter.ToBitmap(dst);  // PictureBox에 영상 출력
                }
                await Task.Delay(33);  // 대략 30 fps
            }
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            isRunning = false;  // 카메라 중지
            capture.Release();  // 카메라 자원 해제
            Dispose();       // 프로그램 종료
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            currentMode = CVMode.BLACK;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            currentMode = CVMode.COLOR;
        }

        private void btnBGR_Click(object sender, EventArgs e)
        {
            currentMode = CVMode.BGR;
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            currentMode= CVMode.BLUR;
        }

        private void btnSharpen_Click(object sender, EventArgs e)
        {
            currentMode = CVMode.SAPEN;
        }

        private void btnSobel_Click(object sender, EventArgs e)
        {
            currentMode = CVMode.SOBEL;
        }
    }
}
