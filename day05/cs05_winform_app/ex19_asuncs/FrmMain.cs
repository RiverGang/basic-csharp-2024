namespace ex19_asuncs
{
    public partial class FrmMain : Form
    {
        #region "생성자, 초기화 영역"
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region "이벤트핸들러 영역"
        // 이벤트핸들러. 복사할 원본파일 선택
        private void BtnGetSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                TxtSource.Text = dlg.FileName;
            }
        }

        // 이벤트핸들러. 붙여넣기할 타겟파일 지정
        private void BtnSetTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                TxtTarget.Text = dlg.FileName;
            }
        }

        // 이벤트핸들러. 동기화복사 진행
        private void BtnSyncCopy_Click(object sender, EventArgs e)
        {
            long result = CopySync(TxtSource.Text, TxtTarget.Text);
        }

        // 이벤트핸들러. 비동기화복사 진행
        // void는 리턴 값이 없으므로 Task<void> 하지 않아도 됨
        private async void BtnAsyncCopy_Click(object sender, EventArgs e)
        {
            long result = await CopyAsync(TxtSource.Text, TxtTarget.Text);
        }

        // 버튼클릭 이벤트핸들러. 복사취소 처리
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UI반응 테스트 완료!");
        }

        #endregion

        #region "사용자메서드 영역"
        
        long CopySync(string srcPath, string destPath)
        {
            // 버튼 사용 비활성화
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            // File은 Open()하면 반드시 Close()해야 함. using 사용 시 close() C#이 알아서 해줌
            // 파일입출력
            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open)) // 기존의 파일 열기
            {
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))// 존재하지 않는 파일 제작
                {
                    // 1MByte 버퍼 생성
                    byte[] buffer = new byte[1024 * 1024]; // 테스트 시 10으로 변경
                    // fromStream에 들어 온 파일을 1MB씩 잘라서 버퍼에 담은 뒤,
                    // toStream에 1MB씩 붙여넣기

                    int nRead = 0;
                    while ((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        toStream.Write(buffer, 0, nRead);
                        totalCopied += nRead; //전체 복사 사이즈를 계속 증가

                        //프로그래스바에 진행사항을 표기
                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied; // 복사한 파일사이즈 리턴
        }


        // 비동기처리 시, async/await 키워드 가장 중
        // async: 나는 비동기메서드야 정의
        // await: 비동기 메서드가 끝날 때까지 기다릴게
        // 비동기를 처리하는 메서드 ...Async로 끝남
        // async는 메서드 리턴 값에 작성. 리턴 값은 나는 비동기로 넘어오는 값임을 알리는 Task<리턴값> 키워드 사용

        async Task<long> CopyAsync(string srcPath, string destPath)
        {
            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(srcPath, FileMode.Open)) 
            {
                using (FileStream toStream = new FileStream(destPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024]; // 테스트 시 10으로 변경

                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead; 

                        PrgCopy.Value = (int)((double)(totalCopied / fromStream.Length) * 100);
                    }
                }
            }

            BtnSyncCopy.Enabled = BtnAsyncCopy.Enabled = true;
            return totalCopied; // 복사한 파일사이즈 리턴
        }

        #endregion

    }
}
