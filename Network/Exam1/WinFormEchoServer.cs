using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinFormEchoServer
{
    public partial class Form1 : Form
    {
        private static TcpListener server = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
        }//end of Form1_Load
        private void StartServer()
        {
            try
            {
                IPAddress serverIP = IPAddress.Parse("127.0.0.1");
                int port = 13000;

                server = new TcpListener(serverIP, port);
                server.Start();

                //textBox1.AppendText("Echo Server 시작 ...\n");
                AppendText("Echo Server 시작 ...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    //textBox1.AppendText("클라이언트가 연결되었습니다.\n");
                    AppendText("클라이언트가 연결되었습니다.");

                    Thread clientThread = new Thread(new ParameterizedThreadStart(ClientAction));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
            }
            finally
            {
                if (server != null)
                {
                    server.Stop();
                }
            }//end finally
        }//end of StartServer
        private void ClientAction(object obj)
        {
            TcpClient client = (TcpClient)obj;
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    //받기
                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string receiveMsg = Encoding.UTF8.GetString(buffer);
                    //Console.WriteLine("클라이언트에게 받은 메시지 : " + receiveMsg);
                    AppendText("클라이언트에게 받은 메시지 : " + receiveMsg);


                    //보내기
                    byte[] echoMsg = Encoding.UTF8.GetBytes(receiveMsg);
                    stream.Write(echoMsg, 0, echoMsg.Length);
                    //Console.WriteLine("에코메시지 전송 완료");
                    AppendText("에코메시지 전송 완료");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        private void AppendText(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendText), new object[] { text });
            }
            else
            {
                textBox1.AppendText(text + Environment.NewLine);
            }
        }


    }//end of Form
}
