namespace WinFormsApp2
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            ColNumber = new DataGridViewTextBoxColumn();
            ColBackNum = new DataGridViewTextBoxColumn();
            ColPlayerName = new DataGridViewTextBoxColumn();
            ColPosition = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColNumber, ColBackNum, ColPlayerName, ColPosition });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 450);
            dataGridView1.TabIndex = 0;
            // 
            // ColNumber
            // 
            ColNumber.HeaderText = "타순";
            ColNumber.Name = "ColNumber";
            // 
            // ColBackNum
            // 
            ColBackNum.HeaderText = "등번호";
            ColBackNum.Name = "ColBackNum";
            // 
            // ColPlayerName
            // 
            ColPlayerName.HeaderText = "선수명";
            ColPlayerName.Name = "ColPlayerName";
            // 
            // ColPosition
            // 
            ColPosition.HeaderText = "수비위치";
            ColPosition.Name = "ColPosition";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColNumber;
        private DataGridViewTextBoxColumn ColBackNum;
        private DataGridViewTextBoxColumn ColPlayerName;
        private DataGridViewTextBoxColumn ColPosition;
    }
}
