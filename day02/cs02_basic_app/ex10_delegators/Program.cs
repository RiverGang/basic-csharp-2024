using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ex10_delegators

{
    delegate int MyDelegate(int a, int b);
    delegate int Compare(int a, int b); // 두 값을 비교하는 대리자



    // 어떠한 일이 발생하는지 시스템이 알려주는 것 - 이벤트
    delegate void Notify(string message); // Notify 대리자 선언

    class Notifier
    {
        public Notify EventOccured; //이벤트 발생(이벤트 메서드 실행)
    }

    class EventListener // 이벤트가 발생하는지 듣고있는 객체
    {
        private string name;
        public EventListener(string name) { this.name = name; }
        public void SomethingHappend(string message)
        {
            Console.WriteLine($"{name}.뭔일이 발생했다! : {message}");
        }
    }




    class Sorting
    {
        // 오름차순 비교
        public int AscendCompare(int a, int b)
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        // 내림차순 비교
        public int DescendCompare(int a, int b)
            {
                if (a > b)
                    return -1;
                else if (a == b)
                    return 0;
                else
                    return 1;
        }

        public void BubbleSort(int[] DataSet, Compare comparer)
        {
            int temp = 0;

            for(int i = 0; i <DataSet.Length -1; i++)
            {
                for(int j = 0; j <DataSet.Length - (i+1); j++)
                {
                    if (comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }    
            }
        }
    }

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("리스너1");
            EventListener listener2 = new EventListener("리스너2");
            EventListener listener3 = new EventListener("리스너3");

            // 대리자 체인 notifier의 EventOccured라는 대리자에 리스너 3개에서 일어날 수 있는 메서드를 모두 연결
            // 일반적인 함수나 메서드 호출에서는 한번에 여러 개의 함수 실행 불가능!!
            notifier.EventOccured += listener1.SomethingHappend;
            notifier.EventOccured += listener2.SomethingHappend;
            notifier.EventOccured += listener3.SomethingHappend;
            notifier.EventOccured("메일을 받았어요!");
            Console.WriteLine();

            notifier.EventOccured -= listener2.SomethingHappend; // 리스너 2번의 함수는 실행 X
            notifier.EventOccured("파일 다운로드 완료!!!");
            Console.WriteLine();

            notifier.EventOccured = new Notify(listener2.SomethingHappend) + new Notify(listener3.SomethingHappend);
            notifier.EventOccured("미사일 발사!");






            #region "계산기 대리자 코드 영역"
            Calculator clac = new Calculator();
            MyDelegate Callback;
            
            Callback = new MyDelegate(clac.Plus); // int a, int b가 아닌 Calculator 객체의 Plus() 메서드를 전달
            var result = Callback(10, 4); // Callback은 calc.Plus를 실행
            Console.WriteLine(result); // 14

            Callback = new MyDelegate(clac.Minus);
            result = Callback(10, 4);
            Console.WriteLine(result); // 6
            #endregion


            /* ------------------------------------------------------- */

            int[] array = { 3, 7, 10, 5, 4, 1, 9 };

            Sorting sorting = new Sorting();

            Console.WriteLine("오름차순 정렬");
            sorting.BubbleSort(array, new Compare(sorting.AscendCompare));
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{array[i]}, ");
            }
            Console.WriteLine();

            Console.WriteLine("내림차순 정렬");
            sorting.BubbleSort(array, new Compare(sorting.DescendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{array[i]}, ");
            }
            Console.WriteLine();



        }
    }
}
