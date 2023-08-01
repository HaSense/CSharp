using System;

namespace UserEvent02
{
    public delegate void FestivalStartedEventHandler(object sender, EventArgs e);

    public class Festival
    {
        public event FestivalStartedEventHandler FestivalStarted;

        public void StartFestival()
        {
            FestivalStarted?.Invoke(this, EventArgs.Empty);
        }

        public void Announce(object sender, EventArgs e)
        {
            Console.WriteLine("축제가 시작되었습니다!");
        }

        public void PlayMusic(object sender, EventArgs e)
        {
            Console.WriteLine("음악을 연주합니다!");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Festival festival = new Festival();

            festival.FestivalStarted += festival.Announce;
            festival.FestivalStarted += festival.PlayMusic;

            festival.StartFestival();  // Outputs: "축제가 시작되었습니다!" and "음악을 연주합니다!"
        }
    }
}

