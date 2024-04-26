namespace WinFormsApp1
{
    partial class PopPlayerList
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
            DgvPlayerList = new DataGridView();
            BtnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvPlayerList).BeginInit();
            SuspendLayout();
            // 
            // DgvPlayerList
            // 
            DgvPlayerList.BackgroundColor = SystemColors.InactiveBorder;
            DgvPlayerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvPlayerList.Location = new Point(23, 63);
            DgvPlayerList.Name = "DgvPlayerList";
            DgvPlayerList.RowHeadersVisible = false;
            DgvPlayerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvPlayerList.Size = new Size(250, 309);
            DgvPlayerList.TabIndex = 0;
            DgvPlayerList.CellClick += DgvPlayerList_CellClick;
            // 
            // BtnOk
            // 
            BtnOk.Location = new Point(193, 378);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(80, 33);
            BtnOk.TabIndex = 1;
            BtnOk.Text = "OK";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // PopPlayerList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 424);
            Controls.Add(BtnOk);
            Controls.Add(DgvPlayerList);
            Name = "PopPlayerList";
            Text = "선수 목록";
            Load += PopPlayerList_Load;
            ((System.ComponentModel.ISupportInitialize)DgvPlayerList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvPlayerList;
        private Button BtnOk;
    }
}