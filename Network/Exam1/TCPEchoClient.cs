using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPEchoClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serverIp = "127.0.0.1";
            int port = 13000;
            TcpClient client = new TcpClient(serverIp, port);

            using (NetworkStream strem = client.GetStream())
            {
                Console.Write("메시지 작성 : ");
                byte[] Msg = Encoding.UTF8.GetBytes(Console.ReadLine());
                strem.Write(Msg, 0, Msg.Length);

                //메아리 받기
                byte[] echoMsgBytes = new byte[2048];
                int bytes = strem.Read(echoMsgBytes, 0, echoMsgBytes.Length);
                string echoMsg = Encoding.UTF8.GetString(echoMsgBytes);
                Console.WriteLine($"Echo 메시지 : " + echoMsg);
            }
        }
    }
}
