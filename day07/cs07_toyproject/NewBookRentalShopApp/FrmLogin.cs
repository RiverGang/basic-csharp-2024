using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmLogin : MetroForm
    {
        private bool isLogin = false;

        public bool IsLogin { get { return isLogin; } set { isLogin = value; } }
        public FrmLogin()
        {
            InitializeComponent();
            
            TxtUserId.Text = string.Empty;
            TxtPassword.Text = string.Empty;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit(); // 종료 시, 종료를 물어보는 다이얼로그 작동
            Environment.Exit(0); //완전 종료
        }

        // 로그인버튼 클릭 이벤트핸들러
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            // DB연계
            #region "아이디/패스워드 입력창 Empty or Null 확인"
            bool isFail = false;
            string errMsg = string.Empty;

            if(string.IsNullOrEmpty(TxtUserId.Text)) // TxtUserId가 Null 이거나 Empty일 경우
            {
                isFail = true;
                errMsg += "아이디를 입력하세요\n";
            }
            
            if(string.IsNullOrEmpty(TxtPassword.Text))
            {
                isFail = true;
                errMsg += "패스워드를 입력하세요\n";
            }

            if(isFail == true)
            {
                MessageBox.Show(errMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            IsLogin = LoginProcees(); // 로그인이 성공하면 True, 실패하면 False 리턴
            if (IsLogin) this.Close(); // 현재 로그인창이 닫혀야 Main창이 열림
        }

        // 로그인 DB처리 시작
        private bool LoginProcees()
        {
            var md5Hash = MD5.Create();
            
            string userId = TxtUserId.Text; // 현재 폼에서 DB로 넘기는 값
            string password = TxtPassword.Text;

            string chkUserId = string.Empty; // DB에서 넘어오는 값
            string chkPassword = string.Empty; 

            
            /*
            1. Connection 생성, 오픈
            2. 쿼리 문자열 생성
            3. SqlCommand 명령용 객체 생성
            4. SqlParameter 객체 생성
            5. Select문 => SqlDataReader 또는 SqlDataSet 객체 사용
            6. CUD 작업 => SqlCommand.ExecuteQuery() 사용
            7. Connection 닫기
            */

            //연결문자열(ConnectionsString)
            //Data Source=localhost;Initial Catalog=BookRentalShop2024;Persist Security Info=True;User ID=sa;Encrypt=False;Password=mssql_p@ss
            
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                string query = $@"SELECT userId 
                                      , [password]
                                   FROM Usertbl
                                  WHERE userId = @userId 
                                    AND [password] = @password"; // @userId와 @password는 쿼리문 외부에서 변수 값을 안전하게 주입함
                SqlCommand cmd = new SqlCommand(query, conn);

                //@userId, @password 파라미터 할당
                SqlParameter prmUserId = new SqlParameter("@userId", userId);
                SqlParameter prmPassword = new SqlParameter("@password", Helper.Common.GetMd5Hash(md5Hash, password));

                cmd.Parameters.Add(prmUserId);
                cmd.Parameters.Add(prmPassword);

                SqlDataReader reader = cmd.ExecuteReader(); // 아이디와 패스워드가 넘어옴

                if(reader.Read())
                {
                    chkUserId = reader["userId"] != null ? reader["userId"].ToString() : "-"; // reader이 가리키는 쿼리에 속성 ["??"] 값이 있으면 (not null) 값을 string으로 변환
                    chkPassword = reader["password"] != null ? reader["password"].ToString() : "-"; //Password가 0이면 -로 변경
                    
                    return true;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 없습니다.", "DB오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //using을 사용하면 conn.Close()가 필요없음.
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 키보드를 입력(KeyPress)한 값(KeyChar)이 Enter(=13)이면
            {
                BtnLogin_Click(sender, e); // BtnLoging_Click 이벤트핸들러 실행
            } 
        }

        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 키보드를 입력(KeyPress)한 값(KeyChar)이 Enter(=13)이면
            {
                TxtPassword.Focus(); // 패스워트 Txt창으로 포커스이동
            }
        }


    }
}
