using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridTest02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("DEPTNO", typeof(int));
            dataTable.Columns.Add("DNAME", typeof(string));
            dataTable.Columns.Add("LOCATION", typeof(string));

            dataTable.Rows.Add(10, "ACCOUNTING", "NEWYORK");
            dataTable.Rows.Add(20, "RESEARCH", "DALLAS");
            dataTable.Rows.Add(30, "SALES", "CHICAGO");
            dataTable.Rows.Add(40, "OPERATIONS", "BOSTON");

            dataGridView1.DataSource = dataTable;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
