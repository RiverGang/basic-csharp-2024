using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Helper
{
    internal class Common
    {
        public static readonly string ConnString = "Data Source=localhost;Initial Catalog=BaseballRecord2024;" +
                                  "Persist Security Info=True;User ID=sa;Encrypt=False;Password=mssql_p@ss";
        public static int OutCount { get; set; }
        // 선수목록선택
        public static string SelPlayerName { get; set; }
        public static string SelBackNumber { get; set; }
        public static string SelTeamName { get; set; }
        public static int SelTeamNum { get; set; }


        // 로그인아이디
        public static string LoginId { get; set; }
    }
}
