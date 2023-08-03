using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
 
namespace ConsoleSocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 서버의 인터넷 주소 및 포트 설정
            IPAddress serverAddr = IPAddress.Parse("127.0.0.1");
            int port = 13000;

            // 클라이언트 소켓 생성
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 서버에 연결
            clientSocket.Connect(new IPEndPoint(serverAddr, port));
            Console.WriteLine("서버에 연결되었습니다.");

            byte[] bytes = new byte[1024];
            int bytesReceived = clientSocket.Receive(bytes);

            // 메시지 수신
            string response = Encoding.UTF8.GetString(bytes, 0, bytesReceived);
            Console.WriteLine($"서버로부터 받은 메시지: {response}");

            // 클라이언트 소켓 종료
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
}
