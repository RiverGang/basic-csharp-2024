using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace WinFormsApp1
{
    public partial class FrmRecord : MetroForm
    {
        int basePic = 0;
        bool InOut = false; // 출루/아웃
        public string OutPosition = string.Empty; // 뜬공(F), 라인드라이브(L), 삼진(K)
        Label LblBase = new Label();

        public FrmRecord()
        {

            InitializeComponent();

        }
        private void FrmRecord_Load(object sender, EventArgs e)
        {

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.StartPosition = FormStartPosition.CenterScreen;
            frmLogin.TopMost = true; // 윈도우화면 가장 상단에.
            frmLogin.ShowDialog();
            LblLoginID.Text = Helper.Common.LoginId;
            //DgvBattingOrder.RowCount = 9;
            for(int i = 0; i<9; i++)
            {
                DgvBattingOrder.Rows.Add($"{i+1}");
            }
            InitInputBattingNumber();
            InitInputInningList();


            LblBase1.Parent = PicBase1;
            LblBase2.Parent = PicBase2;
            LblBase3.Parent = PicBase3;
            LblBase4.Parent = PicBase4;

            LblBase1.BackColor = LblBase2.BackColor = LblBase3.BackColor = LblBase4.BackColor = Color.Transparent;
            LblBase1.Location = new Point(15, 35);
            LblBase2.Location = new Point(15, 5);
            LblBase3.Location = new Point(0, 5);
            LblBase4.Location = new Point(0, 35);
        }

        public void BaseChange()
        {
            switch (this.basePic)
            {
                case 1:
                    this.LblBase = LblBase1;
                    break;

                case 2:
                    this.LblBase = LblBase2;
                    break;
                case 3:
                    this.LblBase = LblBase3;
                    break;
                case 4:
                    this.LblBase = LblBase4;
                    break;
            } // 클릭한 베이스기록이미지에 따라 변경
        }
        private void InitInputBattingNumber() // 타순 콤보박스 데이터 리스트
        {
            try
            {
                var temp = new Dictionary<int, string>();

                temp.Add(1, "1번 타순");
                temp.Add(2, "2번 타순");
                temp.Add(3, "3번 타순");
                temp.Add(4, "4번 타순");
                temp.Add(5, "5번 타순");
                temp.Add(6, "6번 타순");
                temp.Add(7, "7번 타순");
                temp.Add(8, "8번 타순");
                temp.Add(9, "9번 타순");

                CboBetterNum.DataSource = new BindingSource(temp, null);
                CboBetterNum.DisplayMember = "Value";
                CboBetterNum.ValueMember = "Key";
                CboBetterNum.SelectedIndex = -1;

            }
            catch (Exception)
            {

            }
        }
        private void InitInputInningList() // 타순 콤보박스 데이터 리스트
        {
            try
            {
                var temp = new Dictionary<int, string>();

                temp.Add(1, "1회초");
                temp.Add(2, "2회초");
                temp.Add(3, "3회초");
                temp.Add(4, "4회초");
                temp.Add(5, "5회초");
                temp.Add(6, "6회초");
                temp.Add(7, "7회초");
                temp.Add(8, "8회초");
                temp.Add(9, "9회초");

                CboInning.DataSource = new BindingSource(temp, null);
                CboInning.DisplayMember = "Value";
                CboInning.ValueMember = "Key";
                CboInning.SelectedIndex = -1;

            }
            catch (Exception)
            {

            }
        }


        // 초기화
        public void Reset()
        {
            GrbRunnerSelect.Enabled = false;
            CboBetterNum.SelectedIndex = -1;
            SpcPlay.Panel1.Enabled = SpcPlay.Panel2.Enabled = false;
            LblBallDirection.Text = string.Empty;
            CheckBox[] checkbox = [CboxNum1, CboxNum2, CboxNum3, CboxNum4, CboxNum5, CboxNum6, CboxNum7, CboxNum8, CboxNum9];
            foreach (CheckBox checkBox in checkbox)
            {
                checkBox.Checked = false;
            }
        }

        //타석 출루기록 메서드
        public void OnBaseRecord(int num)
        {
            BaseChange();
            if (basePic == 1)
            {
                PicBase1.Image = PicBase2.Image = PicBase3.Image = PicBase4.Image = null;

                switch (num)
                {
                    case 0: // 볼넷
                        LblBase1.Text = "B";
                        break;

                    case 1: // 1루타
                        PicBase1.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base1.png";
                        break;

                    case 2: // 2루타
                        PicBase1.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base1.png";
                        PicBase2.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base2.png";
                        break;

                    case 3: // 3루타
                        PicBase1.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base1.png";
                        PicBase2.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base2.png";
                        PicBase3.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base3.png";
                        break;

                    case 4: // 홈런
                        PicBase1.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base1.png";
                        PicBase2.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base2.png";
                        PicBase3.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base3.png";
                        PicBase4.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base4.png";
                        break;

                    case 5:
                        LblBase1.Text = "E";
                        break;
                }
            }
            SpcPlay.Panel1.Enabled = false; // 타자 출루그룹박스 비활성화

        }


        //타구 방향 기록 메서드
        public void BallDirectionRecord(int num)
        {
            BaseChange();
            if (InOut == true) // 출루
            {

                if (LblBase.Text != string.Empty)
                {
                    LblBase.Text += " * " + num.ToString();
                    LblBallDirection.Text += " * " + num.ToString();
                }
                else
                {
                    LblBase.Text = num.ToString();
                    LblBallDirection.Text = num.ToString();
                }
            }

            else if (InOut == false) // 아웃
            {
                if (LblBase.Text != string.Empty)
                {
                    LblBase.Text += " - " + num.ToString();
                    LblBallDirection.Text += " - " + num.ToString();
                }

                else
                {
                    if (this.OutPosition == "F")
                    {
                        LblBase.Text = "F" + num.ToString();
                        LblBallDirection.Text = num.ToString();
                    }

                    else if (this.OutPosition == "L")
                    {
                        LblBase.Text = "L-" + num.ToString();
                        LblBallDirection.Text = num.ToString();
                    }

                    else
                    {
                        LblBase.Text = num.ToString();
                        LblBallDirection.Text = num.ToString();
                    }
                }
            }

        }

        #region "주자 출루상황 Btn"
        private void BtnBall_Click(object sender, EventArgs e) { OnBaseRecord(0); }

        private void BtnBase1_Click(object sender, EventArgs e) { OnBaseRecord(1); }

        private void BtnBase2_Click(object sender, EventArgs e) { OnBaseRecord(2); }
        private void BtnBase3_Click(object sender, EventArgs e)
        {
            OnBaseRecord(3);

        }

        private void BtnHomerun_Click(object sender, EventArgs e)
        {
            OnBaseRecord(4);

        }

        private void BtnPlayerror_Click(object sender, EventArgs e)
        {
            OnBaseRecord(5);

        }

        #endregion

        // 기록수정 ValueCheck 메세지박스
        public void BaseValueCheck()
        {
            BaseChange();
            PictureBox picturebox = new PictureBox();
            PictureBox[] pic = [PicBase1, PicBase2, PicBase3, PicBase4];
            for (int i = 0; i < pic.Length; i++)
            {
                if (i + 1 == basePic) { picturebox = pic[i]; }
            }

            if (this.LblBase.Text != string.Empty | picturebox.Image != null)
            {
                var res = MessageBox.Show(this, $"Base{basePic}의 기록을 수정하시겠습니까?", "수정", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    if (basePic == 1)
                    {
                        foreach (var item in pic)
                        {
                            if (item.Image != null) { item.Image = null; }
                        }
                    }
                    picturebox.Image = null;
                    LblBase.Text = string.Empty;
                }
            }

        }

        #region "기록박스/기록박스 라벨 클릭 이벤트핸들러"
        //Base1
        private void PicBase1_Click(object sender, EventArgs e)
        {
            this.basePic = 1;
            BaseValueCheck();
            GrbBatter.Enabled = true;
            GrbRunner.Enabled = false;
            Reset();
        }
        private void LblBase1_Click(object sender, EventArgs e)
        {
            this.basePic = 1;
            BaseValueCheck();

            GrbBatter.Enabled = true;
            GrbRunner.Enabled = false;
            Reset();


        }
        //Base2
        private void PicBase2_Click(object sender, EventArgs e)
        {
            this.basePic = 2;
            BaseValueCheck();

            GrbBatter.Enabled = false;
            GrbRunner.Enabled = true;
            Reset();


        }
        private void LblBase2_Click(object sender, EventArgs e)
        {
            this.basePic = 2;
            BaseValueCheck();

            GrbBatter.Enabled = false;
            GrbRunner.Enabled = true;
            Reset();


        }

        private void PicBase3_Click(object sender, EventArgs e)
        {
            this.basePic = 3;
            GrbBatter.Enabled = false;
            GrbRunner.Enabled = true;
            Reset();


        }
        private void LblBase3_Click(object sender, EventArgs e)
        {
            this.basePic = 3;
            GrbBatter.Enabled = false;
            GrbRunner.Enabled = true;
            Reset();


        }


        private void PicBase4_Click(object sender, EventArgs e)
        {
            this.basePic = 4;
            GrbBatter.Enabled = false;
            GrbRunner.Enabled = true;
            Reset();


        }
        private void LblBase4_Click(object sender, EventArgs e)
        {
            this.basePic = 4;
            GrbBatter.Enabled = false;
            GrbRunner.Enabled = true;
            Reset();

        }
        // 아웃카운트 이미지클릭 핸들러
        private void PicOutCount_Click(object sender, EventArgs e)
        {
            TotalOutCount totalOutCount = new TotalOutCount();
            totalOutCount.StartPosition = FormStartPosition.CenterParent;
            totalOutCount.ShowDialog();

            if (Helper.Common.OutCount == 1)
            {
                PicOutCount.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\Out1.png";
            }
            else if (Helper.Common.OutCount == 2)
            {
                PicOutCount.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\Out2.png";
            }
            else if (Helper.Common.OutCount == 3)
            {
                PicOutCount.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\Out3.png";
            }
            else if (Helper.Common.OutCount == 0) { PicOutCount.Image = null; }

            PicOutCount.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        #endregion

        // "타구 방향 체크박스 클릭 이벤트핸들러"
        #region "타구 방향 체크박스 이벤트핸들러"
        private void CboxNum1_Click(object sender, EventArgs e)
        {
            if (CboxNum1.Checked) { BallDirectionRecord(1); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }

        private void CboxNum2_Click(object sender, EventArgs e)
        {
            if (CboxNum2.Checked) { BallDirectionRecord(2); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }
        private void CboxNum3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CboxNum3.Checked) { BallDirectionRecord(3); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }

        private void CboxNum4_CheckedChanged(object sender, EventArgs e)
        {
            if (CboxNum4.Checked) { BallDirectionRecord(4); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }
        private void CboxNum5_Click(object sender, EventArgs e)
        {
            if (CboxNum5.Checked) { BallDirectionRecord(5); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }
        private void CboxNum6_Click(object sender, EventArgs e)
        {
            if (CboxNum6.Checked) { BallDirectionRecord(6); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }

        private void CboxNum7_Click(object sender, EventArgs e)
        {
            if (CboxNum7.Checked) { BallDirectionRecord(7); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }

        private void CboxNum8_Click(object sender, EventArgs e)
        {
            if (CboxNum8.Checked) { BallDirectionRecord(8); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }

        private void CboxNum9_Click(object sender, EventArgs e)
        {
            if (CboxNum9.Checked) { BallDirectionRecord(9); }
            else { LblBase.Text = LblBallDirection.Text = string.Empty; }
        }
        #endregion


        private void BtnBatterPlay_Click(object sender, EventArgs e)
        {
            SpcPlay.Panel1.Enabled = true; // 타자 출루그룹박스 활성화
            this.InOut = true;
        }


        private void BtnBatterOut_Click(object sender, EventArgs e)
        {
            SpcPlay.Panel2.Enabled = true; // 타자 아웃그룹박스 활성화
            this.InOut = false;
        }

        #region "아웃상황 Btn"
        private void BtnGroundBall_Click(object sender, EventArgs e)
        {

        }

        private void BtnFlyBall_Click(object sender, EventArgs e)
        {

            this.OutPosition = "F";

        }

        private void BtnLineBall_Click(object sender, EventArgs e)
        {
            this.OutPosition = "L";
        }

        private void BtnStrikeOut_Click(object sender, EventArgs e)
        {
            if (this.basePic == 1)
            {
                LblBase1.Text = "K";
            }
        }
        #endregion

        private void BtnRunnerPlay_Click(object sender, EventArgs e) // 주자 출루
        {
            GrbRunnerSelect.Enabled = true;
            this.InOut = true;
        }

        private void BtnRunnerOut_Click(object sender, EventArgs e) // 주자 아웃
        {
            this.InOut = false;
        }

        // 타순상황 콤보박스 선택 이벤트핸들러
        private void CboBetterNum_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BaseChange();
            if (RbtBaseStill.Checked == true)
            {
                LblBase.Text = $"S{CboBetterNum.SelectedIndex + 1}";

            }

            else if (RbtBaseScore.Checked == true)
            {
                string[] NumberScore = ["①", "②", "③", "④", "⑤", "⑥", "⑦", "⑧", "⑨"];
                for (int i = 0; i < NumberScore.Length; i++)
                {
                    if (i == CboBetterNum.SelectedIndex) { LblBase.Text = $"{NumberScore[i]}"; }
                }
            }

            else
            {
                string[] NumberChina = ["(一)", "(二)", "(三)", "(四)", "(五)", "(六)", "(七)", "(八)", "(九)"];
                for (int i = 0; i < NumberChina.Length; i++)
                {
                    if (i == CboBetterNum.SelectedIndex) { LblBase.Text = $"{NumberChina[i]}"; }
                }
            }
        }


        #region "상단 State바 텍스트 변화 이벤트핸들러"
        private void CboInning_SelectedIndexChanged(object sender, EventArgs e)
        {
            sLblInning.Text = CboInning.Text;
        }
        #endregion

        private void DgvBattingOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selData = DgvBattingOrder.Rows[e.RowIndex];
            PopPlayerList popup = new PopPlayerList();
            popup.StartPosition = FormStartPosition.CenterParent;


            if(popup.ShowDialog() == DialogResult.Yes)
            {
                selData.Cells[1].Value = Helper.Common.SelBackNumber;
                selData.Cells[2].Value = Helper.Common.SelPlayerName;
            }
           if (e.RowIndex > -1) // 아무 것도 선택하지 않는 것이 -1 ===> 즉, 어떤 것이라도 클릭되면
            {
                var Data = DgvBattingOrder.SelectedRows[0];
                sLblBattingNum.Text = Data.Cells[0].Value.ToString() + "번 타자:";
                sLblPlayerName.Text = Data.Cells[2].Value.ToString();
                sLblTeamName.Text = Helper.Common.SelTeamName;
            }
        }
    }
}
