using System.Net.Sockets;

namespace PictureSendClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 서버 IP와 포트 설정
            string serverIp = "127.0.0.1";
            int port = 13000;

            // TCP 클라이언트 생성 및 서버 연결
            TcpClient client = new TcpClient(serverIp, port);
            Console.WriteLine("서버에 연결되었습니다.");

            // 네트워크 스트림 생성
            NetworkStream networkStream = client.GetStream();

            // 전송할 파일 경로 설정
            string filePath = "image_to_send.png";

            // 파일 읽기 및 서버로 전송
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    networkStream.Write(buffer, 0, bytesRead);
                }
            }

            Console.WriteLine("파일 전송 완료.");

            // 연결 종료
            networkStream.Close();
            client.Close();
        }
    }
}
