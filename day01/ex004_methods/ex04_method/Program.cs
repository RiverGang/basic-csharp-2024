using System.ComponentModel.DataAnnotations;

namespace ex04_method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 3; int y = 4;

            BasicSwap(x, y);
            Console.WriteLine($"BasicSwap: x = {x}, y = {y}");
            
            RefSwap(ref x, ref y); // 참조 매개변수 사용 시, ref 써줘야함
            Console.WriteLine($"RefSwap: x = {x}, y = {y}");

            int a = 10; int b = 3;
            int 값 = 0; int 나머지 = 0;
            Divide(a, b, out 값, out 나머지);
            Console.WriteLine($"{a} / {b} = {값}, {나머지}");

            //메서드 오버로딩
            int res = Plus(x, y);

            float x1 = 3.4f; float y1 = 4.5f;
            float res1 = Plus(x1, y1);
            Console.WriteLine($"x + y = {res} / x1 + y1 = {res1}");


            // 가변길이 매개변수
            Console.WriteLine(Sum([23, 45, 10, 56, 13]));

            //명명된 매개변수
            PrintProfile(phone: "010-5886-0903", name: "이성희"); //매개변수 순서 변경가능

            // 기본값 매개변수
            DefaultMethod(10, 8);
            DefaultMethod(6);
            DefaultMethod();
        }



        public static void BasicSwap(int a, int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        public static void RefSwap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        //quotient 나누기 값, remainder 나머지
        public static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
            // 예전엔 튜플리턴이 없어서 한번에 하나만 값을 리턴할 수 있었음
            // 하나의 값만 출력되는 return이 아닌, 여러개의 값을 out
            
        }

        // 메서드 오버로딩
        public static int Plus(int a, int b) {  return a + b; }

        public static float Plus(float a, float b) {  return a + b; }

        // 가변길이 매개변수
        public static int Sum(params int[] argv)
        {
            int sum = 0;
            foreach(var item in argv)
            {
                sum += item;
            }
            return sum;
        }

        // 명명된 매개변수
        public static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"이름 = {name}, 모바일 = {phone}");
        }

        // 기본 값 매개변수
        public static void DefaultMethod(int a = 1, int b = 0)
        {
            Console.WriteLine($"Default Value = {a}, {b}");
        }
    }
}
