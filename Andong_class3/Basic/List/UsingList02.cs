namespace ListObject01
{
    class Student
    {
        public String Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Quiz 리스트와 배열을 다음 주문에 따라 구현해 주세요.
          
            //1.리스트 studentList를 만드세요.       
            List<Student> studentList = new List<Student>();
            //2.학생 3명을 만들어서 리스트에 넣으세요.
            Student st1 = new Student();
            Student st2 = new Student();
            Student st3 = new Student();
            //3.학생은 "이순신", "강감찬", "을지문덕"
            st1.Name = "이순신";
            st2.Name = "강감찬";
            st3.Name = "을지문덕";
            //4.리스트에 학생을 담습니다.
            studentList.Add(st1);
            studentList.Add(st2);
            studentList.Add(st3);
            //5.출력은 이름만 출력하고 순환문은 foreach를 사용해 주세요.
            foreach (Student student in studentList)
            {
                Console.WriteLine(student.Name);    
            }
        }
    }
}
