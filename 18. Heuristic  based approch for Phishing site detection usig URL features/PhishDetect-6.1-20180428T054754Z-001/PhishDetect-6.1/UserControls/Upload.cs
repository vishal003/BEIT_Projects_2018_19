using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PhishDetect.UserControls
{
    public partial class Upload : UserControl
    {
        public static String datafile;
        string path;
        public Upload()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            datafile = path;
            if (datafile!=null)
                MetroFramework.MetroMessageBox.Show(this, "Dataset Uploaded Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
             MetroFramework.MetroMessageBox.Show(this, "Choose File before Uploading", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opd = new OpenFileDialog();
                string pathCs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                opd.InitialDirectory = pathCs+ @"\Dataset\Training";
                opd.Filter = "Excelfiles|*.xlsx";
                DialogResult dr = opd.ShowDialog();
                TextBox1.Text = opd.FileName;
                path = TextBox1.Text;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("SELECT EXCEL FILE!!", "ERROR");
            }
        }
        private void pictureBox1_DragEnter(object sender,DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void pictureBox1_DragDrop(object sender,DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (String file in files)
                TextBox1.Text = files.First();
                path = TextBox1.Text;
        }

        private void TextBox1_OnValueChanged(object sender, EventArgs e)
        {

        }


    }
}
