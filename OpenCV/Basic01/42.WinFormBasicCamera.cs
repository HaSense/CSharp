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
        private enum CVMode { COLOR, BLACK, BGR};     // 컬러 모드인지 확인하는 변수
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
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (isRunning)  // 이미 카메라가 실행 중이면
            {
                isRunning = false;  // 실행 중 상태를 false로 변경
                btnStart.Text = "Start";  // 버튼 텍스트 변경
                return;
            }

            btnStart.Text = "Stop";  // 버튼 텍스트 변경
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
                    }
                    

                    pictureBox1.Image = BitmapConverter.ToBitmap(frame);  // PictureBox에 영상 출력
                }
                await Task.Delay(33);  // 대략 30 fps
            }
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            isRunning = false;  // 카메라 중지
            capture.Release();  // 카메라 자원 해제
            this.Dispose();       // 프로그램 종료
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
    }
}
