using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTimer_Tick_Count
{
    public partial class Form1 : Form
    {
        int cnt = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(counting);
            timer1.Start();
        }
        private void counting(object sender, EventArgs e)
        {  
                
           label1.Text = (cnt++).ToString();
           
        }
    }
}
