using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingAppExam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1.파일 스트림 생성
            using (Stream outStream = new FileStream("a.dat", FileMode.Create))
            {
                long someValue = 0x123456789ABCDEF0;
                //2.someValue(long 형식)을 byte 배열로 변환
                byte[] someBytes =  BitConverter.GetBytes(someValue);
                //3.변환할 byte 배열을 파일 스트림을 통해 파일에 기록
                outStream.Write(someBytes, 0, someBytes.Length);
            }
            //2.파일 스트림 읽기
            using (Stream inStream = new FileStream("a.dat", FileMode.Open))
            {
                byte[] rbytes = new byte[8];    //읽어올 메모리크기 만큼생성

                int i = 0; //파일을 읽을 위치
                while(inStream.Position < inStream.Length) //데이터 크기만큼 
                {
                    rbytes[i++] = (byte)inStream.ReadByte(); //1byte씩 처리
                }

                long readValue = BitConverter.ToInt64(rbytes, 0); //변수 자료형으로 변환

                Console.WriteLine($"{readValue:X16}"); //16진수로 출력
            }


        }
    }
}
