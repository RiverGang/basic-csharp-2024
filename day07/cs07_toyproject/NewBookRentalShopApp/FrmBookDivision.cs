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
    public partial class FrmBookDivision : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookDivision()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT Division
                                   , Names
                                FROM divtbl";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "divtbl");

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                DgvResult.Columns[0].HeaderText = "장르 코드";
                DgvResult.Columns[1].HeaderText = "장르명";

            }
        } // 로그인사용자 목록 데이터 업데이트 메소드  

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.Focus(); // 입력창 포커스 Id
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation Check)
            // 순번, 이름, 패스워드를 넣지 않으면 저장버튼이 눌리지 않도록

            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                MessageBox.Show("장르 코드를 입력하세요");
                return;
            }
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("장르명을 입력하세요");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();
                    var query = "";
                    if (isNew) // INSERT문 실행 ==> BtnNew 버튼을 눌러야 isNew의 값이 True
                    {
                        query = @"INSERT INTO divtbl
                                            ( Division
                                            , Names)
                                       VALUES
                                            ( @Division
                                            , @Names)";
                    }
                    else // UPDATE문 실행
                    { 
                        query = @"UPDATE divtbl
                                     SET Names = @Names
                                   WHERE Division = @Division"; 
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmDivision = new SqlParameter("Division", TxtDivision.Text);
                    SqlParameter prmNames = new SqlParameter(@"Names", TxtNames.Text);
                
                    // Command에 Parameter를 연결해줘야함
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

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

            TxtDivision.Text = TxtNames.Text = string.Empty;
            RefreshData(); // 신규데이터 업데이트
        }


        // Dgv 로그인사용자 목록 표를 클릭하면
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무 것도 선택하지 않는 것이 -1 ===> 즉, 어떤 것이라도 클릭되면
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 값의 행인덱스(RowIndex)를 받아온다
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true;

                isNew = false; // UPDATA

            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDivision.Text)) // 장르코드가 없으면 
            {
                MetroMessageBox.Show(this, "삭제할 장르 코드를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) { return; }

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM divtbl WHERE Division = @Division";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmDivision = new SqlParameter("@Division", TxtDivision.Text);
                cmd.Parameters.Add(prmDivision);

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

            TxtDivision.Text = TxtNames.Text = string.Empty;
            RefreshData(); // 데이터그리드 재조회
        }

    }
}
