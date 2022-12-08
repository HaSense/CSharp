using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAccessTest
{
    public partial class Form1 : Form       // IS - A
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this);
            
            frm2.ShowDialog(); //모달 
            //Show() 모달리스
        }
    }
}
