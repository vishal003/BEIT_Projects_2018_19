using System.Windows.Forms;

namespace ColorSubstitutionCryptography
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void createCryptographyImageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var objImage = new CreateCryptographyImage();
            objImage.ShowDialog();
        }

        private void readCryptographyImageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var objReadImage = new ReadCryptographyImage();
            objReadImage.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(@"Are you sure!", @"Confirmation", MessageBoxButtons.OKCancel))
            {
                Application.Exit();
            }
        }

        private void createWithTranslatorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            createWithTranslator cwt = new createWithTranslator();
            cwt.Show();
        }

        private void readWithTranslatorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            readWithTranslator rwt = new readWithTranslator();
            rwt.Show();
        }
    }
}
