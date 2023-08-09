/*
타이머를 사용하여 멈추는 방법
*/

namespace WinProgressTaskStop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!timer1.Enabled) // 타이머가 활성화되지 않았다면 시작
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1; // 프로그레스바 값을 1 증가
            }
            else
            {
                timer1.Stop(); // 최대값에 도달하면 타이머 중지
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // 타이머 중지
            progressBar1.Value = 0; // 프로그레스바 값을 초기화
        }
    }
}
