
public partial class Program
{
    public static void Main()
    {
        int number = 42;
        Int32 boxed = number; //Boxing
        int unboxed = boxed; //UnBoxing

        object obj = number; //UpCasting, Boxing
        int downed = (int)obj; //강제형변환, DownCasting


    }
}
