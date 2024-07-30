
using System.Text;

public partial class Program
{
    public static void Main()
    {
        string str1 = "Hello World";
        string str2 = new string("Hello World");
        string str3 = "Hello World";
        string str4 = "Hello World";
        string str5 = new string("Hello World");

        object obj1 = new object();
        object obj2 = new object();

        StringBuilder sb1 = new StringBuilder("Hello World");
        StringBuilder sb2 = new StringBuilder("Hello World");

        Console.WriteLine($"str1 : {str1.GetHashCode()}");
        Console.WriteLine($"str2 : {str2.GetHashCode()}");
        Console.WriteLine($"str3 : {str3.GetHashCode()}");
        Console.WriteLine($"str4 : {str4.GetHashCode()}");
        Console.WriteLine($"str4 : {str5.GetHashCode()}");
        Console.WriteLine();

        Console.WriteLine($"obj1 : {obj1.GetHashCode()}");
        Console.WriteLine($"obj2 : {obj2.GetHashCode()}");
        Console.WriteLine();

        Console.WriteLine($"sb1 : {sb1.GetHashCode()} {sb1.ToString()}");
        Console.WriteLine($"sb2 : {sb2.GetHashCode()} {sb2.ToString()}");
    }
}
