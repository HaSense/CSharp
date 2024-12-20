using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMultiThreadTCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 인터넷 주소 설정
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            // 포트 설정
            int port = 13000;
            // 서버 생성
            TcpListener server = new TcpListener(localAddr, port);
            // 서버 시작
            server.Start();
            //Console.WriteLine("연결을 기다리는 중...");
            richTextBox1.AppendText("연결을 기다리는 중...\n");

            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    // 클라이언트 연결 수락
                    TcpClient client = server.AcceptTcpClient();
                    // 클라이언트 요청 처리 시작
                    Thread t2 = new Thread(() => HandleClient(client));
                    t2.Start();
                }
            });

            t1.Start();
        }
        private void HandleClient(TcpClient client)
        {
            //Console.WriteLine("연결 성공!");
            AppendText("연결 성공!\n");

            using (NetworkStream stream = client.GetStream())
            {
                byte[] data = new byte[256];
                int bytes;

                while ((bytes = stream.Read(data, 0, data.Length)) != 0)
                {
                    AppendText(Encoding.UTF8.GetString(data, 0, bytes) + "\n");
                }

                stream.Close();
            }
            client.Close();
        }

        private void AppendText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                richTextBox1.AppendText(text);
            }
        }
    }


}
