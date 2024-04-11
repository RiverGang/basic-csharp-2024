namespace hello_world // 소스의 가장 큰 단위 namespace
{
    internal class Program // 접근제한자 class 파일명과 동일
    {
        static void Main(string[] args) // 정적 void Main
        {
            // 객체지향 언어에서의 메서드(= 절차지향 언어의 함수)
            // System 네임스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
            //Console.WriteLine("Hello, World!");
            if (args.Length == 0)
            {
                Console.WriteLine("사용법 : hellow_world.exe <이름>");
                return;
            }
            else
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
        }
    }
}
