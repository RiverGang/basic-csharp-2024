using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace NewBookRentalShopApp
{
    public partial class FrmMain : MetroForm
    {
        // 각화면을 초기화
        FrmLoginUser frmLoginUser = null; // 객체를 메서드로 생성
        FrmBookDivision frmBookDivision = null;
        FrmBookInfo frmBookInfo = null;
        FrmMember frmMember = null;
        FrmBookRental frmBookRental = null;

        public FrmMain()
        {
            InitializeComponent();
            
        }
        
        // 폼로드 이벤트핸들러. 로그인 창을 먼저 띄워야 함
        private void Form1_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.TopMost = true; // 윈도우화면 가장 상단에.
            frm.ShowDialog();

            LblLoginId.Text = Helper.Common.LoginId;
        }

        #region "로그인 사용자관리 메뉴 클릭 이벤트핸들러"

        private void MnuLoginUsers_Click(object sender, EventArgs e)
        {
            // 이미 창이 열려있으면 새로 생성할 필요가 없기 때문에
            // 이런 작업을 해주지 않으면 메뉴 클릭 시 마다 새 폼이 열림
            frmLoginUser = ShowActiveForm(frmLoginUser, typeof(FrmLoginUser)) as FrmLoginUser;
        }

        // 책 장르관리 메뉴 클릭 이벤트핸들러
        private void MnuBookDivision_Click(object sender, EventArgs e)
        {
            frmBookDivision = ShowActiveForm(frmBookDivision, typeof(FrmBookDivision)) as FrmBookDivision;
        }
        private void MnuBookInfo_Click(object sender, EventArgs e)
        {
            // 객체변수 = 메서드, (객체변수, 클래스, 클래스)
            frmBookInfo = ShowActiveForm(frmBookInfo, typeof(FrmBookInfo)) as FrmBookInfo;
        }
        
        // 회원관리 메뉴
        private void MnuMembers_Click(object sender, EventArgs e)
        {
            frmMember = ShowActiveForm(frmMember, typeof(FrmMember)) as FrmMember;
        }

        private void MnuBookRental_Click(object sender, EventArgs e)
        {
            frmBookRental = ShowActiveForm(frmBookRental, typeof(FrmBookRental)) as FrmBookRental;
        }

        #endregion
        Form ShowActiveForm(Form form, Type type) 
        {
            if (form  == null)// 화면이 한번도 안열렸으면
            {
                form = Activator.CreateInstance(type) as Form; // 타입은 클래스 타입
                form.MdiParent = this; // 새로 열리는 자식 창의 부모는(FrmMain)임을 명시
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }
            else
            {
                if (form.IsDisposed) // 창이 한번 닫혔었으면,
                {
                    form = Activator.CreateInstance(type) as Form; // 타입은 클래스 타입
                    form.MdiParent = this; // 새로 열리는 자식 창의 부모는(FrmMain)임을 명시
                    form.WindowState = FormWindowState.Normal;
                    form.Show();
                }
                else // 창을 최소화 or 열려있는 상태면
                {
                    form.Activate(); // 화면에 열려있는 창을 활성화
                }

            }
            return form;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if(res == DialogResult.No)
                {
                    e.Cancel = true; //종료 안됨
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            FrmAbout popup = new FrmAbout();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();
        }
    }
}
