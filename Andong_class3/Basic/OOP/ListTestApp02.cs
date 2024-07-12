namespace ListTestApp02
{
    class Album
    {
        //private int no;
        //private string title;
        //private string artist;
        public Album() { }

        public int No { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

    }
    class NewJeansAlbum : Album
    {
        public NewJeansAlbum() { }
        public NewJeansAlbum(int no, string title, string artist) 
        {
            No = no;
            Title = title;
            Artist = artist;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<NewJeansAlbum> albumList = new List<NewJeansAlbum>();
            NewJeansAlbum album = new NewJeansAlbum();
            album.No = 1;   // 나중일 --> 입력처리, DB가져오기..
            album.Title = "수퍼 내추럴";
            album.Artist = "뉴진스";
            albumList.Add(album);

            album = new NewJeansAlbum();
            album.No = 2;
            album.Title = "하우 스윗";
            album.Artist = "뉴진스";
            albumList.Add(album);

            album = new NewJeansAlbum(3, "Right Now", "뉴진스");
            albumList.Add(album) ;

            foreach(NewJeansAlbum na in albumList)
            {
                Console.WriteLine(na.No);
                Console.WriteLine(na.Title);
                Console.WriteLine(na.Artist);
                Console.WriteLine();    
            }


        }
    }
}
