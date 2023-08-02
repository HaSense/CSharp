using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConsoleTCPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 인터넷 주소 설정
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            // 포트 설정
            int port = 13000;
            // 서버 생성
            TcpListener server = new TcpListener(localAddr, port);

            try
            {
                // 서버 시작
                server.Start();
                Console.WriteLine("연결을 기다리는 중...");

                while (true)
                {
                    // 클라이언트 연결 수락
                    TcpClient client = server.AcceptTcpClient();
                    // 클라이언트 요청 처리 시작
                    Task.Run(() => HandleClient(client));
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
            finally
            {
                // 종료하기 전에 서버를 멈춥니다.
                server.Stop();
            }
        }

        static void HandleClient(TcpClient client)
        {
            try
            {
                Console.WriteLine("연결 성공!");

                using (NetworkStream stream = client.GetStream())
                {
                    string response = "안녕하세요, 클라이언트님!";
                    byte[] data = Encoding.UTF8.GetBytes(response);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"전송한 메시지: {response}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            finally
            {
                // 예외가 발생하더라도 클라이언트를 닫습니다.
                client.Close();
            }
        }
    }
}
