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
    
    public partial class Form2 : Form
    {
        Form1 frm1;     // HAS-A ((포함))
        public Form2() //디폴트 생성자
        {
            InitializeComponent();
        }
        //Form1에 접근하려면 Form1 속성 중 Modifiers를 private --> public으로 수정해 줘야 한다.
        
        public Form2(object form)       //생성자를 하나 더 만듦
        {
            InitializeComponent();

            frm1 = (Form1)form;
        }
        public Form2(string str, Form1 form1)
        {
            this.frm1 = form1;
            str = "Hello";
        }

        private void btnChangeMainLabel_Click(object sender, EventArgs e)
        {
            frm1.lblForm1.Text = "Form2에서 변경을 시켰습니다.";
            
        }
    }
}
