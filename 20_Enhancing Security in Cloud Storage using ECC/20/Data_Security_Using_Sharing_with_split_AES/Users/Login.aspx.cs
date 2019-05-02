using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] == "logout")
            {
                Session["user_id"] = "";
                Alert.Show("You Are Logout Successfully");
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string query = "select * from User_Master where email_id='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'";
        DataTable dt = Database.Getdata(query);
        if (dt.Rows.Count > 0)
        {
            Session["user_id"] = Convert.ToInt32(dt.Rows[0]["user_id"]);
            
            Response.Redirect("Home.aspx");

        }
        else
        {
            Alert.Show("Invalid Username or Password");
            txtUsername.Text = "";
            txtPassword.Text = "";

        }

    }
}
