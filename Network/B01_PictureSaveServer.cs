using System.Net.Sockets;
using System.Net;

namespace PictureSaveServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 13000);
            listener.Start();

            Console.WriteLine("서버가 시작되었습니다. 클라이언트를 기다리는 중...");

            // 클라이언트 연결 수락
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("클라이언트가 연결되었습니다.");

            // 네트워크 스트림 생성
            NetworkStream networkStream = client.GetStream();

            // 그림 파일 수신 및 저장
            using (FileStream fileStream = new FileStream("received_image.png", FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }

            Console.WriteLine("파일 수신 완료.");

            // 연결 종료
            networkStream.Close();
            client.Close();
            listener.Stop();
        }
    }
}
