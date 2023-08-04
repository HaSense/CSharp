using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinTcpClient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string serverIp = "127.0.0.1";
            int port = 13000;

            client = new TcpClient(serverIp, port);
            stream = client.GetStream();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.UTF8.GetBytes(textBox1.Text);
            stream.Write(data, 0, data.Length);    
        }
    }
}
