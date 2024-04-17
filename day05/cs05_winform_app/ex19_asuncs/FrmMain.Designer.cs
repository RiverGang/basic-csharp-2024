namespace ex19_asuncs
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
            PrgCopy = new ProgressBar();
            BtnCancel = new Button();
            BtnAsyncCopy = new Button();
            BtnSyncCopy = new Button();
            label2 = new Label();
            label1 = new Label();
            BtnSetTarget = new Button();
            BtnGetSource = new Button();
            TxtTarget = new TextBox();
            TxtSource = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(PrgCopy);
            groupBox1.Controls.Add(BtnCancel);
            groupBox1.Controls.Add(BtnAsyncCopy);
            groupBox1.Controls.Add(BtnSyncCopy);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(BtnSetTarget);
            groupBox1.Controls.Add(BtnGetSource);
            groupBox1.Controls.Add(TxtTarget);
            groupBox1.Controls.Add(TxtSource);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(488, 169);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "비동기 전송";
            // 
            // PrgCopy
            // 
            PrgCopy.Location = new Point(28, 127);
            PrgCopy.Name = "PrgCopy";
            PrgCopy.Size = new Size(432, 24);
            PrgCopy.TabIndex = 4;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(344, 86);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(116, 35);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnAsyncCopy
            // 
            BtnAsyncCopy.Location = new Point(189, 86);
            BtnAsyncCopy.Name = "BtnAsyncCopy";
            BtnAsyncCopy.Size = new Size(149, 35);
            BtnAsyncCopy.TabIndex = 3;
            BtnAsyncCopy.Text = "비동기화 복사";
            BtnAsyncCopy.UseVisualStyleBackColor = true;
            BtnAsyncCopy.Click += BtnAsyncCopy_Click;
            // 
            // BtnSyncCopy
            // 
            BtnSyncCopy.Location = new Point(28, 86);
            BtnSyncCopy.Name = "BtnSyncCopy";
            BtnSyncCopy.Size = new Size(155, 35);
            BtnSyncCopy.TabIndex = 3;
            BtnSyncCopy.Text = "동기화 복사";
            BtnSyncCopy.UseVisualStyleBackColor = true;
            BtnSyncCopy.Click += BtnSyncCopy_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 60);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "타겟: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 31);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "소스: ";
            // 
            // BtnSetTarget
            // 
            BtnSetTarget.Location = new Point(425, 57);
            BtnSetTarget.Name = "BtnSetTarget";
            BtnSetTarget.Size = new Size(35, 23);
            BtnSetTarget.TabIndex = 1;
            BtnSetTarget.Text = "...";
            BtnSetTarget.UseVisualStyleBackColor = true;
            BtnSetTarget.Click += BtnSetTarget_Click;
            // 
            // BtnGetSource
            // 
            BtnGetSource.Location = new Point(425, 27);
            BtnGetSource.Name = "BtnGetSource";
            BtnGetSource.Size = new Size(35, 23);
            BtnGetSource.TabIndex = 1;
            BtnGetSource.Text = "...";
            BtnGetSource.UseVisualStyleBackColor = true;
            BtnGetSource.Click += BtnGetSource_Click;
            // 
            // TxtTarget
            // 
            TxtTarget.Location = new Point(63, 57);
            TxtTarget.Name = "TxtTarget";
            TxtTarget.ReadOnly = true;
            TxtTarget.Size = new Size(356, 23);
            TxtTarget.TabIndex = 0;
            // 
            // TxtSource
            // 
            TxtSource.Location = new Point(63, 28);
            TxtSource.Name = "TxtSource";
            TxtSource.ReadOnly = true;
            TxtSource.Size = new Size(356, 23);
            TxtSource.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 193);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button BtnSetTarget;
        private Button BtnGetSource;
        private TextBox TxtTarget;
        private TextBox TxtSource;
        private Button BtnCancel;
        private Button BtnAsyncCopy;
        private Button BtnSyncCopy;
        private ProgressBar PrgCopy;
    }
}
