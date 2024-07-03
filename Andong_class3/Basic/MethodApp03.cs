namespace MethodApp03
{
    class Sensor
    {
        //멤버변수
        //생성자
        //멤버메소드
         //데이터 읽어오기
        public void ReadData()
        {
            Console.WriteLine("데이터를 읽다.");
        }
        public void ReadData(byte[] data)
        {
            Console.WriteLine($"{data[0]}{data[1]}{data[2]} 데이터를 읽다.");
        }
        //설정값 조정하기
        public void Calibrate()
        {
            Console.WriteLine("설정값을 조정하다.");
        }
         //경고메시지 보내기
        public void SendAlert()
        {
            Console.WriteLine("경고 보내기");
        }
        public void SendAlert(string message)
        {
            Console.WriteLine($"{message} 경고 보내기");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Sensor sensor = new Sensor();
            sensor.ReadData();
            byte[] arr = { 0x001, 0x002, 0x003 };
            sensor.ReadData(arr);
            sensor.Calibrate();
            sensor.SendAlert();
            sensor.SendAlert("온도초과");
        }
    }
}
