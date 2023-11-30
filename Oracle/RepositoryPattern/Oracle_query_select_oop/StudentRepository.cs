using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_query_select_oop
{
    //DB테이블에 해당하는 타입을 정의해야 합니다.
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hp { get; set; }
    }
    /*
     * Repository는 단순히 저장소라고만 번역해 사용하기엔 깊은 내용이 있습니다.
     * Repository 패턴의 핵심 아이디어는 애플리케이션과 데이터 저장소(DB) 사이의 중간계층을
     * 제공하는 것입니다. 
     * Repository는 단순히 데이터를 저장하고 검색한다는 개념도 맞지만 객체의 생명 주기를 
     * 관리하고 도메인 모델과 데이터 저장소 사이의 매핑을 처리하는게 핵심 역할입니다.
     */
    class StudentRepository
    {
        private DatabaseManager dbManager;

        public StudentRepository()
        {
            dbManager = new DatabaseManager();
        }

        //데이터 전수조사를 GetAll~~() 등의 이름으로 표현합니다.
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (OracleConnection conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand("SELECT * FROM student", conn);
                using (OracleDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        students.Add(new Student
                        {
                            Id = int.Parse(rdr["Id"].ToString()),
                            Name = rdr["Name"] as string,
                            Hp = rdr["Hp"] as string
                        });
                    }
                }
            }

            return students;
        }
    }
}
