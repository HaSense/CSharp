using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleSocketServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 인터넷 주소 설정
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            // 포트 설정
            int port = 13000;

            // 서버 소켓 생성
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 로컬 주소 및 포트에 바인드
            serverSocket.Bind(new IPEndPoint(localAddr, port));

            // 연결 요청 대기 시작
            serverSocket.Listen(1);
            Console.WriteLine("연결을 기다리는 중...");

            // 클라이언트 연결 수락
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("연결 성공!");

            byte[] bytes = new byte[1024];
            string response = "안녕하세요, 클라이언트님!";
            byte[] data = Encoding.UTF8.GetBytes(response);

            // 메시지 전송
            clientSocket.Send(data);
            Console.WriteLine($"전송한 메시지: {response}");

            // 클라이언트 연결 종료
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();

            // 서버 소켓 종료
            serverSocket.Close();
        }
    }
}
