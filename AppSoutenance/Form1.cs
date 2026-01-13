namespace AppSoutenance
{
    public partial class fmrConnection : Form
    {
        public fmrConnection()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FmrMBI f = new FmrMBI();
            f.Show();
            this.Hide();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
