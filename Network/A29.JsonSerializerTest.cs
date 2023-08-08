
/*
 * Author : Ha, Sungho
 * Date : 2022.08.08
 * Content : Nuget 패키지에 있는 마이크로소프트의 JsonSerializer를 이용한 직렬화/역직렬화
 *           1. 객체를 직렬화 후 파일로 저장
 *           2. 파일에서 읽어온 값을 역직렬화하여 객체부활
 * 
 */

using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace JsonSerializerTest
{
    class FileManager
    {
        public void FileSerialize()
        {
            SerialData serialData = new SerialData();
            serialData.Args1 = 100;
            serialData.Args2 = 200;
            serialData.Args3 = "mydata";

            string jsonString = JsonSerializer.Serialize(serialData);
            File.WriteAllText("./serialData.dat", jsonString);
            Console.WriteLine("파일을 저장하였습니다.");
        }
        public void FileDeserialize()
        {
            try
            {
                string path = "./serialData.dat";
                using (FileStream fs = File.Open(path, FileMode.Open))
                {
                    //역직렬화
                    SerialData myData = JsonSerializer.Deserialize<SerialData>(fs);
                    Console.WriteLine($"arg1: {myData.Args1} arg2: {myData.Args2} arg3: {myData.Args3}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message + "역 직렬화를 위한 파일이 현재 디렉토리에 없어 읽어올 수 없습니다.");
            }

        }
    }
    class SerialData
    {
        public int Args1 { get; set; }
        public int Args2 { get; set; }
        public string Args3 { get; set; }
    }
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            FileManager fm = new FileManager();
            fm.FileSerialize(); //객체를 파일로 직렬화
            Thread.Sleep(10);
            fm.FileDeserialize(); //파일에서 다시 객체 꺼내기/ 역직렬화
        }
    }
}
