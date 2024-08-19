using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread_Console_Server_v1
{
    internal class Program
    {
        static int cnt = 0;
        static void Main(string[] args)
        {
            /*
             * [Multi Thread Console Server]
             * 현 코드는 교육을 위한 소스코드라 메인 스레드를 이용해 만들어도 괜찮으나
             * GUI프로그램으로 만들경우 메인 스레드는 UI를 담당하고 네트워크 업무는
             * 작업 스레드로 동작하는 경우가 많아 콘솔임에도 서버동작의 시작수행을
             * 스레드로 만들어 시작합니다.
             */
            Thread serverThread = new Thread(serverFunc); 
            serverThread.IsBackground = true;
            serverThread.Start();

            serverThread.Join();
            Console.WriteLine("서버 메인프로그램 종료!!!");
        }

        private static void serverFunc(object obj)
        {
            /*
             * C#의 경우 간단한 소켓프로그램을 하도록 TCPListener와 TcpClient 클래스가 존재합니다.
             * Socket 클래스의 경우는 Berkely Socket의 다양한 옵션을 사용해 볼 수 있도록 만든
             * 저수준 클래스로 TCPListener, TcpClient, UdpClient 클래스 역시 Socket클래스를 이용해
             * 작성되었으며 Socket 클래스를 사용하면 IPX, Netbios, AppleTalk 등 다양한 프로토콜 및
             * 네트워크 통신을 프로그래밍 할 수 있습니다.
             * 
             * 
             * try ~ catch 대신 using을 사용하면 좋은 이유는 using문을 사용하면 IDisposable 객체를
             * 구현받고 있으므로 finally로 해당 자원을 일일이 Dispose하지 않아도 예외 상황 시 
             * 자원이 처분(Dispose)됨을 보장합니다.
             */

            using(Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 13000);

                srvSocket.Bind(endPoint);
                srvSocket.Listen(50);

                Console.WriteLine("서버 시작...");
                while(true)
                {
                    Socket cliSocket = srvSocket.Accept(); //여기까지 동작은 공통입니다.
                    cnt++; //클라이언트를 구분하기 위한 카운트 증가

                    //Read,Write 기능은 따로 스레드를 만들어 
                    Thread workThread = new Thread(new ParameterizedThreadStart(workFunc));
                    workThread.IsBackground = true;
                    workThread.Start(cliSocket);
                }
            }
        }//end of servFunc
        private static void workFunc(object obj)
        {
            byte[] recvBytes = new byte[1024];
            Socket cliSocket = (Socket)obj;
            int nRecv = cliSocket.Receive(recvBytes);

            string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);
            Console.WriteLine($"클라이언트 번호 ({cnt}) : {txt}");
            byte[] sendBytes = Encoding.UTF8.GetBytes("Hello : " + txt);
            cliSocket.Send(sendBytes);
            cliSocket.Close();
        }
    }
}
