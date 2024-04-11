# basic-csharp-2024
2024년 IoT개발자과정 C# 리포지토리

## 1일차
- C# 소개
    - MS에서 개발한 차세대 프로그래밍 언어
    - 2000년 최초 발표, 앤더스 하일버그(파스칼, 델파이 개발자)
    - 1995년 Java 발표되면서 경쟁하기 위해 개발
    - 객체지향 언어, C/C++과 Java를 참조해서 개발
    - OS플랫폼 독립적, 메모리관리 쉬움
    - 다양한 분야에서 사용 중
    - 2024년 기준 ver12

- .NET Framework (CLR)
    - Windows OS에 종속적
    - OS(운영체제)이 독립적인 새로운 틀 제작시작(2022년 ~ing)
    - 2024년 현재 .NET 8.0
    - C/C++은 gcc 컴파일러, Java는 JDK, C#은 .NET 5.0 이상의 프레임워크 필요
    - 이제는 신규개발 시, .NET Framework는 사용하지말 것


- Hello, C#!
    - Visual Studio 시작
    - 프로젝트: 프로그램 개발 최소단위 그룹
    - 솔루션: 프록젝트의 묶음

    ```cs
    namespace hello_world // 소스의 가장 큰 단위 namespace
    {
        internal class Program // 접근제한자 class 파일명과 동일
        {
            static void Main(string[] args) // 정적 void Main
            {
                // 객체지향 언어에서의 메서드(= 절차지향 언어의 함수)
                // System 네임스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
                Console.WriteLine("Hello, World!");
            }
        }
    }
    ```

- 변수와 상수
    - C++과 동일 -> 패스
    - 모든 C#의 객체는 Object를 조상으로
    - 프로그램 메모리 종류: 스택(값형식: 정수/실수 ...) 힙(참조형식: 클래스/객체/문자열/리스트/배열 ...)
    - Boxing(박싱), Unboxing(언박싱)
    ```cs
    int a 20;
    object b = a; // 박싱(오브젝트 박스에 담는다)
    
    int c = (int)b; // 언박싱(object를 각 타입으로 변환)
    ```

    - 상수: const 키워드
    - 열거형식: enum 키워드
    - var: 컴파일러가 자동으로 Type을 지정해주는 변수, 지역변수에만 사용 가능

- 연산자
    - C++과 동일
    - ++, --는 파이썬에 없음
    - and, or -> &&, ||

- 흐름제어
    - C++과 동일
    - if, swich, while, do while, for, break, continue, goto 모두 동일
    - foreach: python의 for item in []과 동일
    
    ```cs
     int[] arr = { 1, 2, 3, 4, 5 };
 
    foreach (var item in arr)
    {
        Console.WriteLine($"현재 수 : {item}");
    }
    ```

- 메서드(Method)
    - 함수와 동일. 구조적 프로그래밍 -> 함수, 객체지향 -> 메서드
    - 참조로 인수 전달: ref 키워드

    ```cs
     public static void RefSwap(ref int a, ref int b)
    {
        int temp = b;
        b = a;
        a = temp;
    }

    // 사용시 ref 키워드 사용
    RefSwap(ref x, ref y);
    ```
    
    - 매개변수 출력형식 -> 매개변수를 리턴값으로 사용하도록 대체(과도기적인 방법)

    ```cs
     //quotient 나누기 값, remainder 나머지
    public static void Divide(int a, int b, out int quotient, out int remainder)
    {// 예전엔 튜플리턴이 없어서 한번에 하나만 값을 리턴할 수 있었음
     // 하나의 값만 출력되는 return이 아닌, 여러개의 값을 out
    ```
    
    - 메서드 오버로딩 -> 여러 Type으로 같은 처리를 하는 메서드를 여러 개 만들 때
    - 매개변수 가변길이 -> 매개변수 개수를 동적으로 처리

    ```cs
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
    ```

    - 명명된 매개변수 -> 매개변수 사용 순서 변경가능
    
    ```cs
    public static void PrintProfile(string name, string phone)
    { // ...

    PrintProfile(phone: "010-1234-5678", name: "이성희"); //매개변수 순서 변경가능
    // 함수 정의는 name, phone 순서지만 위와 같이 순서를 변경하여 입력 가능
    ```

    - 기본값 매개변수: 매개변수 값 미할당시, 기본값으로 지정

    ```cs
     public static void DefaultMethod(int a = 1, int b = 0)
    { // ...

    DefaultMethod(10, 8); // => a=10, b=8
    DefaultMethod(6); // => a=6, b=0
    DefaultMethod();// => a=1, b=0
    // 단, DefaultMethod( , 6)은 불가능
    ```

- 클래스
    - C++의 클래스, 객체와 유사하나 문법이 다소 상이
    - 생성자: new를 사용해 객체 생성
    - 종료자(파괴자)는 C#에서 거의 사용 X
    - 생성자 오벌됭 -> 파라미터 개수에 따라서 사용가능, 기본적인 메서드 오버로딩과 기능 동일
    - this. 키워드: C++ this->, 파이썬의 self와 동일
    - 접근한정자(Access Modifier)
        - public: 모든 곳에서 접근
        - default(=pirvate): 외부에서 접근 불가
        - protectd: 외부에서 접근 불가, 단 파생클래스(상속관계)에서 접근 가능
        - internal: 같은 어셈블리(네임스페이스)내에서는 public과 동일
        - 그 외: protected internal, private protected

    - C#에는 C++과 같은 다중상속 없음. C++의 다중상속으로 생기는 문제점을 해결하기 위해 다중상속을 없앰
        - 다중상속 기능 -> 인터페이스

        ```cs
        class BaseClass {} // 부모클래스

        class DerivedClass : BaseClass {} // 파생(자식)클래스
        ```

- 구조체
    - 객체지향이 없었을 때, 좀더 객체지향적인 프로그래밍을 위해서 만들어진 부분(C언어에서)
    - class 이후로 사용빈도가 매우 줄어듦
    - 구조체 스택(값형식), 클래스 힙(참조형식)
    - C#에서는 구조체 안써도 됨

- 튜플(C# 7.0 이후 반영)
    - 한꺼번에 여러개의 데이터를 리턴/전달 할 때 유용
    - 값 한번 할당 후 변경불가

- 인터페이스
    - 클래스 -> 객체의 청사진이라면, 인터페이스 -> 클래스의 청사진
    - 인터페이스: 클래스가 어떠한 메서드를 가져야 하는지 약속하는 것
    - 다중상속의 문제를 단일상속으로도 해결가능하도록 만든 주체
    - 명령 시, 제일 앞에 I를 적음
    - 인터페이스의 메서드에는 구현을 작성하지 않음
    - 인터페이스는 약속
        - [!]클래스는 상속 시 별다른 문제가 없으나, 인터페이스는 약속을 지키지 않으면 빌드 불가
    - 클래스는 상속한다 vs 인터페이스는 구현한다

- 추상클래스(abstract)
    - Virtual 메서드하고도 유사
    - 추상클래스의 단순화 => 인터페이스

- 프로퍼티
    - 클래스의 멤버변수 변형, 일반 변수와 유사
    - 멤버변수의 접근제한자를 public으로 했을 때의 객체지향적 문제점(코드오염 등)을 보완하기 위해서 사용
    - GET 접근자/SET 접근자
        - set은 값 할당 시에 잘못된 데이터가 들어가지 않도록 막야아 함
        - Java: Getter메서드/Setter메서드


## 2일차
- 컬렉션(배열, 리스트, 인덱서)
- 일반화(Generic) 프로그래밍
- 예외처리
- 대리자와 이벤트
- 람다식
- 애트리뷰트
- dynamic 형식
- Winform (파일, 스레드)
- 가비지 컬렉션
- 네트워크 프로그래밍

- WPF
- 