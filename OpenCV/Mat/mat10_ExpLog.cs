using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp_log
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<float> v1 = new List<float> { 1, 2, 3 };
            List<float> v_exp = new List<float>();
            List<float> v_log = new List<float>();


            //Mat m1 = new Mat(1, 5, MatType.CV_32F, new float[] { 1, 2, 3, 5, 10 });
            Mat m1 = new Mat(1, 5, MatType.CV_32F);
            float[] data = { 1.0f, 2.0f, 3.0f, 5.0f, 10.0f };
            for (int i = 0; i < data.Length; i++)
            {
                m1.Set<float>(0, i, data[i]);
            }

            Mat m_exp = new Mat();
            Mat m_sqrt = new Mat();
            Mat m_pow = new Mat();

            // 벡터에 대한 exp 연산
            v_exp = v1.ConvertAll(x => (float)Math.Exp(x));

            // 행렬에 대한 exp 연산
            Cv2.Exp(m1, m_exp);

            // 행렬에 대한 log 연산 (출력은 리스트)
            for (int i = 0; i < m1.Cols; i++)
            {
                float val = m1.At<float>(0, i);
                v_log.Add((float)Math.Log(val));
            }

            // sqrt, pow 연산
            Cv2.Sqrt(m1, m_sqrt);
            Cv2.Pow(m1, 3, m_pow);

            // 출력
            Console.WriteLine("[m1] = \n" + m1.Dump() + "\n");
            Console.WriteLine("[v_exp] = " + String.Join(", ", v_exp));
            Console.WriteLine("[m_exp] = \n" + m_exp.Dump());
            Console.WriteLine("[v_log] = " + String.Join(", ", v_log) + "\n");
            Console.WriteLine("[m_sqrt] = \n" + m_sqrt.Dump());
            Console.WriteLine("[m_pow] = \n" + m_pow.Dump());
        }
    }
}
