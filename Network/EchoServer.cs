using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("사용법 : {0} <Bind IP>",
                    Process.GetCurrentProcess().ProcessName);
                return;
            }

            string bindIp = args[0];        //Binding할 IP, 주로 localhost 또는 127.0.0.1
            const int bindPort = 5425;      //Bind할 IP
            TcpListener server = null;      //Server Socket
            try
            {
                //IPEndPoint는 IP통신에 필요한 IP주소와 포트를 나타냅니다.
                IPEndPoint localAddress =
                    new IPEndPoint(IPAddress.Parse(bindIp), bindPort);

                server = new TcpListener(localAddress);

                server.Start(); //클라이언트가 연결요청을 해오기를 기다립니다. Block I/O

                Console.WriteLine("메아리 서버 시작... ");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();    //클라이언트 접속이 있어야 동작됩니다. 아니면 기아상태(Block된 상태)
                    Console.WriteLine("클라이언트 접속 : {0} ",
                        ((IPEndPoint)client.Client.RemoteEndPoint).ToString());

                    //TCPClient를 통해 stream은 통신에 필요한 NetworkStream 객체를 얻습니다.
                    NetworkStream stream = client.GetStream(); //클라이언트 스트림을 호출합니다.

                    int length;
                    string data = null;                 //문자열을 주고 받을 예정이라 문자열 변수를 data라 정했습니다.
                    byte[] bytes = new byte[256];       //문자열은 스트림으로 보낼때 바이트 배열로 보낼 예정이고
                                                        //byte 배열의 크기를 256bytes로 정했습니다. 이를 buffer_size 라고 이야기 하기도 합니다. 

                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) //클라이언트로 부터 읽어올 내용이 있으면 while문은 참입니다.
                    {
                        data = Encoding.Default.GetString(bytes, 0, length); //문자열을 읽어오는 방법
                        Console.WriteLine(String.Format("수신: {0}", data));

                        byte[] msg = Encoding.Default.GetBytes(data); //문자열을 바이트 배열로 만드는 방법

                        stream.Write(msg, 0, msg.Length); //바이트배열을 소켓으로 송출하는 방법
                        Console.WriteLine(String.Format("송신: {0}", data));
                    }

                    stream.Close();  //통신작업이 끝나면 자원들을 모두 닫아 줍시다.
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                server.Stop(); //에러유무에 상관없이 서버는 종료됩니다.
            }

            Console.WriteLine("서버를 종료합니다.");
        }
    }
}
