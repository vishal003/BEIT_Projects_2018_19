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
    public partial class Training : Form
    {
        int taboffset;
        public Training()
        {
            InitializeComponent();
            upload1.BringToFront();
            taboffset = this.Width - TabArea.Width;


        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
            train1.BringToFront();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
            ruleset1.BringToFront();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            
            if (SideMenu.Width ==80)
            {
                SideMenu.Visible = false;
                SideMenu.Width = 285;
                Panel_Animation.ShowSync(SideMenu);
                Logo_Animator.ShowSync(LogoBox);
            }
            else
            {
                Logo_Hide.ShowSync(LogoBox);
                Logo_Animator.Hide(LogoBox);
                SideMenu.Visible = false;
                SideMenu.Width = 80;
                Panel_shrink.ShowSync(SideMenu);
            }
        }
        
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            upload1.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            extracted1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            tree1.BringToFront();
        }

        private void upload1_Load(object sender, EventArgs e)
        {

        }
    }
}
