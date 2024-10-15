using OpenCvSharp;

namespace Mat_Attr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat m1 = new Mat(4, 3, MatType.CV_32FC3, new Scalar(0, 0, 0));

            Console.WriteLine($"m1 : \n{m1.Dump()}");
            Console.WriteLine($"차원 수 : {m1.Dims}");
            Console.WriteLine($"행 개수 : {m1.Rows}");
            Console.WriteLine($"열 개수 : {m1.Cols}");
            Console.WriteLine($"행열 크기 : {m1.Size()}");

            Console.WriteLine($"전체 원소 개수 : {m1.Total()}");
            Console.WriteLine($"한 원소의 크기 : {m1.ElemSize()}");
            Console.WriteLine($"채널당 한 원소의 크기 : {m1.ElemSize1()}");

            Console.WriteLine($"타입 : {m1.Type()}");
            Console.WriteLine($"타입(채널 수 | 깊이) : {m1.Channels()} | {m1.Depth()}");

        }
    }
}
