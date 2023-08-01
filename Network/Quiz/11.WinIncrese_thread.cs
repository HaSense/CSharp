
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

namespace WinIncreseApp02
{
    public partial class Form1 : Form
    {
        private int cnt = 0;
        private Thread t;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            t = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Invoke((Action)(() => label1.Text = cnt++ + ""));
                        Thread.Sleep(1000);
                    }catch (Exception ex)
                    {
                        break; 
                    }
                    
                }
            });
            t.Start();
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.Interrupt();
        }
    }
}
