namespace ex17_winApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("메세지박스!");
        }
    }
}
