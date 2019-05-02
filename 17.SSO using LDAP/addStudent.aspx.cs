using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class addStudent : System.Web.UI.Page
{
    String constr = ConfigurationManager.ConnectionStrings["connect"].ToString();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string constr = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select Id, Branch from branch_master"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlBranch.DataSource = ds.Tables[0];
                        ddlBranch.DataTextField = "Branch";
                        ddlBranch.DataValueField = "Id";
                        ddlBranch.DataBind();
                    }
                }
            }
            ddlBranch.Items.Insert(0, new ListItem("--Select Branch--", "0"));

            
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select Id, Semester from semester_master"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        ddlSem.DataSource = ds.Tables[0];
                        ddlSem.DataTextField = "Semester";
                        ddlSem.DataValueField = "Id";
                        ddlSem.DataBind();
                    }
                }
            }
            ddlSem.Items.Insert(0, new ListItem("--Select Semester--", "0"));
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("select Email from student_master where Email=@email", conn);
        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        if (dt.Rows.Count > 0)
        {
            Label1.Visible = true;
            Label1.Text = "Email-Id already exist";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            //Random Password Generation
            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }

            SqlConnection conn1 = new SqlConnection(constr);
            SqlCommand cmd1 = new SqlCommand("insert into student_master (Name,Branch,Semester,Email,Password) values (@name,@branch,@sem,@email,@pass)", conn1);
            cmd1.Parameters.AddWithValue("@name", txtName.Text);
            cmd1.Parameters.AddWithValue("@branch", ddlBranch.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@sem", ddlSem.SelectedItem.Text);
            cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd1.Parameters.AddWithValue("@pass", passwordString);
            conn1.Open();
            cmd1.ExecuteNonQuery();
            conn1.Close();    
        } 
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("addStudent.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("manageAttendance.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
        Session.Abandon();
    }
}