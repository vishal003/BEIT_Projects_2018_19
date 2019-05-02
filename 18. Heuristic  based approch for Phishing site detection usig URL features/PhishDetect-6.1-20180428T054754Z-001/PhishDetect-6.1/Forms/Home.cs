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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                Training obj = new Training();
                obj.Show();
                obj.WindowState = FormWindowState.Maximized;
                this.Hide();
            }
            else
            {
                Training obj = new Training();
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
                Testing obj = new Testing();
                obj.Show();
                obj.WindowState = FormWindowState.Maximized;
                this.Hide();
            }
            else
            {
                Testing obj = new Testing();
                obj.Show();
                this.Hide();
            }
        }
    }
}
