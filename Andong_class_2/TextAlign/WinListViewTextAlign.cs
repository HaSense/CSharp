using System;
using System.Collections.Generic;
using System.ComponentModel;
/* 폼에 Listview 하나를 던져주세요.
   ListView의 List 뷰에서는 문자열 보간을 사용하여 각 항목을 정렬할 수 없다고 합니다.
   List 뷰는 각 항목을 세로로 나열하며, 문자열 내의 공백이나 정렬은 무시 된다고 합니다. 
   따라서  문자열의 폭이 조정되지 않고, 정렬도 적용되지 않을 것입니다.
   
   View.Details 속성을 이용하여 컬럼을 만든 다음 정렬하여 사용하세요.
*/

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextAlign003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ListView의 View 속성을 Details로 설정
            listView1.View = View.Details;

            // 컬럼 헤더를 추가
            listView1.Columns.Add("번호", 50);
            listView1.Columns.Add("내용", 100);
            listView1.Columns.Add("점수", 50);

            // 리스트뷰에 행을 추가
            listView1.Items.Add(new ListViewItem(new[] { "10", "Good Arhentina", "40" }));
            listView1.Items.Add(new ListViewItem(new[] { "20", "USA Fighting", "40" }));
            listView1.Items.Add(new ListViewItem(new[] { "30", "Korea Fighting", "40" }));

        }
    }
}
