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
    public partial class FrmMember : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmMember()
        {
            InitializeComponent();
        }

        private void FrmLoginUser_Load(object sender, EventArgs e)
        {
            RefreshData(); // bookstbl에서 데이터를 가져오는 부분

            // 콤보박스에 들어가는 데이터를 초기화
            InitInputData(); // 콤보박스, 날짜, NumericUpDown 컨트롤 데이터, 초기화
        }

        private void InitInputData()
        {
            try
            {
                var  temp = new Dictionary<string, string>();
                
                temp.Add("A", "A");
                temp.Add("B", "B");
                temp.Add("C", "C");
                temp.Add("D", "D");

                CboLevels.DataSource = new BindingSource(temp, null);
                CboLevels.DisplayMember = "Value";
                CboLevels.ValueMember = "Key"; 
                CboLevels.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

            }
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT [memberIdx]
                                   , [Names]
                                   , [Levels]
                                   , [Addr]
                                   , [Mobile]
                                   , [Email]
                                FROM [membertbl]";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "membertbl");

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                DgvResult.Columns[0].HeaderText = "회원번호";
                DgvResult.Columns[1].HeaderText = "회원명";
                DgvResult.Columns[2].HeaderText = "등급";
                DgvResult.Columns[3].HeaderText = "주소";
                DgvResult.Columns[4].HeaderText = "전화번호";
                DgvResult.Columns[5].HeaderText = "이메일";
                // 각 컬럼의 넓이 지정
                DgvResult.Columns[0].Width = 80;
                DgvResult.Columns[1].Width = 80;
                DgvResult.Columns[2].Width = 70;
                DgvResult.Columns[3].Width = 200;
                DgvResult.Columns[4].Width = 100; // 장르코드 열 숨김
                DgvResult.Columns[5].Width = 150;

            }
        } // 로그인사용자 목록 데이터 업데이트 메소드  

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtMemberIdx.Text = TxtNames.Text = TxtAddr.Text = TxtEmail.Text = string.Empty;
            CboLevels.SelectedIndex = -1;
            TxtMemberIdx.Focus(); // 입력창 포커스 Id
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation Check)
            // 출판일은 기본으로 오늘 날짜가 들어감, ISBN은 Null 가능, 책가격도 기본 0
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("회원명을 입력하세요");
                return;
            }
            if (string.IsNullOrEmpty(TxtAddr.Text))
            {
                MessageBox.Show("주소를 입력하세요");
                return;
            }
            if (CboLevels.SelectedIndex < 0)
            {
                MessageBox.Show("등급을 선택하세요");
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
                        query = @"INSERT INTO [membertbl]
                                               ([Names]
                                               ,[Levels]
                                               ,[Addr]
                                               ,[Mobile]
                                               ,[Email])
                                         VALUES
                                               (@Names
                                               ,@Levels
                                               ,@Addr
                                               ,@Mobile
                                               ,@Email)";
                    }
                    else // UPDATE문 실행
                    { 
                        query = @"UPDATE [membertbl]
                                           SET [Names] = @Names
                                              ,[Levels] = @Levels
                                              ,[Addr] = @Addr
                                              ,[Mobile] = @Mobile
                                              ,[Email] = @Email
                                         WHERE memberIdx = @memberIdx"; 
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmNames = new SqlParameter(@"Names", TxtNames.Text);
                    cmd.Parameters.Add(prmNames);
                    SqlParameter prmAddr = new SqlParameter(@"Addr", TxtAddr.Text);
                    cmd.Parameters.Add(prmAddr);
                    SqlParameter prmLevels = new SqlParameter(@"Levels", CboLevels.SelectedValue);
                    cmd.Parameters.Add(prmLevels);
                    SqlParameter prmMobile = new SqlParameter(@"Mobile", TxtMobile.Text);
                    cmd.Parameters.Add(prmMobile);
                    SqlParameter prmEmail = new SqlParameter(@"Email", TxtEmail.Text);
                    cmd.Parameters.Add(prmEmail);

                    if(isNew != true)
                    {
                        SqlParameter prmMemberIdx = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                        cmd.Parameters.Add(prmMemberIdx);
                    }

                    // Command에 Parameter를 연결해줘야함
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

            TxtMemberIdx.Text = TxtNames.Text = TxtAddr.Text = TxtEmail.Text = string.Empty;
            CboLevels.SelectedIndex = -1;
                
            RefreshData(); // 신규데이터 업데이트
        }


        // Dgv 로그인사용자 목록 표를 클릭하면
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무 것도 선택하지 않는 것이 -1 ===> 즉, 어떤 것이라도 클릭되면
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 값의 행인덱스(RowIndex)를 받아온다
                TxtMemberIdx.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                CboLevels.SelectedValue = selData.Cells[2].Value;
                TxtAddr.Text = selData.Cells[3].Value.ToString();
                TxtMobile.Text = selData.Cells[4].Value.ToString();
                TxtEmail.Text = selData.Cells[5].Value.ToString();

                isNew = false; // UPDATA

            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMemberIdx.Text)) // 장르코드가 없으면 
            {
                MetroMessageBox.Show(this, "삭제할 회원을 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) { return; }

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM membertbl WHERE memberIdx = @memberIdx";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmMember = new SqlParameter("@memberIdx", TxtMemberIdx.Text);
                cmd.Parameters.Add(prmMember);

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

            TxtMemberIdx.Text = TxtNames.Text = TxtAddr.Text = TxtEmail.Text = TxtMobile.Text = string.Empty;
            CboLevels.SelectedIndex = -1;
            RefreshData(); // 데이터그리드 재조회
        }

    }
}
