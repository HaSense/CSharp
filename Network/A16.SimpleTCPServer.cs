using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTCPServer
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //인터넷 주소만들기 127.0.0.1은 localhost와 동치임
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            //포트만들기
            int port = 13000;
            //서버만들기
            TcpListener server = new TcpListener(localAddr, port);
            //시작
            server.Start();
            Console.WriteLine("연결을 기다리는 중...");

            //Listen하며 기다리기
            using (TcpClient client = server.AcceptTcpClient())
            {
                Console.WriteLine("연결 성공!");

                //주고받기
                using (NetworkStream stream = client.GetStream())
                {
                    string response = "안녕하세요, 클라이언트님!";
                    //한글의 경우 UTF-8 byte로 직렬화
                    byte[] data = Encoding.UTF8.GetBytes(response);

                    //이 코드가 전송코드, stream에 쓰는 동작 만으로 네트워크 전송이 일어남!!!
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"전송한 메시지: {response}");
                }
            }
            server.Stop();//IDispose를 직접 구현하지 않아 따로 처리해야 함
        }
    }
}

