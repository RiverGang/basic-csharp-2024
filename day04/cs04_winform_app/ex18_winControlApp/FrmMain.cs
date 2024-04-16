namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // Ʈ���� ����̸����� ����� ������

        public FrmMain()
        {
            InitializeComponent(); // �����̳ʿ��� ������ ȭ�鱸�� �ʱ�ȭ

            LsvDummy.Columns.Add("�̸�");
            LsvDummy.Columns.Add("����");

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // ���� OS���� ��ġ�� ��Ʈ�� �� ��������
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }
        }

        // ����ü, ����, ���Ÿ� ���� �޼���
        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) // �ƹ��͵� ���õ��� ����
                return;

            FontStyle style = FontStyle.Regular; // �Ϲ� ����(����x & ���Ÿ�x & ... �� ��� �ƴ�)�� �ʱ�ȭ

            if (Chkbold.Checked) // ���� üũ�ڽ� üũ��(=True)
                style |= FontStyle.Bold;

            if (Chkltalic.Checked) // ���Ÿ� üũ�ڽ� üũ��(=True)
                style |= FontStyle.Italic;

            TxtSamletxt.Font = new Font((string)CboFonts.SelectedItem, 12, style);
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode node in TrvDummy.Nodes)
            {
                TreeToList(node);
            }
        }

        private void TreeToList(TreeNode node)
        {
            //throw new NotImplementedException();
            LsvDummy.Items.Add( // ����Ʈ�信 ������ �߰�
                new ListViewItem(
                    new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }
                    )
                );

            foreach (TreeNode subnode in node.Nodes)
            {
                TreeToList(subnode);
            }
        }


        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void Chkbold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void Chkltalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }


        // Ʈ���� ��ũ�� �̺�Ʈ�ڵ鷯
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            {
                PrgDummy.Value = TrbDummy.Value; // Ʈ���� �����͸� �ű�� ���α׷����� ���� ���� ����
            }
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "���â";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Tomato;
            FrmModal.ShowDialog(); // ���â ����
            // �ڽ�â�� �ݱ� ������ �θ�â �ǵ帱 �� ���� => Modal


        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "��� ����â";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.GreenYellow;
            FrmModaless.Show(); // ��޸���â ����
            // �ڽ� â�� ������� �θ�â ���� ���� -> Modaless
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TxtSamletxt.Text, "�޼��� �ڽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("���ƿ�?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("�� ���ƿ�");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("�ƴϿ� ���� �Ⱦ��");
            }
        }

        // ������ �����ư�� Ŭ�� ��, �߻��ϴ� �̺�Ʈ �ڵ鷯
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("���� �����Ͻðڽ��ϱ�?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (res == DialogResult.Yes)
            {
                MessageBox.Show("���α׷��� ����˴ϴ�", "����");
            }
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode == null) // �θ��带 �������� ������ �ڽĳ�� ����X
            {
                MessageBox.Show("������ ��尡 �����ϴ�.", "���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // ���̻� ������� �޼��� ����
            }

            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand(); // ��� Ȯ��
            TreeToList(); //����Ʈ �並 �ٽ� �׷��ش�

        }

        private void BtbLoad_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Title = "�̹��� ����";
            // Filter�� Ȯ���ڸ� �̹����θ� ����
            DlgOpenImage.Filter = "Image Files(*.bmpl;*.jpg;*.png)|*.bmp;*.jpg;*.png"; // �����̸� �ؽ�Ʈ �ڽ� �� Ȯ���ڿ� Ȯ���� ������
            var res = DlgOpenImage.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show(DlgOpenImage.FileName.ToString());
                PicNomal.Image = Bitmap.FromFile(DlgOpenImage.FileName);
            }
        }

        private void PicNomal_Click(object sender, EventArgs e)
        {
            if(PicNomal.SizeMode == PictureBoxSizeMode.Normal)
            {
                PicNomal.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PicNomal.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
