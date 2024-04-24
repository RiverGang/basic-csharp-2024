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
    public partial class FrmBookRental : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookRental()
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
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT r.rentalIdx
                                  ,r.memberIdx
	                              ,m.Names AS memNames
                                  ,r.bookIdx
	                              ,b.Names AS bookNames
                                  ,r.rentalDate
                                  ,r.returnDate
                              FROM rentaltbl AS r
                              JOIN membertbl AS m
                                ON r.memberIdx = m.memberIdx
                              JOIN bookstbl AS b
                                ON r.bookIdx = b.bookIdx";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "rentaltbl");

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                DgvResult.Columns[0].HeaderText = "대출 번호";
                DgvResult.Columns[1].HeaderText = "회원 번호";
                DgvResult.Columns[2].HeaderText = "회원명";
                DgvResult.Columns[3].HeaderText = "책 번호";
                DgvResult.Columns[4].HeaderText = "책제목";
                DgvResult.Columns[5].HeaderText = "대출일";
                DgvResult.Columns[6].HeaderText = "반납일";

            }
        } // 로그인사용자 목록 데이터 업데이트 메소드  

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtRentalIdx.Text = TxtMemberIdx.Text = TxtBookIdx.Text = string.Empty;
            TxtMemNames.Text = TxtBookNames.Text = string.Empty;
            DtpReturnDate.Value = DtpRentalDate.Value = DateTime.Now;
            TxtRentalIdx.Focus(); // 입력창 포커스 Id
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation Check)
            // 출판일은 기본으로 오늘 날짜가 들어감, ISBN은 Null 가능, 책가격도 기본 0
            if (string.IsNullOrEmpty(TxtMemNames.Text))
            {
                MessageBox.Show("회원명을 선택하세요");
                return;
            }
            if (string.IsNullOrEmpty(TxtBookNames.Text))
            {
                MessageBox.Show("대출할 책을 선택하세요");
                return;
            }

            // 반납일이 1800-01-01 이면, 반납일에 null 입력


            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();
                    var query = "";
                    if (isNew) // INSERT문 실행 ==> BtnNew 버튼을 눌러야 isNew의 값이 True
                    {
                        query = @"INSERT INTO [dbo].[rentaltbl]
                                          ( [memberIdx]
                                          , [bookIdx]
                                          , [rentalDate]
                                          , [returnDate])
                                     VALUES
                                          ( @memberIdx
                                          , @bookIdx
                                          , @rentalDate
                                          , @returnDate)";
                    }
                    else // UPDATE문 실행
                    { 
                        query = @"UPDATE [dbo].[rentaltbl]
                                       SET [memberIdx] = @memberIdx
                                          ,[bookIdx] = @bookIdx
                                          ,[rentalDate] = @rentalDate
                                          ,[returnDate] = @returnDate
                                     WHERE rentalIdx = @rentalIdx"; 
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmMemberIdx = new SqlParameter(@"memberIdx", TxtMemberIdx.Text);
                    cmd.Parameters.Add(prmMemberIdx);
                    SqlParameter prmBookIdx = new SqlParameter(@"bookIdx", TxtBookIdx.Text);
                    cmd.Parameters.Add(prmBookIdx);
  
                    SqlParameter prmRentalDate = new SqlParameter(@"rentalDate", DtpRentalDate.Value);
                    cmd.Parameters.Add(prmRentalDate);

                    // 반납날짜 추가처리
                    var returnDate = "";
                    if (DtpReturnDate.Value <= DtpRentalDate.Value) // 대출일과 반납일 비교
                    {
                        returnDate = ""; //대출(Rental)이 더크면 null;
                    }
                    else
                    {
                        returnDate = DtpReturnDate.Value.ToString("yyyy-MM-dd");
                    }
                    SqlParameter prmReturnDate = new SqlParameter("@returnDate", returnDate);
                    cmd.Parameters.Add(prmReturnDate);



                    if(isNew != true)
                    {
                        SqlParameter prmRentalIdx = new SqlParameter("@RentalIdx", TxtRentalIdx.Text);
                        cmd.Parameters.Add(prmRentalIdx);
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

            TxtRentalIdx.Text = TxtMemNames.Text = TxtBookNames.Text = string.Empty;
            DtpReturnDate.Value = DateTime.Now;

            RefreshData(); // 신규데이터 업데이트
        }


        // Dgv 로그인사용자 목록 표를 클릭
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무 것도 선택하지 않는 것이 -1 ===> 즉, 어떤 것이라도 클릭되면
            {
                var selData = DgvResult.Rows[e.RowIndex];
                TxtRentalIdx.Text = selData.Cells[0].Value.ToString(); // 대출번호
                TxtMemberIdx.Text = selData.Cells[1].Value.ToString(); // 회원번호
                TxtMemNames.Text = selData.Cells[2].Value.ToString(); // 회원명
                TxtBookIdx.Text = selData.Cells[3].Value.ToString(); // 책번호
                TxtBookNames.Text = selData.Cells[4].Value.ToString(); // 책제목
                DtpRentalDate.Value = DateTime.Parse(selData.Cells[5].Value.ToString()); // 대출일
                DtpReturnDate.Value = !string.IsNullOrEmpty(selData.Cells[6].Value.ToString()) ? DateTime.Parse(selData.Cells[6].Value.ToString()) :
                                                                       DateTime.Parse("1800-01-01"); // 반납을 하지 않은 날짜
                
                isNew = false; // UPDATA

            }
        }

        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            PopMember popup = new PopMember();
            popup.StartPosition = FormStartPosition.CenterParent;
            if(popup.ShowDialog() == DialogResult.Yes)
            {
                TxtMemberIdx.Text = Helper.Common.SelMemberIdx;
                TxtMemNames.Text = Helper.Common.SelMemberName;
            }


        }

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            PopBook popup = new PopBook();
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.Yes)
            {
                TxtBookIdx.Text = Helper.Common.SelBookIdx;
                TxtBookNames.Text = Helper.Common.SelBookName;
            }
        }
    }
}
