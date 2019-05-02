using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data.SqlClient;

public partial class Share_File : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_id"] == "")
        {
            Response.Redirect("Login.aspx?msg=logout");

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string username = ddlUser.SelectedValue;
        string email_id = ddlUser.SelectedItem.Text;
        string file_name = ddlfile_name.SelectedItem.Text;
        int cloud_id = Convert.ToInt32(ddlcloud_id.SelectedValue);

        if (cloud_id == 0)
        {
            string cs = Database.cs;
            Select_Info(cs, file_name, email_id);
        }


    }
    public void Select_Info(string cs, string file_name, string email_id)
    {
        SqlCommand cmd = new SqlCommand("Select_info");
        var sqltype = CommandType.StoredProcedure;
        SqlParameter[] sqlpara ={
                                    new SqlParameter("@file_name",file_name),
                                 };
        DataTable dt = Database.Getdata_Store(cs, cmd, sqlpara, sqltype);
        string key_value = Convert.ToString(dt.Rows[0]["FileKey"]);

        int fileid = Convert.ToInt32(dt.Rows[0]["file_id"]);

        #region
        //string query = "select key_value from auto_keys where key_id='" + key_value + "'";
        //DataTable dt1 = Database.Getdata(query);
        //string decrypt_key = Convert.ToString(dt1.Rows[0]["key_value"]);
        #endregion
        string query1 = "Insert into Share_Master values('" + file_name + "','" + email_id + "','" + ddlcloud_id.SelectedItem.Text + "','" + fileid + "',getdate())";
        Database.InsertData_direct(query1);
        Send_Mail(email_id,  key_value);
        Response.Redirect("Share_Log.aspx");

    }
    public void Send_Mail(string email_id, string key_value)
    {
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

            mail.To.Add(email_id);
            mail.Subject = "Customer  Details";
            mail.Body = "This is to inform you that your organization share a file with You. Access Details as Follows. Secrect Key is '" + key_value + "'.";
            //                + "' And Authentication keys are '" + Keys + "'";
            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {
            Alert.Show("mail Sending fail");

        }

    }


}