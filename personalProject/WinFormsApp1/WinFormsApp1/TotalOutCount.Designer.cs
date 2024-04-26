namespace WinFormsApp1
{
    partial class TotalOutCount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            BtnOk = new Button();
            RdbOut3 = new RadioButton();
            RdbOut2 = new RadioButton();
            RdbOut1 = new RadioButton();
            BtnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnCancel);
            groupBox1.Controls.Add(BtnOk);
            groupBox1.Controls.Add(RdbOut3);
            groupBox1.Controls.Add(RdbOut2);
            groupBox1.Controls.Add(RdbOut1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(224, 114);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "아웃 카운트";
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(54, 76);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(54, 23);
            BtnOk.TabIndex = 4;
            BtnOk.Text = "확인";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // RdbOut3
            // 
            RdbOut3.AutoSize = true;
            RdbOut3.Location = new Point(157, 46);
            RdbOut3.Name = "RdbOut3";
            RdbOut3.Size = new Size(54, 19);
            RdbOut3.TabIndex = 3;
            RdbOut3.TabStop = true;
            RdbOut3.Text = "3 out";
            RdbOut3.UseVisualStyleBackColor = false;
            // 
            // RdbOut2
            // 
            RdbOut2.AutoSize = true;
            RdbOut2.Location = new Point(85, 46);
            RdbOut2.Name = "RdbOut2";
            RdbOut2.Size = new Size(54, 19);
            RdbOut2.TabIndex = 2;
            RdbOut2.TabStop = true;
            RdbOut2.Text = "2 out";
            RdbOut2.UseVisualStyleBackColor = false;
            // 
            // RdbOut1
            // 
            RdbOut1.AutoSize = true;
            RdbOut1.Location = new Point(13, 46);
            RdbOut1.Name = "RdbOut1";
            RdbOut1.Size = new Size(54, 19);
            RdbOut1.TabIndex = 1;
            RdbOut1.TabStop = true;
            RdbOut1.Text = "1 out";
            RdbOut1.UseVisualStyleBackColor = false;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(114, 76);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(54, 23);
            BtnCancel.TabIndex = 5;
            BtnCancel.Text = "초기화";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // TotalOutCount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(248, 138);
            ControlBox = false;
            Controls.Add(groupBox1);
            Name = "TotalOutCount";
            Text = "OutCount";
            Load += TotalOutCount_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton RdbOut3;
        private RadioButton RdbOut2;
        private RadioButton RdbOut1;
        private Button BtnOk;
        private Button BtnCancel;
    }
}