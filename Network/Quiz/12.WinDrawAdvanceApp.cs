using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDrawAdvancedApp01
{
    public partial class Form1 : Form
    {
        private bool drawCircle = false;
        private int elapsed = 0; // 버튼이 클릭된 후 경과한 시간
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawCircle = false; //false일때 삼각형 상태임
            elapsed = 0; // 경과 시간을 초기화
            progressBar1.Value = 0; // 프로그래스 바를 초기화
            panel1.Invalidate(); // 패널을 다시 그림
            timer1.Start(); // 타이머를 시작
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (!drawCircle)
            {
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 50), new Point(300, 100) };
                g.FillPolygon(Brushes.Blue, points);
            }
            else
            { 
                g.FillEllipse(Brushes.Blue, new Rectangle(100, 50, 200, 100));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            elapsed += timer1.Interval; // 경과 시간 증가
            // 프로그래스 바 업데이트
            progressBar1.Value = Math.Min(elapsed, progressBar1.Maximum);

            if (elapsed >= progressBar1.Maximum)
            {
                drawCircle = true; //원이 되었으면 상태를 true로 변경
                panel1.Invalidate(); // 패널을 다시 그림
                timer1.Stop(); // 타이머를 멈춤
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 3000; // 프로그래스바 3초(3000milsec)를 이용
            progressBar1.Value = 0; //0으로 초기화
            timer1.Interval = 100; // 타이머 인터벌이 초기값이 100이다. 
            //위 세줄은 컨트롤에서 작성하게 되면 적지 않아도 된다.
        }
    }
}
