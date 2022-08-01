using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FileReaderWriter_Binary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Temp\\pic1.png";
            byte[] picture;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                picture = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            }
            path = "C:\\Temp\\pic2.png";
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(picture);
                bw.Flush(); //이진파일 Flush() 신경
                bw.Close();
                fs.Close();
            }
        }
    }
}
