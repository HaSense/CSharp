using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTcpFileServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. 인터넷 주소만들고 포트 만들기 ---> 서버만들기
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            int port = 13001;
            TcpListener server = new TcpListener(localAddr, port);
            server.Start();
            Console.WriteLine("서버 시작....");

            //2. 클라이언트와 접속할 소켓 만들고 클라이언트 기다리기
            using (TcpClient client = server.AcceptTcpClient()) //block I/O
            {
                Console.WriteLine("연결 성공!!!");

                //사진전송
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = File.ReadAllBytes(@"./newjeans.png");
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("전송이 완료되었습니다.");
                }
            }
                       
            server.Stop();

        }
    }
}
