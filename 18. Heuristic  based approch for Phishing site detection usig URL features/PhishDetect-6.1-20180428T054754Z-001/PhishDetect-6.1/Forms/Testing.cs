using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhishDetect.Forms
{
    public partial class Testing : Form
    {
        public Testing()
        {
            InitializeComponent();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                Home obj = new Home();
                obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                this.Close();
            }
            else
            {
                Home obj = new Home();
                obj.Show();
                this.Close();
            }
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                test_url obj = new test_url();
                obj.Show();
                obj.WindowState = FormWindowState.Maximized;
                this.Hide();
            }
            else
            {
                test_url obj = new test_url();
                obj.Show();
                this.Hide();
            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                bunifuImageButton1.Image = Properties.Resources.maximize;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                bunifuImageButton1.Image = Properties.Resources.min;
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                test_graph obj = new test_graph();
                obj.Show();
                obj.WindowState = FormWindowState.Maximized;
                this.Hide();
            }
            else
            {
                test_graph obj = new test_graph();
                obj.Show();
                this.Hide();
            }
        }
    }
}
