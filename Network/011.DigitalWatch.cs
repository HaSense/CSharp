using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalWatch02
{
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(threadTime);
            t.IsBackground = true;
            t.Start();

            this.thread = t;
        }
        

        private void btnStop_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }
        void threadTime(object now)
        {
            while (true)
            {
                if (label1.InvokeRequired) //지금 작업스레드입니까?
                {
                    label1.BeginInvoke(new Action(() => label1.Text = DateTime.Now.ToString()));
                }
                else //UI스레드 이다.
                {
                    label1.Text = DateTime.Now.ToString();
                }
                
                Thread.Sleep(1000);
            }
        }
    }
}
