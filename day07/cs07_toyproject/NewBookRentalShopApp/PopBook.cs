using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewBookRentalShopApp
{
    public partial class PopBook : MetroForm
    {
        public PopBook()
        {
            InitializeComponent();
        }

        private void PopMember_Load(object sender, EventArgs e)
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

        }

        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 구현할 거 없음
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvResult.SelectedRows == null) { MessageBox.Show("도서를 선택하세요"); return; }
            
            var selData = DgvResult.SelectedRows[0];
            //MessageBox.Show(selData.Cells[0].Value.ToString() + selData.Cells[1].Value.ToString());
            Helper.Common.SelBookIdx = selData.Cells[0].Value.ToString();
            Helper.Common.SelBookName = selData.Cells[1].Value.ToString();

            this.DialogResult = DialogResult.Yes; // DialogResult 발생시킴
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 창 바로 닫기
        }
    }
}
