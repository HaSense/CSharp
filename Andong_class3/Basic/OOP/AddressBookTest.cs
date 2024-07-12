namespace MyAddressBook
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hp { get; set; }
        
        public Person(int id, string name, string hp)
        {
            Id = id;
            Name = name;
            Hp = hp;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> addressbook = new List<Person>(); //리스트 만들기

            //do ~ while 메뉴 do{
            int choice = 0;
            do
            {
                Console.WriteLine("1. 데이터 삽입");
                Console.WriteLine("2. 데이터 삭제");
                Console.WriteLine("3. 데이터 수정");
                Console.WriteLine("4. 데이터 검색");
                Console.WriteLine("5. 프로그램 종료");
                Console.WriteLine();
                Console.Write("메뉴 : ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("삽입");
                        /////////////////////////////////////
                        ///삽입 기능 넣기
                        Console.Write("ID 번호를 입력하세요 : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("이름을 입력하세요 : ");
                        string name = Console.ReadLine();
                        Console.Write("전화번호를 입력하세요 : ");
                        string hp = Console.ReadLine();
                        Person person = new Person(id, name, hp);
                        addressbook.Add(person);

                        ///////////////////////////////////////
                        break;
                    case 2:
                        Console.WriteLine("삭제");
                        Console.Write("삭제할 데이터의 ID를 입력해 주세요.");
                        int deleteId = int.Parse(Console.ReadLine());

                        for(int i=0; i < addressbook.Count; i++)
                        {
                            if (addressbook[i].Id == deleteId)
                            {
                                addressbook.RemoveAt(i);
                                
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("수정");
                        Console.Write("수정할 데이터의 ID를 입력해 주세요.");
                        int updateId = int.Parse(Console.ReadLine());

                        for (int i = 0; i < addressbook.Count; i++)
                        {
                            if (addressbook[i].Id == updateId)
                            {
                                //해당 위치의 i의 데이터 수정
                                Console.Write("수정 ID 번호를 입력하세요 : ");
                                addressbook[i].Id = int.Parse(Console.ReadLine());
                                Console.Write("수정 이름을 입력하세요 : ");
                                addressbook[i].Name = Console.ReadLine();
                                Console.Write("수정 전화번호를 입력하세요 : ");
                                addressbook[i].Hp = Console.ReadLine();

                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("검색");
                        foreach (Person p in addressbook)
                        {
                            Console.WriteLine($"ADDR_ID : {p.Id}");
                            Console.WriteLine($"이름 : {p.Name}");
                            Console.WriteLine($"전화번호 : {p.Hp}");
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        Console.WriteLine("종료");
                        break;
                    default:
                        Console.WriteLine("다시 시작 해 주세요.");
                        break;
                }
            } while (choice != 5);

        }
    }
}
