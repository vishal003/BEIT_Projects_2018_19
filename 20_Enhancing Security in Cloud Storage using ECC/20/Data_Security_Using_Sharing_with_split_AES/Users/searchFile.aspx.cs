using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Users_searchFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user_id"] == "")
            {
                Response.Redirect("Login.aspx?msg=logout");
            }
            string query = Request.QueryString["name"];
            if (query != null)
            {
                searchFile(query);
            }
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string query = txtSearchQuery.Text;
        searchFile(query);
    }

    public void searchFile(string findKey)
    {
        if (Session["uesr_id"] != "")
        {
            string cs = Database.cs;
            SqlCommand cmd = new SqlCommand("keywordSearch");
            var sqltype = CommandType.StoredProcedure;
            SqlParameter[] sqlpara ={
                                    new SqlParameter("@str",findKey),
                                    new SqlParameter("@uid",SqlDbType.Int){Value=Convert.ToInt32(Session["user_id"])}
                                 };
            DataTable dt = Database.Getdata_Store(cs, cmd, sqlpara, sqltype);
            if (dt.Rows.Count > 0)
            {
                gridFileList.DataSource = dt;
                gridFileList.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Keyword Not Found !!!!')</script>");
            }
        }
        else
        {
            {
                Response.Redirect("Login.aspx?msg=logout");
            }
        }
    }

    protected void List_rowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = 0;
        GridViewRow row;
        GridView grid = sender as GridView;

        switch (e.CommandName)
        {
            case "request":
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                string fid = row.Cells[0].Text;
                string cs = Database.cs;
                SqlCommand cmd = new SqlCommand("insertRequest");
                var sqltype = CommandType.StoredProcedure;
                SqlParameter[] sqlpara ={
                                    new SqlParameter("@fid",SqlDbType.Int){Value=Convert.ToInt32(fid)},
                                    new SqlParameter("@uid",SqlDbType.Int){Value=Convert.ToInt32(Session["user_id"])}
                                 };
                DataTable dt = Database.Getdata_Store(cs, cmd, sqlpara, sqltype);
                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                {
                    Response.Write("<script>alert('Request Already Sent!!!!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('request sent!!!!')</script>");
                }
                //use row to find the selected controls you need for edit, update, delete here
                // e.g. HiddenField value = row.FindControl("hiddenVal") as HiddenField;

                break;
        }
    }

}