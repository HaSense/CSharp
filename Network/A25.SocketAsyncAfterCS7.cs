/*
C# 7.1 이후로 Main를 async Task 리턴 타입으로 지정할 수 있게 되었습니다.
그 이전에는 A24코드 처럼 따로 하나의 스레드를 만들어 사용하였습니다.
*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSocketServer
{
    internal class Program
    {
        static async Task Main(string[] args)
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
            serverSocket.Listen(10); // 동시에 대기할 최대 연결 수를 10으로 설정
            Console.WriteLine("연결을 기다리는 중...");

            while (true)
            {
                // 클라이언트 연결 수락
                Socket clientSocket = await serverSocket.AcceptAsync();
                // 클라이언트 요청 처리 시작
                HandleClientAsync(clientSocket);
            }
        }

        static async void HandleClientAsync(Socket clientSocket)
        {
            try
            {
                Console.WriteLine("연결 성공!");

                string response = "안녕하세요, 클라이언트님!";
                byte[] data = Encoding.UTF8.GetBytes(response);

                // 메시지 전송
                await clientSocket.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);
                Console.WriteLine($"전송한 메시지: {response}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                // 예외가 발생하더라도 클라이언트를 닫습니다.
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
