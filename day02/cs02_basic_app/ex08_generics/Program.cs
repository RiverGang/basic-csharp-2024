namespace ex08_generics
{
    internal class Program
    {   
        // 배열 복사 기능 -> 일반화 프로그래밍
        // 메서드 뒤에 <T>, 각 매개변수의 Type 대신 T로 변경
        static void CopyArray<T>(T[] src, T[] dest) // 배열을 복사하는 메서드, src배열을 dest에 복사한다
        {
            for(int i = 0; i < src.Length; i++) { dest[i] = src[i]; }
        }

        //static void CopyArray(float[] src, float[] dest) // CopyArray 오버로딩
        //{
        //    for (int i = 0; i < src.Length; i++) { dest[i] = src[i]; }
        //}

        static void Main(string[] args)
        {
            int[] array1 = { 10, 20, 30, 50, 70 };
            int[] array2 = new int[array1.Length];

            CopyArray(array1, array2);
            Console.WriteLine(array2[4]);

            float[] array3 = { 3.4f, 2.2f, 7.7f };
            float[] array4 = new float[array3.Length];
            CopyArray(array3, array4);
            Console.WriteLine(array3[0]);

        }
    }
}
