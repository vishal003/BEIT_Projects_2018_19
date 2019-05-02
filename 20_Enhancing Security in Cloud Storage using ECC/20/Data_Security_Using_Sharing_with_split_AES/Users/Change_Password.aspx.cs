using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Users_Change_Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == "")
        {
            Response.Redirect("Login.aspx?msg=logout");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string employee_id = Convert.ToString(Session["user_id"]);
        string select_pwd="select password from User_Master where user_id='"+employee_id+"'";
        DataTable select_data=Database.Getdata(select_pwd);
        string password=Convert.ToString(select_data.Rows[0]["password"]);
        if (select_data.Rows.Count > 0)
        {
            if (password == txtexisting_pwd.Text)
            {
                string update_query = "update User_Master set password='" + txtnew_password.Text + "'where user_id='" + employee_id + "'";
                Database.InsertData_direct(update_query);
                Response.Redirect("Home.aspx?msg=change");
            }
            else
            {
                Alert.Show("Invalid Current Password");
            }
        }
    }
}