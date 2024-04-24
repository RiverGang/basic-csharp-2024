using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NewBookRentalShopApp.Helper
{
    public class Common
        // 두가지 윈폼에 반복적으로 쓰이는 메서드를 공통 클래스의 공통 메서드로 축약
    {
        
        // 정적으로 만드는 공통 연결문자열
        // readonly 키워드: 개발자가 변경하지 않는 이상 변경할 수 없는 키워드
        public static readonly string ConnString = "Data Source=localhost;Initial Catalog=BookRentalShop2024;" +
                                   "Persist Security Info=True;User ID=sa;Encrypt=False;Password=mssql_p@ss";

       
        // 회원선택 팝업에서 대출화면으로 넘길데이터 정적프로퍼티
        public static string SelMemberIdx {  get; set; }
        public static string SelMemberName { get; set; }
        public static string SelBookIdx { get; set; }
        public static string SelBookName { get; set; }

        // 로그인아이디
        public static string LoginId { get; set; }

        
        
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // 입력문자열을 byte배열로 변환한 뒤 MD5 해시 처리
            // MD5 해시 알고리즘 암호화
            // 1234 --> 0101101 -> 110010101101011 -> x65xAEx11...
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder(); // 문자열을 좀 더 쉽게 만들어주는 클래스
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2")); // 16진수 문자로 각 글자를 전부 변환
            }

            return builder.ToString();
        }
    }


}