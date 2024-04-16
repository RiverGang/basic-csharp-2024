namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // 트리뷰 노드이름으로 사용할 랜덤값

        public FrmMain()
        {
            InitializeComponent(); // 디자이너에서 정의한 화면구성 초기화

            LsvDummy.Columns.Add("이름");
            LsvDummy.Columns.Add("깊이");

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // 현재 OS내에 설치된 폰트를 다 가져와줘
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }
        }

        // 글자체, 볼드, 이탤릭 변경 메서드
        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) // 아무것도 선택되지 않흠
                return;

            FontStyle style = FontStyle.Regular; // 일반 글자(볼드x & 이탤릭x & ... 등 모두 아닌)로 초기화

            if (Chkbold.Checked) // 굵게 체크박스 체크시(=True)
                style |= FontStyle.Bold;

            if (Chkltalic.Checked) // 이탤릭 체크박스 체크시(=True)
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
            LsvDummy.Items.Add( // 리스트뷰에 아이템 추가
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


        // 트랙바 스크롤 이벤트핸들러
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            {
                PrgDummy.Value = TrbDummy.Value; // 트랙바 포인터를 옮기면 프로그레스바 값도 같이 변경
            }
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "모달창";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Tomato;
            FrmModal.ShowDialog(); // 모달창 띄우기
            // 자식창을 닫기 전까지 부모창 건드릴 수 없음 => Modal


        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "모달 리스창";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.GreenYellow;
            FrmModaless.Show(); // 모달리스창 띄우기
            // 자식 창과 상관없이 부모창 접근 가능 -> Modaless
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TxtSamletxt.Text, "메세지 박스", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("좋아요?", "질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("네 좋아요");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("아니요 정말 싫어요");
            }
        }

        // 윈도우 종료버튼을 클릭 시, 발생하는 이벤트 핸들러
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("정말 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (res == DialogResult.Yes)
            {
                MessageBox.Show("프로그램이 종료됩니다", "종료");
            }
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode == null) // 부모노드를 선택하지 않으면 자식노드 생성X
            {
                MessageBox.Show("선택한 노드가 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 더이상 진행없이 메서드 종료
            }

            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand(); // 노드 확장
            TreeToList(); //리스트 뷰를 다시 그려준다

        }

        private void BtbLoad_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Title = "이미지 열기";
            // Filter는 확장자를 이미지로만 한정
            DlgOpenImage.Filter = "Image Files(*.bmpl;*.jpg;*.png)|*.bmp;*.jpg;*.png"; // 파일이름 텍스트 박스 옆 확장자에 확장자 한정됨
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
