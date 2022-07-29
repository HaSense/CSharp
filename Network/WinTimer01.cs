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

namespace WinTimer01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Timer1_Tick(this, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            label1.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;

            label1.Text = DateTime.Now.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            timer1.Enabled = false;
        }
    }
}
