using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public partial class Users_frmMatchHash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user_id"] == "")
            {
                Response.Redirect("Login.aspx?msg=logout");
            }
            else
            {
                string share_id = Request.QueryString["share_id"];
                
                string cs = Database.cs;
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("select file_id,fi.file_name,hashValue from dbo.Share_Master left join dbo.File_Info as fi on fid=file_id where share_id=@id");
                adp.SelectCommand.Connection = new SqlConnection(cs);
                adp.SelectCommand.Parameters.AddWithValue("@id", share_id);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblFileName.Text = dt.Rows[0][1].ToString();
                    lblHashValue.Text = dt.Rows[0][2].ToString();
                    lblGeneratedHash.Visible = lblViewGHash.Visible = false;
                }
                else
                {
                    Response.Redirect("View_Share_Files.aspx");
                }

            }
        }
    }
    protected void btnGenerateHash_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            StreamReader reader = new StreamReader(FileUpload1.FileContent);
            string data = string.Empty;
            do
            {
                string textLine = reader.ReadLine();
                //string.Concat(data,textLine);
                if (data == string.Empty)
                    data = textLine;
                else
                    data = data + "\n" + textLine;
            } while (reader.Peek() != -1);
            reader.Close();

            string hashData = performHash(data);

            lblViewGHash.Visible = lblGeneratedHash.Visible = true;
            lblGeneratedHash.Text = hashData;
            if (hashData.Equals(lblHashValue.Text))
            {
                Response.Write("<script>alert('Hash Value Matched')</script>");
            }
            else
            {
                Response.Write("<script>alert('Hash Value Not Matched')</script>");
            }
        }
    }

    private string performHash(string data)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(data);
       // SHA256Managed hashstring = new SHA256Managed();
        MD5 hashstring = System.Security.Cryptography.MD5.Create();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }
        return hashString;
    }
}