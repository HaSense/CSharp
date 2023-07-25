using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializationApp02
{
    class Student
    {
        public int STID { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileName = "a.json";
            using (Stream ws = new FileStream(fileName, FileMode.Create))
            {
                Student st = new Student();
                st.STID = 1;
                st.Name = "이순신";
                st.Major = "스마트팩토리";

                string jsonString = JsonSerializer.Serialize<Student>(st); //직렬화
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
                ws.Write(jsonBytes, 0, jsonBytes.Length);
            }

            using (Stream rs = new FileStream(fileName, FileMode.Open))
            {
                byte[] jsonBytes = new byte[rs.Length];
                rs.Read(jsonBytes, 0, jsonBytes.Length);
                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);

                Student st2 = JsonSerializer.Deserialize<Student>(jsonString);

                Console.WriteLine(st2.STID);
                Console.WriteLine(st2.Name);
                Console.WriteLine(st2.Major);

            }
        }
    }
}
