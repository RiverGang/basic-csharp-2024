## 개인 프로젝트
- 야구 기록 프로그램
    - 특징: 야구 기록지 작성 기능구현
    
    - WinForm
        - 로그인

            ![로그인](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/pj001.png)

            - DB에 저장된 기록원만 접속 가능
            - 메인화면에 현재 접속 기록원 아이디 표기        
            
        - 메인화면

            ![메인화면](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/pj004.png)

            - 경기 별 타순 목록 데이터 선택
                - Data Grid View에 행 Click -> 선수 목록 팝업창 open -> 선수 선택 -> Data Grid 및 상단에 선수정보 반영
            
            
            ![타구기록](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/pj006.png)
            
            - 타구상황 & 방향에 따른 버튼 클릭 -> 타구 상황 별 기호/이미지를 PictureBox/Label에 기록

                - 타자 진루/아웃 -> 게임 상황 -> 타구 방향
                    - 타자 진루: 1,2,3루타, 홈런 | 볼넷/사구/실책
                    - 주자 진루: 도루, 진루, 득점

                    - 타자 아웃: 땅볼, 뜬공, 라이너, 삼진
                    - 주자 아웃: 타구방향
                
                - 아웃카운트 기록
                    - 아웃카운트 PictureBox 클릭 시, 아웃카운트 팝업 열림

            - 개선점
                - 아이콘 변경
                - Base3,4 클릭 시 수정이벤트
                - 이미 데이터가 입력된 행은 팝업이 뜨지 않도록하기
                - 이닝상황 콤보박스 옆에 팀 선택 콤보박스 추가 & 팀선택에 따라 타순 목록 클릭 시 open 되는 팝업창이 목록이 팀별로 다르게 나오도록하기
                - 아웃카운트 popup에 득점 옵션 추가하기
                - 메인화면 오른쪽 하단 빈 부분에 스코어보드 추가

- 최종 목표: 이닝별 && 선수별 기록상황이 저장되어 기록이 다르게 되고, DB에 반영되도록 하기!

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
    - **foreach**: python의 for item in []과 동일
    
    ```cs
     int[] arr = { 1, 2, 3, 4, 5 };
 
    foreach (var item in arr)
    {
        Console.WriteLine($"현재 수 : {item}");
    }
    ```

- 메서드(Method)
    - 함수와 동일. 구조적 프로그래밍 -> 함수, 객체지향 -> 메서드
    - **참조로 인수 전달**: ref 키워드, C++에서 Pointer로 값을 사용할 때와 동일한 기능

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

    ![인터페이스설명](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/cs001.png)

- 추상클래스(abstract)
    - Virtual 메서드하고도 유사
    - 추상클래스의 단순화 => 인터페이스

- **프로퍼티**
    - 클래스의 멤버변수 변형, 일반 변수와 유사
    - 멤버변수의 접근제한자를 public으로 했을 때의 객체지향적 문제점(코드오염 등)을 보완하기 위해서 사용
    - get 접근자/set 접근자
        - set은 값 할당 시에 잘못된 데이터가 들어가지 않도록 막야아 함
        - Java: Getter메서드/Setter메서드


## 2일차
- TIP
    - [C# 주의사항] 빌드 시 발생하는 오류 해결(프로세스 액세스 오류)
        - 빌드하고자 하는 프로그램이 백그라운드상에 실행 중이기 때문
        - Ctrl + Shift + ESC(=작업관리자)에서 해당 프로세스 작업 끝내기 후
        - 재빌드


- 컬렉션(배열, 리스트, 인덱서)
    - 모든 배열 => System.Array 클래스를 상속받는 하위 클래스
    - 기본적인 배열의 사용법, Python의 리스트와 동일
    - 배열 분할 - C# 8.0부터 파이썬의 배열 슬라이스 도입
    - 컬렉션, 파이썬의 리스트/스택/큐/딕셔너리와 동일
        - ArrayList
        - Stack
        - Queue
        - Hashtable(=Dictionary)
    - yield: foreach를 사용할 수 있는 객체로 만들기

- 일반화(Generic) 프로그래밍
    - Type의 제약을 해소하고자 만든 기능. ArrayList 등이 해결(but, 박싱/언박싱의 문제)
    - ex) 파이썬 -> 변수에 제약사항 X
    - **하나의 메서드로 여러 타입의 처리르 해줄 수 있는 프로그래밍 방식**
    - 일반화 컬렉션
        - List<T>
        - Stack<T>, Queue<T>
        - Dictionary<TKey, TValue>
    
- 예외처리
    - 소스코드 상 문법적 오류: 오류(Error)
    - 실행 중 생기는 오류: 예외(Exception)

- 대리자(delegate)와 이벤트
    - 메서드: 호출 시 매개변수 전달
    - 대리자: 호출 시 함수(메서드) 자체를 전달
    - 이벤트: 컴퓨터 내에서 발생하는 객체의 사건들
    - 익명 메서드 사용, 한번쓰고 말 함수가 필요할 때 유용
    - delegate --> event
    - 윈폼 개발 = 이벤트 기반(Event driven) 프로그래밍
    
- TIP: C# 주석 중 영역을 지정할 수 있는 주석
    - #region ~ #endregion
    - 영역을 Expend 또는 Collapse (확장 및 축소 가능)

    ![region주석](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/cs002.png)


## 3일차
- 람다식: 익명메서드를 만드는 방식 중 하나
    - delegate, lambda expression
    - 익명 메서드/프로퍼티 사용 시 코딩량 줄여줌
        - 익명 메서드 사용 마다 대리자를 선언해야하기 때문에
        - Func, Action을 MS에서 미리 만듦

        - Func: return 값 필수(입력 매개변수 가능), <> 내 파라미터 하나는 return을 의미
        - Action: return 값 X, 입력 매개변수만 지정 
    
- LINQ(Lanuguage INtegrated Query)
    - C#에 통합된 데이터 질의 기능(DB SQL과 거의 동일)
    - group by -> 집계함수 필수 X
    - 단, 키워드 사용순서가 다름

    - LINQ만 고집하면 안됨, 기존의 C# 로직을 사용해야 할 경우..

- 리플렉션, 애트리뷰트
    - 리플렉션 object.GetType();
    - [Obsolete(다음 버전 사용불가), true|false]

- dynamic 형식(파이썬 실행)
    - COM 객체 사용(dynamic 형식)
    - IronPython 라이브러리: Python을 C#에서 사용할 수 있도록 해주는 오픈소스 라이브러리
    - NuGet Package: 파이썬의 pip와 같은 라이브러리 관리툴
        - 해당 프로젝트 종속성, 마우스 오른쪽 클릭 > NuGet Package 관리
            1. 파이썬 엔진 생성, 스코프 객체, 설정경로 객체 생성
            2. 해당 컴퓨터 파이썬 경로들 설정
            3. 실행시킬 파이썬 파일 경로 지정
            4. 파이썬 실행(scope 연결)
            5. 파이썬 함수를 Func 또는 Action으로 매핑
            6. 매핑시킨 메서드를 실행

- 가비지 컬렉션
    - C, C++은 메모리 사용시 개발자가 직접 메모리 해제 필수
    - C#, Java, python 등의 객체지향 언어는 Garbage Collection(쓰레기 수집기) 기능으로 프로그램이 직접 관리
    - C# 개발자는 메모리 관리에 아무 것도 할게 없다!!

- Winform UI 개발 + 파일, 스레드
    - 이벤트, 이벤트핸들러 (대리자, 이벤트 연결)
    - 그래픽 사용자 인터페이스를 만드는 방법
        1. Winforms(Windows Forms)
        2. WPF(Windows Presetation Foundation)
    - WYSIWYG(What You See Is What You Get) 방식의 GUI 프로그램 개발


## 4일차
- 윈폼 UI 개발
    - Winforms로 윈폼 개발 학습
    - Ctrl + A: 전체선택
    - 컨트롤 Profix
        - ComboBox: Cbo ~
        - CheckBox: Chk ~
        - RadioButton: Rdo ~
        - TextBox: Txt~
        - Button: Btn~
        - TrackBar: Trb~
        - ProgressBar: Prg~
        - TreeView: Trv~
        - ListView: Lsv~
        - PictuerBox: Pic~
        - *Dialog : Dlg~
        - RichTextBox : Rtx~

## 5일차
- 윈폼 UI 개발(계속)
    - 파일 입출력 추가
        - 리치텍스트박스(like MSWord, 한글워드)로 파일저장

    - 스레드 추가
        - 프로세스를 나누어서 동시에 여러가지 일을 진행
        - 스레드 사용하기 불편함
        - C# BackgroundWorker 클래스를 추가(Thread를 사용하기 편하게 만든 클래스)
    
        <img src="https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/cs003.png" width="850">
            
    - 비동기 작업 앱
        - 가장 트렌드가 되는 작업방법
        - 백그라운드 처리는 Thread, BackgroundWork와 유사 
        - async, await 키워드

        ![비동기앱](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/cs004.png)


## 6일차
- 토이 프로젝트
    - 윈도우 탐색기 앱(컨트롤 학습)
        - MyExplorer 프로젝트 생성
        - 아이콘 검색: flatinco.com
        - 확장자 변환: pnq to ico
        - 트리뷰, 리스트뷰 기능 추가

        ![중간결과](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/cs005.png)

        - 미적용: 컨텍스트메뉴 보기 기능, 더블클릭 프로그램 실행 ...


## 7일차
- 토이 프로젝트
    - 윈도우 탐색기 앱 종료
        - 실행 결과

        https://github.com/RiverGang/basic-csharp-2024/assets/122778656/98034ddd-82bd-4702-8e6f-f6871f382ca6




        
    - 도서관리 앱 with SQL Server(Base) ModernUI 앱 (NuGet패키지)
    
    ```cs
    // 값 형식 변수에 null값을 넣을 수 있도록 만들어준 기능 Nullable => ?
    // 변수명 뒤에 ? 만 추가할 것
    int? a = null;
    double? b = null;
    float? c = null;
    ```


## 8일차
- 토이 프로젝트
    - 도서관리 앱 관리환면
        - 앱 사용자 관리완료


## 9일차
- 토이 프로젝트
    - 도서관리 앱
        - 기존에 만들어진 폼을 복사하여 변경할 때
        - *** .cs 클래스명, 생성자, *.Designer.cs에 있는 클래스명 ***
        - 3군데 모두 이름 변경
        - 공통클래스 
            - 폴더를 추가해서 혼동되지 않게 분리해주면 좋음
            - [추가] - [클래스]
        - 책장르 관리
        - 책정보 관리
        
        
## 10일차        
        - 도서회원 관리
        - 대출관리
        - 이 프로그램은 ...

        - ![책대여프로그램](https://raw.githubusercontent.com/RiverGang/basic-csharp-2024/main/images/cs006.png)



## 나머지
- Pending
    - IoT Dummy 앱 with SQL Server(IoT, DB)
    - 국가교통정보센터 CCTV뷰 앱 (OpenAI, NuGet dll, Network)



