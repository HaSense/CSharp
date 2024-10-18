using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat m1 = new Mat(3, 5, MatType.CV_8UC1);
            byte[,] array = new byte[,]
            {
                { 21, 15, 10, 9, 14 },
                { 6, 10, 15, 9, 7 },
                { 7, 12, 8, 14, 1 }
            };
            // 배열 값을 Mat 객체에 할당
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    m1.Set(i, j, array[i, j]);
                }
            }

            Mat m_sort1 = new Mat();
            Mat m_sort2 = new Mat();
            Mat m_sort3 = new Mat();

            // 각 행을 기준으로 오름차순 정렬
            Cv2.Sort(m1, m_sort1, SortFlags.EveryRow);
            // 각 행을 기준으로 내림차순 정렬
            Cv2.Sort(m1, m_sort2, SortFlags.EveryRow | SortFlags.Descending);
            // 각 열을 기준으로 오름차순 정렬
            Cv2.Sort(m1, m_sort3, SortFlags.EveryColumn);

            // 원본 행렬 출력
            Console.WriteLine("[m1] = ");
            PrintMat(m1);

            // 정렬된 행렬 출력 (행 기준 오름차순)
            Console.WriteLine("\n[m_sort1] = ");
            PrintMat(m_sort1);

            // 정렬된 행렬 출력 (행 기준 내림차순)
            Console.WriteLine("\n[m_sort2] = ");
            PrintMat(m_sort2);

            // 정렬된 행렬 출력 (열 기준 오름차순)
            Console.WriteLine("\n[m_sort3] = ");
            PrintMat(m_sort3);
        }
        // 행렬을 출력하는 함수
        static void PrintMat(Mat mat)
        {
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Cols; j++)
                {
                    Console.Write($"{mat.At<byte>(i, j)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
