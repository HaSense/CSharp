using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_query_select_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //DB객체가 담겨있는 저장소를 불러오고
            StudentRepository repository = new StudentRepository();
            //저장소에서 원하는 데이터 모두 잡아올린 다음 List객체로 전달
            List<Student> students = repository.GetAllStudents();

            //순차적으로 화면에 뿌림!!
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} : {student.Name} : {student.Hp}");
            }
        }
    }
}
