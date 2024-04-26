namespace WinFormsApp1
{
    partial class FrmLogin
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
            label1 = new Label();
            label2 = new Label();
            TxtId = new TextBox();
            TxtPassword = new TextBox();
            BtnOk = new Button();
            BtnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(23, 73);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 0;
            label1.Text = "ID";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(23, 98);
            label2.Name = "label2";
            label2.Size = new Size(80, 25);
            label2.TabIndex = 0;
            label2.Text = "PASSWORD";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TxtId
            // 
            TxtId.Location = new Point(109, 75);
            TxtId.Name = "TxtId";
            TxtId.Size = new Size(125, 23);
            TxtId.TabIndex = 1;
            TxtId.KeyPress += TxtId_KeyPress;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(109, 100);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(125, 23);
            TxtPassword.TabIndex = 2;
            TxtPassword.KeyPress += TxtPassword_KeyPress;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(162, 129);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(72, 23);
            BtnOk.TabIndex = 3;
            BtnOk.Text = "OK";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(109, 129);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(47, 23);
            BtnExit.TabIndex = 4;
            BtnExit.Text = "Exit";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 181);
            Controls.Add(BtnExit);
            Controls.Add(BtnOk);
            Controls.Add(TxtPassword);
            Controls.Add(TxtId);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmLogin";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TxtId;
        private TextBox TxtPassword;
        private Button BtnOk;
        private Button BtnExit;
    }
}