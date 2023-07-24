using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stream stream1 = new FileStream("a.dat", FileMode.Create);
            Stream stream2 = new FileStream("b.dat", FileMode.Open);
            Stream stream3 = new FileStream("c.dat", FileMode.OpenOrCreate);

            Stream stream4 = new FileStream("d.dat", FileMode.Truncate); //파일을 비워서 열기
            Stream stream5 = new FileStream("e.dat", FileMode.Append);  //덧붙이기 모드로 열기

            long someValue = 0x123456789ABCDEF0;

            //1.파일 스트림 생성
            Stream outStream = new FileStream("f.dat", FileMode.Create);
            //2.someValue(long 형식)을 byte 배열로 변환
            byte[] wBytes = BitConverter.GetBytes(someValue);
            //3.변환할 byte 배열을 파일 스트림을 통해 파일에 기록
            outStream.Write(wBytes, 0, wBytes.Length);
            //4.파일 스트림 닫기
            outStream.Close();


            //1.파일 스트림 생성
            using (Stream outStream2 = new FileStream("g.dat", FileMode.Create))
            {
                //2.someValue(long 형식)을 byte 배열로 변환
                byte[] wBytes2 = BitConverter.GetBytes(someValue);
                //3.변활할 byte 배열을 파일 스트림을 통해 파일에 기록
                outStream2.Write(wBytes2, 0, wBytes2.Length);
            }

        }
        
    }
}
