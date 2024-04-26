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
        bool InOut = false; // ���/�ƿ�
        public string OutPosition = string.Empty; // ���(F), ���ε���̺�(L), ����(K)
        Label LblBase = new Label();

        public FrmRecord()
        {

            InitializeComponent();

        }
        private void FrmRecord_Load(object sender, EventArgs e)
        {

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.StartPosition = FormStartPosition.CenterScreen;
            frmLogin.TopMost = true; // ������ȭ�� ���� ��ܿ�.
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
            } // Ŭ���� ���̽�����̹����� ���� ����
        }
        private void InitInputBattingNumber() // Ÿ�� �޺��ڽ� ������ ����Ʈ
        {
            try
            {
                var temp = new Dictionary<int, string>();

                temp.Add(1, "1�� Ÿ��");
                temp.Add(2, "2�� Ÿ��");
                temp.Add(3, "3�� Ÿ��");
                temp.Add(4, "4�� Ÿ��");
                temp.Add(5, "5�� Ÿ��");
                temp.Add(6, "6�� Ÿ��");
                temp.Add(7, "7�� Ÿ��");
                temp.Add(8, "8�� Ÿ��");
                temp.Add(9, "9�� Ÿ��");

                CboBetterNum.DataSource = new BindingSource(temp, null);
                CboBetterNum.DisplayMember = "Value";
                CboBetterNum.ValueMember = "Key";
                CboBetterNum.SelectedIndex = -1;

            }
            catch (Exception)
            {

            }
        }
        private void InitInputInningList() // Ÿ�� �޺��ڽ� ������ ����Ʈ
        {
            try
            {
                var temp = new Dictionary<int, string>();

                temp.Add(1, "1ȸ��");
                temp.Add(2, "2ȸ��");
                temp.Add(3, "3ȸ��");
                temp.Add(4, "4ȸ��");
                temp.Add(5, "5ȸ��");
                temp.Add(6, "6ȸ��");
                temp.Add(7, "7ȸ��");
                temp.Add(8, "8ȸ��");
                temp.Add(9, "9ȸ��");

                CboInning.DataSource = new BindingSource(temp, null);
                CboInning.DisplayMember = "Value";
                CboInning.ValueMember = "Key";
                CboInning.SelectedIndex = -1;

            }
            catch (Exception)
            {

            }
        }


        // �ʱ�ȭ
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

        //Ÿ�� ����� �޼���
        public void OnBaseRecord(int num)
        {
            BaseChange();
            if (basePic == 1)
            {
                PicBase1.Image = PicBase2.Image = PicBase3.Image = PicBase4.Image = null;

                switch (num)
                {
                    case 0: // ����
                        LblBase1.Text = "B";
                        break;

                    case 1: // 1��Ÿ
                        PicBase1.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base1.png";
                        break;

                    case 2: // 2��Ÿ
                        PicBase1.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base1.png";
                        PicBase2.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base2.png";
                        break;

                    case 3: // 3��Ÿ
                        PicBase1.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base1.png";
                        PicBase2.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base2.png";
                        PicBase3.ImageLocation = "C:\\Sources\\portfolio\\WinFormsApp1\\WinFormsApp1\\images\\base3.png";
                        break;

                    case 4: // Ȩ��
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
            SpcPlay.Panel1.Enabled = false; // Ÿ�� ���׷�ڽ� ��Ȱ��ȭ

        }


        //Ÿ�� ���� ��� �޼���
        public void BallDirectionRecord(int num)
        {
            BaseChange();
            if (InOut == true) // ���
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

            else if (InOut == false) // �ƿ�
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

        #region "���� ����Ȳ Btn"
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

        // ��ϼ��� ValueCheck �޼����ڽ�
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
                var res = MessageBox.Show(this, $"Base{basePic}�� ����� �����Ͻðڽ��ϱ�?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        #region "��Ϲڽ�/��Ϲڽ� �� Ŭ�� �̺�Ʈ�ڵ鷯"
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
        // �ƿ�ī��Ʈ �̹���Ŭ�� �ڵ鷯
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

        // "Ÿ�� ���� üũ�ڽ� Ŭ�� �̺�Ʈ�ڵ鷯"
        #region "Ÿ�� ���� üũ�ڽ� �̺�Ʈ�ڵ鷯"
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
            SpcPlay.Panel1.Enabled = true; // Ÿ�� ���׷�ڽ� Ȱ��ȭ
            this.InOut = true;
        }


        private void BtnBatterOut_Click(object sender, EventArgs e)
        {
            SpcPlay.Panel2.Enabled = true; // Ÿ�� �ƿ��׷�ڽ� Ȱ��ȭ
            this.InOut = false;
        }

        #region "�ƿ���Ȳ Btn"
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

        private void BtnRunnerPlay_Click(object sender, EventArgs e) // ���� ���
        {
            GrbRunnerSelect.Enabled = true;
            this.InOut = true;
        }

        private void BtnRunnerOut_Click(object sender, EventArgs e) // ���� �ƿ�
        {
            this.InOut = false;
        }

        // Ÿ����Ȳ �޺��ڽ� ���� �̺�Ʈ�ڵ鷯
        private void CboBetterNum_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BaseChange();
            if (RbtBaseStill.Checked == true)
            {
                LblBase.Text = $"S{CboBetterNum.SelectedIndex + 1}";

            }

            else if (RbtBaseScore.Checked == true)
            {
                string[] NumberScore = ["��", "��", "��", "��", "��", "��", "��", "��", "��"];
                for (int i = 0; i < NumberScore.Length; i++)
                {
                    if (i == CboBetterNum.SelectedIndex) { LblBase.Text = $"{NumberScore[i]}"; }
                }
            }

            else
            {
                string[] NumberChina = ["(��)", "(�)", "(߲)", "(��)", "(��)", "(׿)", "(��)", "(��)", "(��)"];
                for (int i = 0; i < NumberChina.Length; i++)
                {
                    if (i == CboBetterNum.SelectedIndex) { LblBase.Text = $"{NumberChina[i]}"; }
                }
            }
        }


        #region "��� State�� �ؽ�Ʈ ��ȭ �̺�Ʈ�ڵ鷯"
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
           if (e.RowIndex > -1) // �ƹ� �͵� �������� �ʴ� ���� -1 ===> ��, � ���̶� Ŭ���Ǹ�
            {
                var Data = DgvBattingOrder.SelectedRows[0];
                sLblBattingNum.Text = Data.Cells[0].Value.ToString() + "�� Ÿ��:";
                sLblPlayerName.Text = Data.Cells[2].Value.ToString();
                sLblTeamName.Text = Helper.Common.SelTeamName;
            }
        }
    }
}
