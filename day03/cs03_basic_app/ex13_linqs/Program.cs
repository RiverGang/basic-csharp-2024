using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ex13_linqs
{
    class Profile
    {
        private int age;
        public string Name { get; set; } // 자동 프로퍼티

        public int Height { get; set; } // 키에 -21억~21억

        public int Age // 나이도 -21억~21억 값 모두 들어감, 제약설정 필요
        {
            get => age;
            set
            {
                if (value >= 0 && value < 200) { age = value; }
                else { age = 20; } // 입력 범주를 넘어가면 20으로 fix
            }
        }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }

        internal class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfiles =
            {
                new Profile { Name  = "정우성", Height = 186, Age =49},
                new Profile { Name  = "이정재", Height = 184, Age =49},
                new Profile { Name  = "김태희", Height = 158, Age =46},
                new Profile { Name  = "전지현", Height = 172, Age =44},
                new Profile { Name  = "이문세", Height = 180, Age =55},
                new Profile { Name  = "장원영", Height = 165, Age =24},
                new Profile { Name  = "RM", Height = 175, Age =29}
            };

            Product[] arrProducts =
            {
                new Product { Title = "비트", Star = "정우성"},
                new Product { Title = "오징어게임", Star = "이정재"},
                new Product { Title = "엽기적인 그녀", Star = "전지현"},
                new Product { Title = "도둑들", Star = "전지현"},
                new Product { Title = "Dynamite", Star = "RM"},
                new Product { Title = "Solo 예찬", Star = "이문세"}
            };


            // LINQ 미사용
            List<Profile> profiles = new List<Profile>();

            foreach (Profile profile in arrProfiles) 
            { 
                if(profile.Height < 175)
                    profiles.Add(profile);
            }

            profiles.Sort(
                (profile1, profile2) =>
                {
                    return profile1.Height - profile2.Height;
                });

            foreach(var profile in profiles)
            {
                Console.WriteLine($"{profile.Name}({profile.Age}세), {profile.Height}cm");
            } // 15줄 코딩


            // LINQ 사용
            Console.WriteLine("LINQ 사용");

            var profiles2 = from profile in arrProfiles
                            where profile.Height < 175
                            orderby profile.Height
                            select profile;

            foreach (var profile in profiles2)
            {
                Console.WriteLine($"{profile.Name}({profile.Age}세), {profile.Height}cm");
            } // LINQ 사용 시 -> 8줄 코딩



            // LINQ 기본
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = from n in numbers
                         where n % 2 == 0
                         orderby n descending //내림차순으로
                         select n;

            foreach (var item in result)
            {
                Console.WriteLine(item );
            }


            // group by - DB의 group by처럼 집계함수가 필요하진 않음
            var groupProfiles = from profile in arrProfiles
                                group profile by profile.Height < 175 into g
                                select new { GroupKey = g.Key, Profiles = g };

            foreach (var group in groupProfiles)
            {
                Console.WriteLine($"- 175cm 미만? : {group.GroupKey}");

                foreach (var profile in group.Profiles)
                {
                    Console.WriteLine($">>> {profile.Name}({profile.Age}세) {profile.Height}cm");
                }
            }

            // LINQ JOIN

            // 내부조인
            var innerJoinResult = from pf in arrProfiles
                                  join pr in arrProducts
                                  on pf.Name equals pr.Star // 내부조인
                                  select new // 새로운 쿼리 생성
                                  {
                                      Name = pf.Name,
                                      Work = pr.Title,
                                      Height = pf.Height,
                                      Age = pf.Age
                                  };

            Console.WriteLine("내부조인 결과");
            foreach (var item in innerJoinResult)
            {
                Console.WriteLine($"작품: {item.Work} / 아티스트: {item.Name} / 나이: {item.Age}세");
            }


            // 외부조인
            var outerJoinResult = from pf in arrProfiles
                                  join pr in arrProducts
                                  on pf.Name equals pr.Star
                                  // 여기 아래부터 외부조인시, 내부조인 LINQ에 추가되는 부분
                                  into ps // ps라는 새로운 컬럼 생성
                                  from pr in ps.DefaultIfEmpty(new Product() { Title = "작품없음" }) // Defalt 값 지정
                                  select new
                                  {
                                      Name = pf.Name,
                                      Work = pr.Title,
                                      Height = pf.Height,
                                      Age = pf.Age
                                  };


            Console.WriteLine("외부조인 결과");
            foreach (var item in outerJoinResult)
            {
                Console.WriteLine($"작품: {item.Work} / 아티스트: {item.Name} / 나이: {item.Age}세");
            }


        }
    }
}
