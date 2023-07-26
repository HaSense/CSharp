using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCopyApp
{
    public partial class Form1 : Form
    {
        private string sourceFile, destFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSrcFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sourceFile = openFileDialog.FileName;
                    label1.Text = sourceFile;
                }
            }
            
        }

        private void btnDstFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    destFile = saveFileDialog.FileName;
                    File.Copy(sourceFile, destFile, true);  // true는 대상 파일이 이미 있을 경우 덮어쓰기를 의미
                    label2.Text = "파일 복사 완료: " + destFile;
                }
            }
        }
    }
}
