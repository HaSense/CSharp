using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_exam1
{
    //객체, 정우성:186, 김태희:158, ...
    class Profile
    {
        private string name;
        private int height;
        public string Name { get; set; }
        public int Height { get; set; }

        //생성자
        public Profile(){ }
        public Profile(string name, int height)
        {
            Name = name;
            Height = height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                //p.514
                new Profile(){Name="정우성", Height=186 },
                new Profile(){Name="김태희", Height=158 },
                //new Profile(){Name="고현정", Height=172},
                new Profile("고현정", 172),
                new Profile("이문세", 178),
                new Profile("하동훈",171)
            };

            //작업
            //특정 객체만 가지는 List를 만들고 싶다.
            List<Profile> profiles = new List<Profile>();
            //키가 175이하 배우만 수집
            foreach(Profile profile in arrProfile)
            {
                if (profile.Height < 175)
                    profiles.Add(profile);
            }
            //람다
            profiles.Sort(
                (profile1, profile2) =>
                {
                    return profile1.Height - profile2.Height;
                }
            );

            foreach (var profile in profiles)
                Console.WriteLine("{0}, {1}", profile.Name, profile.Height);

            //LINQ 사용
            var myProfiles = from profile in arrProfile
                             where profile.Height < 175
                             orderby profile.Height
                             select profile;

            Console.WriteLine();
            foreach (var profile in myProfiles)
                Console.WriteLine("{0}, {1}", profile.Name, profile.Height);
        }
    }
}
