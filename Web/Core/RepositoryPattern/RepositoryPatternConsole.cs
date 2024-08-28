namespace RepositoryPatternConsole
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HP { get; set; }
    }
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> students = new List<Student>();

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Update(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.HP = student.HP;
            }
        }

        public void Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Student> studentRepository = new StudentRepository();

            // 학생 추가
            studentRepository.Add(new Student { Id = 1, Name = "홍길동", HP = "010-1111-1111" });
            studentRepository.Add(new Student { Id = 2, Name = "이순신", HP = "010-2222-2222" });
            studentRepository.Add(new Student { Id = 2, Name = "강감찬", HP = "010-3333-3333" });

            // 모든 학생 정보 출력
            Console.WriteLine("모든 학생 정보:");
            foreach (var student in studentRepository.GetAll())
            {
                Console.WriteLine($"ID: {student.Id}, 이름: {student.Name}, 연락처: {student.HP}");
            }

            // 특정 학생 정보 조회
            var studentById = studentRepository.GetById(1);
            Console.WriteLine($"\nID가 1인 학생: 이름: {studentById.Name}, 연락처: {studentById.HP}");

            // 학생 정보 업데이트
            studentRepository.Update(new Student { Id = 1, Name = "홍길동 업데이트", HP = "010-9999-9999" });

            // 업데이트된 학생 정보 조회
            studentById = studentRepository.GetById(1);
            Console.WriteLine($"\n업데이트된 ID가 1인 학생: 이름: {studentById.Name}, 연락처: {studentById.HP}");

            // 학생 삭제
            studentRepository.Delete(2);

            // 삭제 후 모든 학생 정보 출력
            Console.WriteLine("\n삭제 후 모든 학생 정보:");
            foreach (var student in studentRepository.GetAll())
            {
                Console.WriteLine($"ID: {student.Id}, 이름: {student.Name}, 연락처: {student.HP}");
            }
        }
    }
}
