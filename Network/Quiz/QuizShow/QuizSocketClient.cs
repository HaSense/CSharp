using System.Net.Sockets;
using System.Text;

namespace QuizSocketClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    clientSocket.Connect("127.0.0.1", 13000);

                    byte[] buffer = new byte[1024];
                    int received; //받은 바이트

                    while (true)
                    {
                        received = clientSocket.Receive(buffer);
                        string serverMessage = Encoding.UTF8.GetString(buffer, 0, received);
                        Console.WriteLine(serverMessage);

                        if (serverMessage.Contains("정답을 입력하세요"))
                        {
                            string userInput = Console.ReadLine();
                            byte[] data = Encoding.UTF8.GetBytes(userInput);
                            clientSocket.Send(data);
                        }
                        else if (serverMessage.Contains("우승하셨습니다") || serverMessage.Contains("오답입니다"))
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            
        }
    }
}
