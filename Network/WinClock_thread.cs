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

namespace WinClock_Thread
{
    public partial class Form1 : Form
    {
        private Thread thread; 
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
            object obj = DateTime.Now.ToString();
            Thread t = new Thread(new ParameterizedThreadStart(threadTime));
            t.IsBackground = true;
            t.Start(obj);

            int cnt = 0;
            thread = t;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
           
            thread.Abort();
                      
        }
                
        void threadTime(object now)
        {
            //호출한 스레드가 작업스레드인가 ?
            int cnt = 0;
            while (true)
            {
                if (label1.InvokeRequired) //작업스레드 인가??
                {
                    label1.BeginInvoke(new Action(()
                        => label1.Text = DateTime.Now.ToString()));
                }
                else //UI스레드 인가??
                    label1.Text = DateTime.Now.ToString();
                Thread.Sleep(500);

                if (cnt++ == 20) break;
            }
        }
    }
}
