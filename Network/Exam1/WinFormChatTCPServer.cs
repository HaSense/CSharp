using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinFormTCPChattingServer
{
    public partial class Form1 : Form
    {
        private static TcpListener server = null;
        private static List<TcpClient> clientList = new List<TcpClient>();

        public Form1()
        {
            InitializeComponent();

            Thread serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
        }
        private void StartServer()
        {
            try
            {
                IPAddress serverIp = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(serverIp, 13000);

                server.Start();
                AppendText("Chat Server 시작...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    AppendText("클라이언트가 연결되었습니다.");

                    lock (clientList)
                    {
                        clientList.Add(client);
                    }

                    Thread clientThread = new Thread(ClientAction);
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("소켓 예외: " + ex.ToString());
            }
            finally
            {
                if (server != null)
                {
                    server.Stop();
                }
            }
        }
        private void ClientAction(object obj)
        {
            TcpClient client = (TcpClient)obj;
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[256];
                    int bytesRead;

                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        AppendText("클라이언트로부터 받은 메시지: " + receivedMessage);

                        BroadcastMessage(receivedMessage, client);
                    }
                }
            }
            catch (Exception e)
            {
                AppendText("클라이언트 처리 중 예외 발생: " + e.Message);
            }
            finally
            {
                lock (clientList)
                {
                    clientList.Remove(client);
                }
                if (client != null)
                {
                    client.Close();
                }
                AppendText("클라이언트 연결이 종료되었습니다.");
            }
        }

        private void BroadcastMessage(string message, TcpClient senderClient)
        {
            byte[] broadcastMsg = Encoding.UTF8.GetBytes(message);

            lock (clientList)
            {
                foreach (TcpClient client in clientList)
                {
                    if (client != senderClient)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            stream.Write(broadcastMsg, 0, broadcastMsg.Length);
                        }
                        catch (Exception ex)
                        {
                            AppendText("메시지 전송 중 예외 발생: " + ex.Message);
                        }
                    }
                }
            }
            AppendText("메시지를 모든 클라이언트에게 전송했습니다.");
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
                
    }
}
