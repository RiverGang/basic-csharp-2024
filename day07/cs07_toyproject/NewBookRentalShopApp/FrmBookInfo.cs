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
    public partial class FrmBookInfo : MetroForm
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        public FrmBookInfo()
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
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    conn.Open();
                    var query = @"SELECT Division, Names FROM divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, object>();

                    while (reader.Read())
                    {
                        // Key, Value
                        // B001, 공포/스릴러
                        // readerp[0] = Division컬럼, reader[1] = Names 컬럼
                        temp.Add(reader[0].ToString(), reader[1].ToString());
                    }

                    Debug.WriteLine(temp.Count);
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value"; // 공포/스릴러 표시
                    CboDivision.ValueMember = "Key"; // B001
                    CboDivision.SelectedIndex = -1;
                }

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

                var query = @"SELECT [bookIdx]
                                   , b.Names 
                                   , [Author]
                                   , d.Names as DivNames
                                   , d.Division
                                   , [ReleaseDate]
                                   , [ISBN]
                                   , [Price]
                                FROM bookstbl as b
                                JOIN divtbl as d
                                  ON b.Division = d.Division
                            ";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "booktbl");

                DgvResult.DataSource = ds.Tables[0];
                DgvResult.ReadOnly = true; // 수정불가
                DgvResult.Columns[0].HeaderText = "책순번";
                DgvResult.Columns[1].HeaderText = "책제목";
                DgvResult.Columns[2].HeaderText = "저자";
                DgvResult.Columns[3].HeaderText = "장르";
                DgvResult.Columns[4].HeaderText = "장르코드";
                DgvResult.Columns[5].HeaderText = "출판일";
                DgvResult.Columns[6].HeaderText = "ISBN";
                DgvResult.Columns[7].HeaderText = "책가격";
                // 각 컬럼의 넓이 지정
                DgvResult.Columns[0].Width = 80;
                DgvResult.Columns[1].Width = 200;
                DgvResult.Columns[2].Width = 150;
                DgvResult.Columns[3].Width = 80;
                DgvResult.Columns[4].Visible = false; // 장르코드 열 숨김
                DgvResult.Columns[5].Width = 100;
                DgvResult.Columns[6].Width = 120;
                DgvResult.Columns[7].Width = 80;






            }
        } // 로그인사용자 목록 데이터 업데이트 메소드  

        private void BtnNew_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtBookIdx.Text = TxtNames.Text = TxtAuthor.Text = TxtISBN.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now;
            NudPirce.Value = 0;
            TxtBookIdx.Focus(); // 입력창 포커스 Id
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 입력검증(Validation Check)
            // 출판일은 기본으로 오늘 날짜가 들어감, ISBN은 Null 가능, 책가격도 기본 0
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                MessageBox.Show("책제목을 입력하세요");
                return;
            }
            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                MessageBox.Show("저자를 입력하세요");
                return;
            }
            if (CboDivision.SelectedIndex < 0)
            {
                MessageBox.Show("장르를 선택하세요");
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
                        query = @"INSERT INTO [dbo].[bookstbl]
                                            ( [Author]
                                            , [Division]
                                            , [Names]
                                            , [ReleaseDate]
                                            , [ISBN]
                                            , [Price])
                                       VALUES
                                            ( @Author
                                            , @Division
                                            , @Names
                                            , @ReleaseDate
                                            , @ISBN
                                            , @Price)";
                    }
                    else // UPDATE문 실행
                    { 
                        query = @"UPDATE [bookstbl]
                                     SET [Author] = @Author
                                       , [Division] = @Division
                                       , [Names] = @Names
                                       , [ReleaseDate] = @ReleaseDate
                                       , [ISBN] = @ISBN
	                                   , [Price] = @Price
                                   WHERE bookIdx = @bookIdx"; 
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmNames = new SqlParameter(@"Names", TxtNames.Text);
                    cmd.Parameters.Add(prmNames);
                    SqlParameter prmAuthor = new SqlParameter(@"Author", TxtAuthor.Text);
                    cmd.Parameters.Add(prmAuthor);
                    SqlParameter prmDivision = new SqlParameter(@"Division", CboDivision.SelectedValue);
                    cmd.Parameters.Add(prmDivision);
                    SqlParameter prmReleaseDate = new SqlParameter(@"ReleaseDate", DtpReleaseDate.Value);
                    cmd.Parameters.Add(prmReleaseDate);
                    SqlParameter prmISBN = new SqlParameter(@"ISBN", TxtISBN.Text);
                    cmd.Parameters.Add(prmISBN);
                    SqlParameter prmPrice = new SqlParameter(@"Price", NudPirce.Value);
                    cmd.Parameters.Add(prmPrice);
                    if(isNew != true)
                    {
                        SqlParameter prmBookIdx = new SqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
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

            TxtBookIdx.Text = TxtNames.Text = TxtAuthor.Text = TxtISBN.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now;
            NudPirce.Value = 0;

            RefreshData(); // 신규데이터 업데이트
        }


        // Dgv 로그인사용자 목록 표를 클릭하면
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무 것도 선택하지 않는 것이 -1 ===> 즉, 어떤 것이라도 클릭되면
            {
                var selData = DgvResult.Rows[e.RowIndex]; // 내가 선택한 값의 행인덱스(RowIndex)를 받아온다
                TxtBookIdx.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtAuthor.Text = selData.Cells[2].Value.ToString();
                DtpReleaseDate.Value = DateTime.Parse(selData.Cells[5].Value.ToString());
                // "2019-03-09" 문자열을 DateTime.Parse()로
                // DateTime형변환
                TxtISBN.Text = selData.Cells[6].Value.ToString();
                NudPirce.Value = Decimal.Parse(selData.Cells[7].Value.ToString());
                // "20000" 가격을 숫자형으로 형변환
                // 거의 모든 타입에 *.Parse(string) 메서드가 존재
                TxtBookIdx.ReadOnly = true;


                // 콤보박스는 맨 마지막에
                CboDivision.SelectedValue = selData.Cells[4].Value; // 구분코드로 선택해야함

                isNew = false; // UPDATA

            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBookIdx.Text)) // 장르코드가 없으면 
            {
                MetroMessageBox.Show(this, "삭제할 장르 코드를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var answer = MetroMessageBox.Show(this, "정말 삭제하시겠습니까?", "삭제여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No) { return; }

            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();
                var query = @"DELETE FROM bookstbl WHERE BookIdx = @BookIdx";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter prmDivision = new SqlParameter("@BookIdx", TxtBookIdx.Text);
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

            TxtBookIdx.Text = TxtNames.Text = TxtAuthor.Text = TxtISBN.Text = string.Empty;
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now;
            NudPirce.Value = 0;
            RefreshData(); // 데이터그리드 재조회
        }

    }
}
