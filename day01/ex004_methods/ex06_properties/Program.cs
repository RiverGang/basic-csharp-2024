namespace ex06_properties
{
    class Kiturami
    {
        private int temperatur; // 온도

        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        } // 일반 프로퍼티

        public string Name { get; set; } // auto 프로퍼티 사용
                                         // name 값을 초기화 할 때 별다른 제약을 두지 않기에
                                         // 즉, GET/SET에서 특별한 로직이 없으면 생략 가능함

        public int Temperatur // 특별한 로직이 있는 auto 프로퍼티
        {
            get 
            {   // 단순 값 리턴, 특별한 기능 X
                return temperatur; 
            }
            set
            {  // 잘못된 값이 들어오면 안되기에 여러 제약을 걸어줌 
                if (value < 10)
                {
                    temperatur = 20; // 10도 이하는 허용안함
                }
                else if (value > 70)
                {
                    temperatur = 50; // 70도 초과는 허용안함
                }
                else
                temperatur = value;
            }
            
        }

        // 생성자
        public Kiturami(int year, string name, int temperatur)
        {
            Year = year;
            Name = name;
            Temperatur = temperatur;
        }

        public void SetTemperature(int temp)
        {
            if (temp > 70)
            {
                Console.WriteLine("온도가 너무 높습니다. 50도로 조정합니다");
                this.temperatur = 50;
            }
            else if (temp < 10)
            {
                Console.WriteLine("온도가 너무 낮습니다. 20도로 조정합니다");
                this.temperatur = 20;
            }
            else
            {
                this.temperatur = temp;
            }
        }

        public int GetTemperature()
        {
            return this.temperatur;
        }
        public void On()
        {
            Console.WriteLine("보일러 On");
        }

        public void Off()
        {
            Console.WriteLine("보일러 Off");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("보일러 시작!");
            
            //Kiturami boiler = new Kiturami();
            ////boiler.SetTemperature(400); --> 막아버림 public은 사용하면 안됨
            ////Console.WriteLine($"보일러 온도는 {boiler.GetTemperature()}도");
            //boiler.Temperatur = 400;
            //Console.WriteLine($"보일러 온도는 {boiler.GetTemperature()}도");
            //boiler.On();

            //boiler.Name = "귀뚜라미";
            //Console.WriteLine($"보일러 이름은 {boiler.Name}");


            Kiturami kiturami = new Kiturami(name: "라미", temperatur: 27, year: 2023);
            Console.WriteLine(kiturami.Name);
            Console.WriteLine($"제작년도: {kiturami.Year}");
            kiturami.Temperatur = 180;
            Console.WriteLine($"{kiturami.Name}의 현재 온도는 {kiturami.Temperatur}도");
        }
    }
}
