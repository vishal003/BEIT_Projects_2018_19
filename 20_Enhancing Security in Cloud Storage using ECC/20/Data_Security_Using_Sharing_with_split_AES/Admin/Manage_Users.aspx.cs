using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_id"] == "")
        {
            Response.Redirect("Login.aspx?msg=logout");

        }
        
    }
    protected void DeleteButton_OnCommand(object sender, CommandEventArgs e)
    {
        //write delect query and pass Student id this e.commandargument

        string query = "delete From User_Master where user_id=" + e.CommandArgument + "";
        Database.InsertData_direct(query);
        Response.Redirect("Manage_Users.aspx");
        Alert.Show("User Deleted Successfully");
    }
}