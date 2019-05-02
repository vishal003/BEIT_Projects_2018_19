using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class Admin_ViewRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gridRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = 0;
        GridViewRow row;
        GridView grid = sender as GridView;

        switch (e.CommandName)
        {
            case "share_":
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                string rid = row.Cells[0].Text;
                string fid = row.Cells[1].Text;
                string email_id = row.Cells[3].Text;
                //shareFile
                string cs = Database.cs;
                SqlCommand cmd = new SqlCommand("shareFile");
                var sqltype = CommandType.StoredProcedure;
                SqlParameter[] sqlpara ={
                                    new SqlParameter("@reqId",SqlDbType.Int){Value=Convert.ToInt32(rid)},
                                    new SqlParameter("@fid",SqlDbType.Int){Value=Convert.ToInt32(fid)}
                                 };
                DataTable dt = Database.Getdata_Store(cs, cmd, sqlpara, sqltype);
                Send_Mail(email_id, dt.Rows[0][0].ToString());
                Response.Redirect("ViewRequest.aspx");

                break;
        }
    }

    public void Send_Mail(string email_id, string key_value)
    {
        try
        {
            //SmtpClient SmtpServer = new SmtpClient();
            //MailMessage mail = new MailMessage();
            //SmtpServer.Credentials = new System.Net.NetworkCredential("project.tpo@gmail.com", "1234ABCD$");
            //SmtpServer.Port = 587;
            //SmtpServer.EnableSsl = true;
            //SmtpServer.Host = "smtp.gmail.com";
            //mail = new MailMessage();
            //mail.From = new MailAddress("project.tpo@gmail.com");

            //mail.To.Add(email_id);
            //mail.Subject = "Customer  Details";
            //mail.Body = "This is to inform you that your organization share a file with You. Access Details as Follows. Secrect Key is '" + key_value + "'.";
            ////                + "' And Authentication keys are '" + Keys + "'";
            //SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {
            Alert.Show("mail Sending fail");

        }

    }

}