using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPListenerEchoServer
{
    internal class Program
    {
        private static TcpListener server = null;
        static void Main(string[] args)
        {
            try
            {
                IPAddress serverIP = IPAddress.Parse("127.0.0.1");
                int port = 13000;

                server = new TcpListener(serverIP, port);
                server.Start();

                Console.WriteLine("Echo Server 시작 ...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("클라이언트가 연결되었습니다.");

                    Thread clientThread = new Thread(new ParameterizedThreadStart(ClientAction));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(server != null)
                {
                    server.Stop();
                }
            }//end finally
        }//end of main

        static void ClientAction(object obj)
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
                    Console.WriteLine("클라이언트에게 받은 메시지 : " + receiveMsg);

                    //보내기
                    byte[] echoMsg = Encoding.UTF8.GetBytes(receiveMsg);
                    stream.Write(echoMsg, 0, echoMsg.Length);
                    Console.WriteLine("에코메시지 전송 완료");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(client != null)
                {
                    client.Close();
                }
            }
            

        }

    }//end of Program class
}
