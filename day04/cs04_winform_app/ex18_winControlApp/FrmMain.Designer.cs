namespace ex18_winControlApp
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            CboFonts = new ComboBox();
            Chkltalic = new CheckBox();
            Chkbold = new CheckBox();
            label2 = new Label();
            TxtSamletxt = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            PrgDummy = new ProgressBar();
            TrbDummy = new TrackBar();
            groupBox3 = new GroupBox();
            BtnQuestion = new Button();
            BtnMsgBox = new Button();
            BtnModaless = new Button();
            BtnModal = new Button();
            groupBox4 = new GroupBox();
            BtnAddChild = new Button();
            BtnAddRoot = new Button();
            LsvDummy = new ListView();
            TrvDummy = new TreeView();
            groupBox5 = new GroupBox();
            BtbLoad = new Button();
            PicNomal = new PictureBox();
            DlgOpenImage = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicNomal).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CboFonts);
            groupBox1.Controls.Add(Chkltalic);
            groupBox1.Controls.Add(Chkbold);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TxtSamletxt);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("나눔고딕", 8.999999F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 135);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "콤보박스, 체크박스, 텍스트박스";
            // 
            // CboFonts
            // 
            CboFonts.Font = new Font("나눔고딕", 8.999999F);
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(66, 41);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(218, 22);
            CboFonts.TabIndex = 3;
            CboFonts.SelectedIndexChanged += CboFonts_SelectedIndexChanged;
            // 
            // Chkltalic
            // 
            Chkltalic.AutoSize = true;
            Chkltalic.Font = new Font("나눔고딕", 8.999999F, FontStyle.Italic);
            Chkltalic.Location = new Point(346, 43);
            Chkltalic.Name = "Chkltalic";
            Chkltalic.Size = new Size(59, 18);
            Chkltalic.TabIndex = 2;
            Chkltalic.Text = "이탤릭";
            Chkltalic.UseVisualStyleBackColor = true;
            Chkltalic.CheckedChanged += Chkltalic_CheckedChanged;
            // 
            // Chkbold
            // 
            Chkbold.AutoSize = true;
            Chkbold.Font = new Font("나눔고딕", 8.999999F, FontStyle.Bold);
            Chkbold.Location = new Point(290, 43);
            Chkbold.Name = "Chkbold";
            Chkbold.Size = new Size(48, 18);
            Chkbold.TabIndex = 2;
            Chkbold.Text = "굵게";
            Chkbold.UseVisualStyleBackColor = true;
            Chkbold.CheckedChanged += Chkbold_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔고딕", 8.999999F);
            label2.Location = new Point(26, 44);
            label2.Name = "label2";
            label2.Size = new Size(36, 14);
            label2.TabIndex = 0;
            label2.Text = "폰트 :";
            // 
            // TxtSamletxt
            // 
            TxtSamletxt.Font = new Font("나눔고딕", 8.999999F);
            TxtSamletxt.Location = new Point(26, 80);
            TxtSamletxt.Name = "TxtSamletxt";
            TxtSamletxt.Size = new Size(379, 21);
            TxtSamletxt.TabIndex = 1;
            TxtSamletxt.Text = "Hello, C#!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔고딕", 8.999999F);
            label1.Location = new Point(26, 44);
            label1.Name = "label1";
            label1.Size = new Size(41, 14);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(PrgDummy);
            groupBox2.Controls.Add(TrbDummy);
            groupBox2.Location = new Point(12, 153);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(426, 114);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "트랙바, 프로그레스바";
            // 
            // PrgDummy
            // 
            PrgDummy.Location = new Point(26, 73);
            PrgDummy.Maximum = 20;
            PrgDummy.Name = "PrgDummy";
            PrgDummy.Size = new Size(379, 23);
            PrgDummy.TabIndex = 1;
            // 
            // TrbDummy
            // 
            TrbDummy.Location = new Point(26, 22);
            TrbDummy.Maximum = 20;
            TrbDummy.Name = "TrbDummy";
            TrbDummy.Size = new Size(379, 45);
            TrbDummy.TabIndex = 0;
            TrbDummy.Scroll += TrbDummy_Scroll;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnQuestion);
            groupBox3.Controls.Add(BtnMsgBox);
            groupBox3.Controls.Add(BtnModaless);
            groupBox3.Controls.Add(BtnModal);
            groupBox3.Location = new Point(12, 273);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(426, 100);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "모달창, 모달리스창";
            // 
            // BtnQuestion
            // 
            BtnQuestion.Location = new Point(330, 37);
            BtnQuestion.Name = "BtnQuestion";
            BtnQuestion.Size = new Size(75, 35);
            BtnQuestion.TabIndex = 1;
            BtnQuestion.Text = "...";
            BtnQuestion.UseVisualStyleBackColor = true;
            BtnQuestion.Click += BtnQuestion_Click;
            // 
            // BtnMsgBox
            // 
            BtnMsgBox.Font = new Font("맑은 고딕", 9F);
            BtnMsgBox.Location = new Point(207, 37);
            BtnMsgBox.Name = "BtnMsgBox";
            BtnMsgBox.Size = new Size(117, 35);
            BtnMsgBox.TabIndex = 0;
            BtnMsgBox.Text = "MessageBox";
            BtnMsgBox.UseVisualStyleBackColor = true;
            BtnMsgBox.Click += BtnMsgBox_Click;
            // 
            // BtnModaless
            // 
            BtnModaless.Location = new Point(105, 37);
            BtnModaless.Name = "BtnModaless";
            BtnModaless.Size = new Size(96, 35);
            BtnModaless.TabIndex = 0;
            BtnModaless.Text = "Modaless";
            BtnModaless.UseVisualStyleBackColor = true;
            BtnModaless.Click += BtnModaless_Click;
            // 
            // BtnModal
            // 
            BtnModal.Location = new Point(26, 37);
            BtnModal.Name = "BtnModal";
            BtnModal.Size = new Size(73, 35);
            BtnModal.TabIndex = 0;
            BtnModal.Text = "Modal";
            BtnModal.UseVisualStyleBackColor = true;
            BtnModal.Click += BtnModal_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BtnAddChild);
            groupBox4.Controls.Add(BtnAddRoot);
            groupBox4.Controls.Add(LsvDummy);
            groupBox4.Controls.Add(TrvDummy);
            groupBox4.Location = new Point(13, 379);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(425, 211);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "트리뷰, 리스트뷰";
            // 
            // BtnAddChild
            // 
            BtnAddChild.Location = new Point(116, 171);
            BtnAddChild.Name = "BtnAddChild";
            BtnAddChild.Size = new Size(90, 29);
            BtnAddChild.TabIndex = 2;
            BtnAddChild.Text = "자식추가";
            BtnAddChild.UseVisualStyleBackColor = true;
            BtnAddChild.Click += BtnAddChild_Click;
            // 
            // BtnAddRoot
            // 
            BtnAddRoot.Location = new Point(21, 170);
            BtnAddRoot.Name = "BtnAddRoot";
            BtnAddRoot.Size = new Size(90, 30);
            BtnAddRoot.TabIndex = 2;
            BtnAddRoot.Text = "루트추가";
            BtnAddRoot.UseVisualStyleBackColor = true;
            BtnAddRoot.Click += BtnAddRoot_Click;
            // 
            // LsvDummy
            // 
            LsvDummy.Location = new Point(214, 22);
            LsvDummy.Name = "LsvDummy";
            LsvDummy.Size = new Size(190, 140);
            LsvDummy.TabIndex = 1;
            LsvDummy.UseCompatibleStateImageBehavior = false;
            LsvDummy.View = View.Details;
            // 
            // TrvDummy
            // 
            TrvDummy.Location = new Point(18, 22);
            TrvDummy.Name = "TrvDummy";
            TrvDummy.Size = new Size(190, 140);
            TrvDummy.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BtbLoad);
            groupBox5.Controls.Add(PicNomal);
            groupBox5.Location = new Point(444, 13);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(359, 577);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "픽처박스";
            // 
            // BtbLoad
            // 
            BtbLoad.Location = new Point(278, 299);
            BtbLoad.Name = "BtbLoad";
            BtbLoad.Size = new Size(75, 23);
            BtbLoad.TabIndex = 1;
            BtbLoad.Text = "로드";
            BtbLoad.UseVisualStyleBackColor = true;
            BtbLoad.Click += BtbLoad_Click;
            // 
            // PicNomal
            // 
            PicNomal.BackColor = SystemColors.ControlDark;
            PicNomal.Location = new Point(6, 22);
            PicNomal.Name = "PicNomal";
            PicNomal.Size = new Size(347, 271);
            PicNomal.TabIndex = 0;
            PicNomal.TabStop = false;
            PicNomal.Click += PicNomal_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 599);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "컨트롤 예제";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrbDummy).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicNomal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox TxtSamletxt;
        private CheckBox Chkltalic;
        private CheckBox Chkbold;
        private Label label2;
        private ComboBox CboFonts;
        private GroupBox groupBox2;
        private ProgressBar PrgDummy;
        private TrackBar TrbDummy;
        private GroupBox groupBox3;
        private Button BtnMsgBox;
        private Button BtnModaless;
        private Button BtnModal;
        private Button BtnQuestion;
        private GroupBox groupBox4;
        private ListView LsvDummy;
        private TreeView TrvDummy;
        private Button BtnAddChild;
        private Button BtnAddRoot;
        private GroupBox groupBox5;
        private Button BtbLoad;
        private PictureBox PicNomal;
        private OpenFileDialog DlgOpenImage;
    }
}
