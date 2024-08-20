using System.Net.Sockets;
using System.Net;
using System.Text;

namespace QuizSocketServer
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread serverThread = new Thread(ServerAction);
            serverThread.IsBackground = true;
            serverThread.Start();

            serverThread.Join();
            Console.WriteLine("서버 메인프로그램 종료!!!");
        }
        private static void ServerAction(object obj)
        {
            using (Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 13000);
                srvSocket.Bind(endPoint);
                srvSocket.Listen(30);

                Console.WriteLine("퀴즈 서버 시작...");

                while (true)
                {
                    Socket cliSocket = srvSocket.Accept();
                    Thread workThread = new Thread(new ParameterizedThreadStart(WorkAction));
                    workThread.IsBackground = true;
                    workThread.Start(cliSocket);
                }
            }
        }

        private static void WorkAction(object obj)
        {
            Socket cliSocket = (Socket)obj;
            List<Quiz> quizList = new List<Quiz>
            {
                new Quiz("C#의 창시자는?", new string[] { "1. Anders Hejlsberg", "2. James Gosling", "3. Bjarne Stroustrup" }, "1"),
                new Quiz("HTTP의 기본 포트 번호는?", new string[] { "1. 21", "2. 80", "3. 443" }, "2"),
                new Quiz("88올림픽 개최 연도는?", new string[] { "1. 2024", "2. 2000", "3. 1988" }, "3")
            };

            int currentQuestion = 0;

            while (currentQuestion < quizList.Count)
            {
                Quiz quiz = quizList[currentQuestion];

                string message = $"문제 {currentQuestion + 1}: {quiz.Question}\n" +
                         $"{quiz.Options[0]}\n{quiz.Options[1]}\n{quiz.Options[2]}\n정답을 입력하세요 (1, 2, 3):";

                SendMessage(cliSocket, message);

                byte[] recvBytes = new byte[1024];
                int nRecv = cliSocket.Receive(recvBytes);
                string clientResponse = Encoding.UTF8.GetString(recvBytes, 0, nRecv).Trim();

                if (clientResponse == quiz.CorrectAnswer)
                {
                    SendMessage(cliSocket, "정답입니다!");
                    currentQuestion++;
                }
                else
                {
                    SendMessage(cliSocket, "오답입니다. 다음 기회에 도전하세요.");
                    break;
                }
            }

            if (currentQuestion == quizList.Count)
            {
                SendMessage(cliSocket, "축하합니다! 모든 문제를 맞추셨습니다. 우승하셨습니다!");
            }

            cliSocket.Close();
        }

        private static void SendMessage(Socket socket, string message)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(message + "\n");
            socket.Send(sendBytes);
        }
    }

    //Quiz를 List로 만들어 제어하기 위해 만든 Quiz 클래스
    public class Quiz 
    {
        public string Question { get; set; }    // 퀴즈문제
        public string[] Options { get; set; }   // 객관식 내용
        public string CorrectAnswer { get; set; } // 정답

        public Quiz(string question, string[] options, string correctAnswer)
        {
            Question = question;
            Options = options;
            CorrectAnswer = correctAnswer;
        }
    }
}
