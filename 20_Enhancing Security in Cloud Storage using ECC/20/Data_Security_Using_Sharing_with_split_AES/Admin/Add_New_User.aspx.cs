using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class Add_New_User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_id"] == "")
        {
            Response.Redirect("Login.aspx?msg=logout");

        }
        btnCancel.Visible = false;
        if (Request.QueryString["action"] == "edit" && this.IsPostBack == false)
        {
            btnCancel.Visible = true;
            string user_id = Request.QueryString["user_id"];
            string query1 = "select * from User_Master where user_id='" + user_id + "'";
            DataTable dt = Database.Getdata(query1);
            txtfull_name.Text = Convert.ToString(dt.Rows[0]["full_name"]);
            txtcontact_no.Text = Convert.ToString(dt.Rows[0]["contact_no"]);
            txtemail_id.Text = Convert.ToString(dt.Rows[0]["email_id"]);
            txtaddress.Text = Convert.ToString(dt.Rows[0]["address"]);

        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] == "edit")
        {
            string user_id = Request.QueryString["user_id"];
            string query2 = "update User_Master set full_name='" + txtfull_name.Text + "',contact_no='" + txtcontact_no.Text + "',email_id='" + txtemail_id.Text + "',address='" + txtaddress.Text + "' where user_id='" + user_id + "'";
            Database.InsertData_direct(query2);
            Response.Redirect("Manage_Users.aspx?msg=update");

        }
        else
        {
            string select_id = "select * from User_Master where email_id='"+txtemail_id.Text+"'";
            DataTable dt = Database.Getdata(select_id);
            if (dt.Rows.Count > 0)
            {
                Alert.Show("User Already Exists");
            }
            else
            {

                var chars = "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm0987654321";
                var stringargs = new char[8];
                var random = new Random();
                for (int i = 0; i < stringargs.Length; i++)
                {
                    stringargs[i] = chars[random.Next(chars.Length)];
                }

                string password = new String(stringargs);
                string query = "Insert Into User_Master values('" + txtfull_name.Text + "','" + txtcontact_no.Text + "','" + txtemail_id.Text + "','" + txtaddress.Text + "','" + password + "') ";
                Database.InsertData_direct(query);
                try
                {
                    SmtpClient SmtpServer = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    SmtpServer.Credentials = new System.Net.NetworkCredential("ecccloud007@gmail.com", "ecc@00786");
                    SmtpServer.Port = 587;
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Host = "smtp.gmail.com";
                    mail = new MailMessage();
                    mail.From = new MailAddress("ecccloud007@gmail.com");

                    mail.To.Add(txtemail_id.Text);
                    mail.Subject = "Customer  Details";
                    mail.Body = "This is to inform you that your Username is '" + txtemail_id.Text + "' And Password is '" + password + "'";
                    SmtpServer.Send(mail);

                }
                catch (Exception ex)
                {
                    Alert.Show("mail Sending fail");

                }
                Response.Redirect("Manage_Users.aspx?msg=add");
            }
        }
    }
    
}