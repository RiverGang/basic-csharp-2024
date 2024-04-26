using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class FrmLogin : MetroForm
    {
        private bool isLogin = false;
        public bool IsLogin { get { return isLogin; } set { isLogin = value; } }


        public FrmLogin()
        {
            InitializeComponent();
            TxtId.Text = string.Empty;
            TxtPassword.Text = string.Empty;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            #region "아이디/패스워드 입력창 Empty or Null 확인"
            bool isFail = false;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtId.Text)) // TxtId가 Null 이거나 Empty일 경우
            {
                isFail = true;
                errMsg += "아이디를 입력하세요\n";
            }

            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                isFail = true;
                errMsg += "패스워드를 입력하세요\n";
            }

            if (isFail == true)
            {
                MessageBox.Show(errMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            IsLogin = LoginProcees(); // 로그인이 성공하면 True, 실패하면 False 리턴
            if (IsLogin) this.Close(); // 현재 로그인창이 닫혀야 Main창이 열림
        }

        private bool LoginProcees()
        {

            string recorderId = TxtId.Text; // 현재 폼에서 DB로 넘기는 값
            string password = TxtPassword.Text;

            string chkUserId = string.Empty; // DB에서 넘어오는 값
            string chkPassword = string.Empty;

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                string query = $@"SELECT recorderId 
                                      , [password]
                                   FROM Recordertbl
                                  WHERE recorderId = @recorderId 
                                    AND [password] = @password"; // @userId와 @password는 쿼리문 외부에서 변수 값을 안전하게 주입함
                SqlCommand cmd = new SqlCommand(query, conn);

                //@userId, @password 파라미터 할당
                SqlParameter prmRecorderId = new SqlParameter("@recorderId", recorderId);
                SqlParameter prmPassword = new SqlParameter("@password", password);

                cmd.Parameters.Add(prmRecorderId);
                cmd.Parameters.Add(prmPassword);

                SqlDataReader reader = cmd.ExecuteReader(); // 아이디와 패스워드가 넘어옴

                if (reader.Read())
                {
                    chkUserId = reader["recorderId"] != null ? reader["recorderId"].ToString() : "-"; // reader이 가리키는 쿼리에 속성 ["??"] 값이 있으면 (not null) 값을 string으로 변환
                    chkPassword = reader["password"] != null ? reader["password"].ToString() : "-"; //Password가 0이면 -로 변경
                    Helper.Common.LoginId = chkUserId;
                    
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


        private void BtnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); //완전 종료
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 키보드를 입력(KeyPress)한 값(KeyChar)이 Enter(=13)이면
            {
                TxtPassword.Focus(); // 패스워트 Txt창으로 포커스이동
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 키보드를 입력(KeyPress)한 값(KeyChar)이 Enter(=13)이면
            {
                BtnOk_Click(sender, e); // BtnLoging_Click 이벤트핸들러 실행
            }
        }
    }
}
