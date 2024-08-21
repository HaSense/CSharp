using System.Net.Sockets;
using System.Text;

namespace ChatTCPClient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToServer();
        }
        private void ConnectToServer()
        {
            string server = "127.0.0.1";
            int port = 13000;

            try
            {
                client = new TcpClient(server, port);
                stream = client.GetStream();

                receiveThread = new Thread(ReceiveMsg);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                AppendText("서버에 연결되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버에 연결할 수 없습니다: " + ex.Message);
            }
        }
        private void btnMsg_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.");
                return;
            }

            string message = txtMsg.Text;
            byte[] Msg = Encoding.UTF8.GetBytes(message);
            stream.Write(Msg, 0, Msg.Length); // 메시지 전송

            AppendText("나: " + message); //화면에 내가 보낸 글자 추가

            txtMsg.Text = "";
        }
        private void ReceiveMsg()
        {
            try
            {
                byte[] buffer = new byte[256];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string receiveMsg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AppendText("받은 메시지: " + receiveMsg);
                }
            }
            catch (Exception ex)
            {
                AppendText("서버로부터 메시지 수신 중 오류 발생: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        private void Disconnect()
        {
           /// isRunning = false; // 스레드 종료 신호
            
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();

            AppendText("서버와의 연결이 종료되었습니다.");
        }

        // UI 스레드에서 안전하게 텍스트박스에 메시지를 추가하는 메서드
        private void AppendText(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendText), new object[] { text });
            }
            else
            {
                txtResult.AppendText(text + Environment.NewLine);
            }
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
