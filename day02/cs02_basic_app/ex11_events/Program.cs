namespace ex11_events
{
    delegate int MyDelegate(int a, int b);
    delegate void EventHandler(string message); // 이벤트핸들러 대리자(어떠한 메서드를 대신 호출)


    class CustomNotifier // 우리가 구현한 것이 아닌, 원래부터 만들어져 있는 것이라고 생각
    {
        // 이벤트 등록, evet라는 키워드를 쓰면 기본적으로 EventHandler 이름을 일반적으로 사용
        public event EventHandler SomthingHappend; // 뭔가 일이 일어나면 대신 처리

        public void DoSomething(int number)
        {
            int temp = number % 10;
            if (temp != 0 && temp % 3 == 0)
            {   // 3,6,9 등의 상태가 되면 이벤트를 발생시키겠다
                SomthingHappend($"{number} : 짝!"); // SomthingHappend가 처리할 로직이 포함되어있지 않음 (10행에서 선언만 되어있음.)
                // () 괄호 안이 string message
                
                // 이벤트 핸들러 발생, 자신의 메서드가 아닌 외부에서 만들어진 메서드를 대신 실행

            }
        }
    }

    
    internal class Program
    {   
        public static void MyHandler(string message)
        {
            Console.WriteLine("다른 일을 처리합니다");
           // Console.WriteLine($"{DateTime.Now.ToShortTimeString()} : {message}");
        }
    
        static void Main(string[] args)
        {
            #region "익명 메서드"
            MyDelegate callback; // 대리자
            // 메서드 이름이 존재X
            // 익명 메서드, 한번 사용이후 다시 호출할 필요가 없을 때 사용.
            callback = delegate (int a, int b)
            {
                return a + b;
            };
            
            var result = callback(10, 4);
            #endregion

            CustomNotifier notifier = new CustomNotifier();
            notifier.SomthingHappend += new EventHandler(MyHandler); // 특정한 이벤트에서 실행될 '기능'(=메서드)는 MyHandler이다

            for (int i = 0;  i < 30; i++)
            {
                notifier.DoSomething(i); // 이벤트 발생
            }

            // notifier.SomethingHappened(30); // 이벤트핸들러는 함수가 아니기 때문에 호출불가
        }
    }
}
