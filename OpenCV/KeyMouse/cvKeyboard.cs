using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvKeyboardTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Mat image = new Mat(200, 300, MatType.CV_8U, new Scalar(255)))
            {
                Cv2.NamedWindow("키보드 이벤트", WindowFlags.AutoSize);
                Cv2.ImShow("키보드 이벤트", image);

                while (true)
                {
                    int key = Cv2.WaitKeyEx(200);
                    
                    if (key == 27) // 'ESC' key
                        break;

                    switch (key)
                    {
                        case (int)'a':
                            Console.WriteLine("a키 입력");
                            break;
                        case (int)'b':
                            Console.WriteLine("b키 입력");
                            break;
                        case (int)'A':
                            Console.WriteLine("A키 입력");
                            break;
                        case (int)'B':
                            Console.WriteLine("B키 입력");
                            break;
                        case 2424832: // 왼쪽 화살표
                            Console.WriteLine("왼쪽 화살표 키 입력");
                            break;
                        case 2490368: // 위쪽 화살표
                            Console.WriteLine("위쪽 화살표 키 입력");
                            break;
                        case 2555904: // 오른쪽 화살표
                            Console.WriteLine("오른쪽 화살표 키 입력");
                            break;
                        case 2621440: // 아래쪽 화살표
                            Console.WriteLine("아래쪽 화살표 키 입력");
                            break;
                            //default:
                            //    Console.WriteLine(key);
                            //    break;
                    }
                }
            }
        }
    }
}
