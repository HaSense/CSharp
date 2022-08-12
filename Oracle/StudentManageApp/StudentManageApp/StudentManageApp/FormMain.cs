using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManageApp
{
    public partial class FormMain : Form
    {
        private List<Student> studentList;

        private int currentIndex = -1; // dataGridView_CellClick을 재사용하기 위해서 필드로 선언
        public FormMain()
        {
            InitializeComponent();
            studentList = new List<Student>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadDBData();
            DisplayData();

            sslCount.Text = "등록수" + studentList.Count.ToString();

            if (studentList.Count > 0)
            {
                ShowRecord(0); //첫번째 데이터를 표시
            }
        }
        private void ReadDBData()
        {
            string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";
            // 오라클 연결
            OracleConnection conn = new OracleConnection(strConn);
            conn.Open();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            // SQL문 지정 및 INSERT 실행
            cmd.CommandText = "SELECT * FROM STUDENT_BY_COURSE";
            //cmd.ExecuteNonQuery();
            // 결과 리더 객체를 리턴
            OracleDataReader rdr = cmd.ExecuteReader();
            // 레코드 계속 가져와서 루핑
            while (rdr.Read())
            {
                // 필드 데이타 읽기
                Student student = new Student();

                student.ID = rdr.GetInt32(0);
                student.Name = rdr["이름"] as string;
                student.Age = rdr.GetInt32(2);
                student.Class = rdr["과정명"] as string;
                student.School = rdr["대학교"] as string;
                student.Major = rdr["전공"] as string;
                student.Email = rdr["이메일"] as string;
                student.HP = rdr["전화번호"] as string;
                student.Feature = rdr["특징"] as string;
                student.Counsel = rdr["상담"] as string;

                studentList.Add(student);
            }
            // 사용후 닫음
            conn.Close();

        }
        private void DisplayData()
        {
            //Linq from절을 활용하여 studentList에서 조건에 맞는 요소만 뽑아옴
            //아래 코드는 where절을 사용하지 않아 전체를 가져온다.
            //Linq를 사용하지 않으면 foreach를 사용한것과 같다.
            var data = (from i in studentList select i).ToList(); 
            
            dataGridView1.DataSource = data;
        }
        private void ShowRecord(int index)
        {
            tbID.Text = (index + 1).ToString();
            tbName.Text = studentList[index].Name;
            tbAge.Text = studentList[index].Age + ""; //문자열 + 정수 --> 문자열
            tbClass.Text = studentList[index].Class;
            tbSchool.Text = studentList[index].School;
            tbMajor.Text = studentList[index].Major;
            tbEmail.Text = studentList[index].Email;
            tbHP.Text = studentList[index].HP;
            tbFeature.Text = studentList[index].Feature;
            tbCounsel.Text = studentList[index].Counsel;   
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FormInsert frmInsert = new FormInsert();
            frmInsert.ShowDialog(); //모달, 모달리스 구분
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //현재 선택된 인덱스 + 1을 번호 출력
            //순서1
            //this.txtNum.Text = (e.RowIndex + 1).ToString();//필드 사용전

            currentIndex = e.RowIndex; //현재 인덱스를 필드에 보관
            //202,203 검색관련해서 추가
            DataGridViewCell dgvc = dataGridView1.Rows[e.RowIndex].Cells[0];
            currentIndex = Convert.ToInt32(dgvc.Value.ToString()) - 1;

            if (currentIndex != -1)//순서4
            {
                //현재 DataGridView 인덱스로 출력 
                //매번 재 사용하기 위해서 메서드 추출했다.
                ShowRecord(currentIndex);
            }
        }
    }
}
