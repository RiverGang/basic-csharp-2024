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

namespace WinFormsApp1
{
    public partial class PopPlayerList : MetroForm

    {
        public PopPlayerList()
        {
            InitializeComponent();
        }

        private void PopPlayerList_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
            {
                conn.Open();

                var query = @"SELECT p.playerBacknumber
	                               , p.playerName
	                               , t.[teamName]
                                FROM TeamInfotbl AS t
                                JOIN Palyertbl AS p
                                  ON t.teamIdx = p.teamIdx;
                            ";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Palyertbl");

                DgvPlayerList.DataSource = ds.Tables[0];
                DgvPlayerList.ReadOnly = true; // 수정불가
                DgvPlayerList.Columns[0].HeaderText = "등번호";
                DgvPlayerList.Columns[1].HeaderText = "선수 이름";
                DgvPlayerList.Columns[2].HeaderText = "소속팀 코드";
                // 각 컬럼의 넓이 지정
                DgvPlayerList.Columns[0].Width = 60;
                DgvPlayerList.Columns[1].Width = 110;
                DgvPlayerList.Columns[2].Width = 60;

            }

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (DgvPlayerList.SelectedRows == null) { MessageBox.Show("선수를 선택하세요"); return; }

            var selData = DgvPlayerList.SelectedRows[0];
            Helper.Common.SelBackNumber = selData.Cells[0].Value.ToString();
            Helper.Common.SelPlayerName = selData.Cells[1].Value.ToString();
            Helper.Common.SelTeamName = selData.Cells[2].Value.ToString();



            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void DgvPlayerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
