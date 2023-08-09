namespace WinProgressTaskStop
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                for (int i = 0; i <= progressBar1.Maximum; i++)
                {
                    // 취소 요청이 있는지 확인
                    if (cts.Token.IsCancellationRequested)
                        return;

                    // progressBar1 값을 업데이트 (UI 스레드에서)
                    Invoke((Action)(() => progressBar1.Value = i));

                    // 일정 시간 대기
                    Thread.Sleep(100);
                }

                for (int i = 0; i <= progressBar2.Maximum; i++)
                {
                    // 취소 요청이 있는지 확인
                    if (cts.Token.IsCancellationRequested)
                        return;

                    // progressBar2 값을 업데이트 (UI 스레드에서)
                    Invoke((Action)(() => progressBar2.Value = i));

                    // 일정 시간 대기
                    Thread.Sleep(100);
                }
            }, cts.Token);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 작업을 취소하고 프로그레스바를 초기화
            cts.Cancel();
            progressBar1.Value = 0;
            progressBar2.Value = 0;
        }
    }
}
