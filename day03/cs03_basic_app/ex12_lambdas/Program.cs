using System.Reflection;

namespace ex12_lambdas
{
    // 정수 값 두개를 받아 정수 값을 리턴해주는 함수는 내가 대신 해줄게라는 형식의 대리자 Calculate
    delegate int Calculate(int a, int b);
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("익명 메서드");
            // 메서드 일반 사용
            Calculate calc;
            calc = delegate (int a, int b)
            {
                return a + b;
            };

            Console.WriteLine($"계산결과 = {calc(10, 4)}");

            // 메서드 람다식 사용 => 훨씬 짧게 가능
            // return문 생략해야함
            Calculate calc2 = (a, b) => a + b; //{ return a + b; };
            Console.WriteLine($"계산결과 = {calc2(10, 5)}");


            // 문장 형식의 람다식
            Calculate calc3 = (a, b) =>
            {
                Console.WriteLine("이런 식으로 뺄셈이 됩니다.");
                var sum = a - b;
                return sum;
            };

            Console.WriteLine($"계산결과 = {calc3(11, 4)}");



            // ------------ Func, Action 빌트인 대리자 사용 -------------
            
            // Func: return값은 필수 -> 꺽쇠 안 type 하나는 return을 뜻함. 두 개 -> 매개변수 하나, return 하나
            Func<int> func1 = () => 10; // return만 존재
            Console.WriteLine($"Func1 = {func1}");

            Func<int, int> func2 = (x) => x * 2; // 매개변수와, return 모두 o
            Console.WriteLine($"Func2 = {func2(4)}");

            Func<int, int, double> func3 = (x, y) => (double)x / y; //매개변수 1개 이상
            Console.WriteLine($"Func3 = {func3(22, 7)}");


            //Acution은 리턴 값이 없음
            int result = 0;
            Action<int> act1 = (x) => result = x * x;
            act1(3);
            Console.WriteLine($"Act1 = {result}");

            Action<double, double> act2 = (x, y) => //매개변수 2개
            {
                double res = x / y;
                Console.WriteLine(res);
            };

            act2(21.1, 7.0);


       

            
            


        }

    }
}

class Test
{
    private int name;
    private double point;

    public int Name // 기존의 프로퍼티 방식
    {
        get { return name; }
        set { name = value; }
    }

    public double Point // 람다식 사용한 프로퍼티, 코딩이 간편해짐
    {
        get => point;
        set => point = value;
    }
}
