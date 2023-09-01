using Microsoft.EntityFrameworkCore;
using NAudio.Wave;
namespace Mp3SqlServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusicDbContext())
            {
                context.Database.EnsureCreated();
            }

            Console.WriteLine("1. ETA.mp3 파일을 데이터베이스에 저장");
            Console.WriteLine("2. 데이터베이스의 ETA.mp3 파일 재생");
            Console.Write("옵션을 선택하세요: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SaveMP3ToDatabase("ETA.mp3");
                    break;
                case "2":
                    PlayMP3FromDatabase();
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }

        private static void SaveMP3ToDatabase(string filePath)
        {
            byte[] mp3Data = File.ReadAllBytes(filePath);

            using (var context = new MusicDbContext())
            {
                var mp3File = new MP3File { FileName = Path.GetFileName(filePath), Data = mp3Data };
                context.MP3Files.Add(mp3File);
                context.SaveChanges();
            }

            Console.WriteLine("MP3 파일이 데이터베이스에 저장되었습니다.");
        }

        private static void PlayMP3FromDatabase()
        {
            byte[] mp3Data;

            using (var context = new MusicDbContext())
            {
                mp3Data = context.MP3Files.FirstOrDefault(m => m.FileName == "ETA.mp3")?.Data;
            }

            if (mp3Data == null)
            {
                Console.WriteLine("데이터베이스에서 MP3 파일을 찾을 수 없습니다.");
                return;
            }

            var tempPath = Path.GetTempFileName() + ".mp3";
            File.WriteAllBytes(tempPath, mp3Data);

            using (var audioFile = new AudioFileReader(tempPath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                Console.WriteLine("재생 중... 중지하려면 아무 키나 누르세요.");
                Console.ReadKey();
                outputDevice.Stop();
            }

            File.Delete(tempPath);
        }
    }

    public class MP3File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }

    public class MusicDbContext : DbContext
    {
        private const string Conn = "Server=(local)\\SQLEXPRESS;Database=SmartFactory;Trusted_Connection=True";
        public DbSet<MP3File> MP3Files { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Conn);
        }
    }
}
