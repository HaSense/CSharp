using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsTest
{
    class Book
    {
        decimal _isbn;

        public Book(decimal isbn)
        {
            _isbn = isbn;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(12345);
            Book book2 = new Book(12345);

            char[] ch = { 'A', 'B', 'C', 'D' };
            string str1 = "ABCD";
            string str2 = "ABCD";
            string str3 = new string(ch);
            string str4 = new string(ch);

            Console.WriteLine(book1.Equals(book2)); //False
            Console.WriteLine($"book1 Hashcode : {book1.GetHashCode()}");
            Console.WriteLine($"book2 Hashcode : {book2.GetHashCode()}");

            Console.WriteLine(str1.Equals(str2));
            Console.WriteLine($"str1 Hashcode : {str1.GetHashCode()}");
            Console.WriteLine($"str2 Hashcode : {str2.GetHashCode()}");


            Console.WriteLine(str3.Equals(str4));
            Console.WriteLine($"str3 Hashcode : {str3.GetHashCode()}");
            Console.WriteLine($"str4 Hashcode : {str4.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine(str1 == str2);
            Console.WriteLine(str3 == str4);  
        }
    }
}
