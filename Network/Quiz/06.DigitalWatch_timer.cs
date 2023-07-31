using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DigitalWatch
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private TimeSpan time;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = TimeSpan.Zero;
            timer.Interval = 1000;
            timer.Tick += TimerTick;
        }
        private void TimerTick(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToString("mm:ss"); //이렇게 찍으면 현재시간 출력.
            time = time.Add(TimeSpan.FromSeconds(1));
            label1.Text = time.ToString("mm' : 'ss");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
