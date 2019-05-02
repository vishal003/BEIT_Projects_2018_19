using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Users_View_Share_Files : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["msg"] == "invalid")
        {
            Alert.Show("Invalid Secret Keys");
        }
        if (Session["user_id"] == "")
        {
            Response.Redirect("Login.aspx?msg=logout");
        }
        string user_id = Convert.ToString(Session["user_id"]);
        string query="select email_id from User_master where user_id='"+user_id+"'";
        DataTable dt= Database.Getdata(query);
        string email_id=Convert.ToString(dt.Rows[0]["email_id"]);
        string query1 = "select share_id, file_name from Share_Master where username='"+email_id+"'";
        DataTable dt1 = Database.Getdata(query1);
        GridView1.DataSource = dt1;
        GridView1.DataBind();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchFile.aspx?name="+txtSearchQuery.Text);
    }
}