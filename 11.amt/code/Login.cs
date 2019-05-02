using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ColorSubstitutionCryptography
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show(@"All Fields Required!");
                return;
            }

            bool flag = false;

            using (MySqlConnection objConnection = new MySqlConnection("Data Source= 127.0.0.1;port= 3306;username= root;password=;database= amt;Integrated Security=True"))
            {
                using (MySqlCommand objCommand = new MySqlCommand("select * from users where userName = @UserName and userPass = @userPass", objConnection))
                {
                    objCommand.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = txtUserName.Text.Trim();
                    objCommand.Parameters.Add("@userPass", MySqlDbType.VarChar).Value = txtPass.Text.Trim();
                    objConnection.Open();

                    var objDr = objCommand.ExecuteReader();
                        if (objDr.HasRows)
                        flag = true;
                    else
                        flag = false;

                   // flag = Convert.ToBoolean(objCommand.ExecuteScalar());
                    objConnection.Close();
                }
            }

            if (flag)
            {
                Hide();
                var objMain = new Main();
                objMain.Show();
            }
            else
            {
                MessageBox.Show(@"User Name or password is invalid!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(@"Are you sure!",@"Confirmation",MessageBoxButtons.OKCancel))
            {
                Application.Exit();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DialogResult.OK != MessageBox.Show(@"Are you sure!", @"Confirmation", MessageBoxButtons.OKCancel);
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
