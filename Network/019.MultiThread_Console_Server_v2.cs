using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MultiThreadServer_v2
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
            serverSocket.Listen(10); // 동시에 최대 10개의 연결을 대기

            Console.WriteLine("연결을 기다리는 중...");

            // 클라이언트 연결을 계속 수락하는 루프
            while (true)
            {
                // 비동기적으로 클라이언트 연결 수락
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("클라이언트 연결 성공!");

                // 각 클라이언트의 처리를 별도의 Task에서 비동기적으로 수행
                Task.Run(() => HandleClient(clientSocket));
            }
        }

        private static void HandleClient(Socket clientSocket)
        {
            try
            {
                byte[] bytes = new byte[1024];
                string response = "안녕하세요, 클라이언트님!";
                byte[] data = Encoding.UTF8.GetBytes(response);

                // 메시지 전송
                clientSocket.Send(data);
                Console.WriteLine($"전송한 메시지: {response}");

                // 클라이언트로부터 메시지 수신
                int bytesRec = clientSocket.Receive(bytes);
                string receivedMessage = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                Console.WriteLine($"수신한 메시지: {receivedMessage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"에러 발생: {ex.Message}");
            }
            finally
            {
                // 클라이언트 연결 종료
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
