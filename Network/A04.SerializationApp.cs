using System.Text.Json;

namespace SerializationApp
{
    class NameCard
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileName = "a.json";
            using (Stream ws = new FileStream(fileName, FileMode.Create))
            {
                NameCard nc = new NameCard();
                nc.Name = "홍길동";
                nc.Phone = "010-1111-1111";
                nc.Age = 20;

                string jsonString = JsonSerializer.Serialize<NameCard>(nc); //직렬화
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
                ws.Write(jsonBytes, 0, jsonBytes.Length);
            }

            using (Stream rs = new FileStream(fileName, FileMode.Open))
            {
                byte[] jsonBytes = new byte[rs.Length];
                rs.Read(jsonBytes, 0, jsonBytes.Length);
                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes);

                NameCard nc2 = JsonSerializer.Deserialize<NameCard>(jsonString);

                Console.WriteLine(nc2.Name);
                Console.WriteLine(nc2.Phone);
                Console.WriteLine(nc2.Age);

            }
                
            


        }
    }
}
