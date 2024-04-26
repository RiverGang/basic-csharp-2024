using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace WinFormsApp1
{
    public partial class TotalOutCount : MetroForm

    {
        public TotalOutCount()
        {
            InitializeComponent();
        }

        private void TotalOutCount_Load(object sender, EventArgs e)
        {
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (RdbOut1.Checked) { Helper.Common.OutCount = 1; }
            else if (RdbOut2.Checked) { Helper.Common.OutCount = 2; }
            else if (RdbOut3.Checked) { Helper.Common.OutCount = 3; }
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Helper.Common.OutCount = 0;
            this.Close();
        }
    }
}
