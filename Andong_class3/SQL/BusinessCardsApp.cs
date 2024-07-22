using Oracle.ManagedDataAccess.Client;
using System.Net;
using System.Xml.Linq;

namespace BusinessCardsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int choice = 0;
            DBUtils dbUtils = new DBUtils();
            do
            {
                Console.WriteLine("============================");
                Console.WriteLine("명함 관리 시스템");
                Console.WriteLine("============================");
                Console.WriteLine("0. 테이블 초기화(삭제 후 만들기)");
                Console.WriteLine("1. 명함 추가");
                Console.WriteLine("2. 명함 목록 보기");
                Console.WriteLine("3. 명함 수정");
                Console.WriteLine("4. 명함 삭제");
                Console.WriteLine("5. 명함 검색");
                Console.WriteLine("6. 종료");
                Console.WriteLine("============================");
                Console.Write("선택:");

                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();


                switch (choice)
                {
                    case 0:
                        dbUtils.InitializeTables();
                        break;
                    case 1:
                        //입력받기
                        Console.WriteLine("명함 추가");
                        Console.Write("이름: ");
                        string name = Console.ReadLine();
                        Console.Write("전화번호: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("이메일: ");
                        string email = Console.ReadLine();
                        Console.Write("회사: ");
                        string company = Console.ReadLine();
                        Console.Write("주소: ");
                        string address = Console.ReadLine();

                        dbUtils.InsertData(name, phoneNumber, email, company, address);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("명함 검색");
                        Console.Write("검색할 이름을 입력하세요: ");
                        string searchName = Console.ReadLine();
                        dbUtils.SearchBusinessCard(searchName);
                        break;
                    case 6:
                        Console.WriteLine("프로그램을 종료합니다.");
                        return;
                }

            } while (choice != 6);
        }//end of main
    }//end of Program

    class DBUtils
    {
        private string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";

        public void InitializeTables()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string dropTableQuery = @"
                BEGIN
                    EXECUTE IMMEDIATE 'DROP TABLE BusinessCards CASCADE CONSTRAINTS';
                EXCEPTION
                    WHEN OTHERS THEN
                        IF SQLCODE != -942 THEN
                            RAISE;
                        END IF;
                END;";

                    string dropSequenceQuery = @"
                BEGIN
                    EXECUTE IMMEDIATE 'DROP SEQUENCE SEQ_BUSINESSCARDS';
                EXCEPTION
                    WHEN OTHERS THEN
                        IF SQLCODE != -2289 THEN
                            RAISE;
                        END IF;
                END;";

                    string createTableQuery = @"
                CREATE TABLE BusinessCards (
                    CardID NUMBER PRIMARY KEY,
                    Name VARCHAR2(50) NOT NULL,
                    PhoneNumber VARCHAR2(20) NOT NULL,
                    Email VARCHAR2(50),
                    Company VARCHAR2(100),
                    Address VARCHAR2(200)
                )";

                    string createSequenceQuery = @"
                CREATE SEQUENCE SEQ_BUSINESSCARDS
                START WITH 1
                INCREMENT BY 1
                MAXVALUE 9999
                MINVALUE 0
                NOCYCLE
                NOCACHE";

                    using (OracleCommand command = new OracleCommand(dropTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (OracleCommand command = new OracleCommand(dropSequenceQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (OracleCommand command = new OracleCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (OracleCommand command = new OracleCommand(createSequenceQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("테이블과 시퀀스가 초기화되었습니다.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("오류 발생: " + ex.Message);
                }
            }
        }//end of initialize table
        public void InsertData(string name, string phoneNumber, string email, string company, string address)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = @"
                INSERT INTO BusinessCards (CardID, Name, PhoneNumber, Email, Company, Address)
                VALUES (SEQ_BUSINESSCARDS.NEXTVAL, :Name, :PhoneNumber, :Email, :Company, :Address)";

                    using (OracleCommand command = new OracleCommand(insertQuery, connection))
                    {
                        command.Parameters.Add(new OracleParameter("Name", name));
                        command.Parameters.Add(new OracleParameter("PhoneNumber", phoneNumber));
                        command.Parameters.Add(new OracleParameter("Email", email));
                        command.Parameters.Add(new OracleParameter("Company", company));
                        command.Parameters.Add(new OracleParameter("Address", address));

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("명함이 성공적으로 추가되었습니다.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("오류 발생: " + ex.Message);
                }
            }
        }//end of InsertData
        public void SearchBusinessCard(string name)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string searchQuery = @"
                SELECT * FROM BusinessCards
                WHERE Name LIKE :Name";

                    using (OracleCommand command = new OracleCommand(searchQuery, connection))
                    {
                        command.Parameters.Add(new OracleParameter("Name", "%" + name + "%"));

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["CardID"]}, 이름: {reader["Name"]}, 전화번호: {reader["PhoneNumber"]}, 이메일: {reader["Email"]}, 회사: {reader["Company"]}, 주소: {reader["Address"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("오류 발생: " + ex.Message);
                }
            }
        }//end of search
    }
}
