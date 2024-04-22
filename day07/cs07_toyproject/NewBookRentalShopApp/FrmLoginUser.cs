using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmLoginUser : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        private string connString = "Data Source=localhost;Initial Catalog=BookRentalShop2024;" +
                                   "Persist Security Info=True;User ID=sa;Encrypt=False;Password=mssql_p@ss";
        public FrmLoginUser()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                var query = @"SELECT userIdx
                                   , userId
                                   , [password]
                                   , lastLoginDateTime
                                FROM Usertbl";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Usertbl");

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                DgvResult.Columns[0].HeaderText = "사용자번호";
                DgvResult.Columns[1].HeaderText = "사용자아이디";
                DgvResult.Columns[2].HeaderText = "패스워드";
                DgvResult.Columns[3].HeaderText = "마지막 로그인 날짜";

            }
        } // 로그인사용자 목록 데이터 업데이트 메소드  

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtUserIndex.Text = TxtUserId.Text = TxtPassword.Text = string.Empty;
            TxtUserIndex.ReadOnly = true; // Idx는 자동으로 증가될 값이기에 처음부터 ReadOnly True
            TxtUserId.Focus(); // 입력창 포커스 Id
            TxtUserIndex.Text = TxtUserId.Text = TxtPassword.Text = string.Empty;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var md5Hash = MD5.Create(); //MD5 암호화용 객체 생성

            // 입력검증(Validation Check)
            // 순번, 이름, 패스워드를 넣지 않으면 저장버튼이 눌리지 않도록

            if (string.IsNullOrEmpty(TxtUserId.Text))
            {
                MessageBox.Show("사용자 아이디를 입력하세요");
                return;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("패스워드를 입력하세요");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    var query = "";
                    if (isNew) // INSERT문 실행 ==> BtnNew 버튼을 눌러야 isNew의 값이 True
                    {
                        query = @"INSERT INTO Usertbl
		                              ( userId
                                      , [password]
		                              )

                                 VALUES
                                      ( @userId
                                      , @password
		                              )";
                    }
                    else // UPDATE문 실행
                    { 
                        query = @"UPDATE Usertbl
                                     SET userId = @userId
                                       , [password] = @password
                                   WHERE userIdx = @userIdx
                                    "; 
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if(isNew == false) // UPDATE에만 userIdx 사용
                    {
                        SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIndex.Text);
                        cmd.Parameters.Add(prmUserIdx);
                    } 

                    SqlParameter prmUserID = new SqlParameter("@userId", TxtUserId.Text);
                    SqlParameter prmPassword = new SqlParameter(@"password", GetMd5Hash(md5Hash, TxtPassword.Text));
                
                    // Command에 Parameter를 연결해줘야함
                    cmd.Parameters.Add(prmUserID);
                    cmd.Parameters.Add(prmPassword);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(this, "저장성공", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this,"저장실패", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TxtUserIndex.Text = TxtUserId.Text = TxtPassword.Text = string.Empty;
            RefreshData(); // 신규데이터 업데이트
        }


        // Dgv 로그인사용자 목록 표를 클릭하면
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무 것도 선택하지 않는 것이 -1 ===> 즉, 어떤 것이라도 클릭되면
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 값의 행인덱스(RowIndex)를 받아온다
                TxtUserIndex.ReadOnly = true;
                TxtUserIndex.Text = selData.Cells[0].Value.ToString(); 
                TxtUserId.Text = selData.Cells[1].Value.ToString();
                TxtPassword.Text = selData.Cells[2].Value.ToString();

                isNew = false; // UPDATA

            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserIndex.Text)) // 사용자 아이디 순번이 없으면 
            {
                MetroMessageBox.Show(this, "삭제할 사용자를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) { return; }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = @"DELETE FROM Usertbl WHERE userIdx = @userIdx";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmUserIdx = new SqlParameter("@userIdx", TxtUserIndex.Text);
                cmd.Parameters.Add(prmUserIdx);

                var result = cmd.ExecuteNonQuery();

               
                if(result > 0) 
                {
                    MetroMessageBox.Show(this, "삭제성공", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MetroMessageBox.Show(this, "삭제실패", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            TxtUserIndex.Text = TxtUserId.Text = TxtPassword.Text = string.Empty;
            RefreshData(); // 데이터그리드 재조회
        }
    //MD5 해시 알고리즘 암호화
    // 1234 --> 0101101 -> 110010101101011 -> x65xAEx11...

        string GetMd5Hash(MD5 md5Hash, string input)
        {
            // 입력문자열을 byte배열로 변환한 뒤 MD5 해시 처리
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
