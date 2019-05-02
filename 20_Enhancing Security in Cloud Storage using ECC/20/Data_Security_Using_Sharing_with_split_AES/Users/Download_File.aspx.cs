using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public partial class Users_Download_File : System.Web.UI.Page
{
    public string file_path, key, fileName, fileExtension, output, input_file;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == "")
        {
            Response.Redirect("Login.aspx?msg=logout");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string share_id = Request.QueryString["share_id"];
        string query = "select cloud_id, file_name,fid from Share_Master where share_id='" + share_id + "'";
        DataTable dt = Database.Getdata(query);
        string cloud_id = Convert.ToString(dt.Rows[0]["cloud_id"]);
        string file_name = Convert.ToString(dt.Rows[0]["file_name"]);
        int fileid = Convert.ToInt32(dt.Rows[0]["fid"]);


        if (cloud_id == "Cloud")
        {
            SqlCommand compare_keys = new SqlCommand("CompareKeys");
            var sqltype = CommandType.StoredProcedure;
            SqlParameter[] sqlpara ={
                                     new SqlParameter("@key_value",txtsecret_key.Text)
                                    };

            DataTable key_output = Database.Getdata_Store(Database.cs, compare_keys, sqlpara, sqltype);
            if (key_output.Rows.Count > 0)
            {
                file_path = Convert.ToString(key_output.Rows[0]["file_path"]);
                key = txtsecret_key.Text;
                fileName = Path.GetFileNameWithoutExtension(file_path);
                fileExtension = Path.GetExtension(file_path);

                ////////decryption

                output = fileName + "_dec" + fileExtension;
                int i=joinFile(file_path);
                input_file = Server.MapPath("../Files/" + file_path);
                StreamReader reader = File.OpenText(input_file);
                string data_1 = "";
                string line = reader.ReadLine();
                while (line != null)
                {
                    data_1 = data_1 + line;
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
                reader.Close();
                File.Delete(Server.MapPath("../Files/" + file_path));
                SqlDataAdapter adp = new SqlDataAdapter("select * from fileMaster where file_id='" + fileid + "'", Database.cs);
                DataTable dt1 = new DataTable();
                adp.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    //var keyBytes = (Byte[])dt1.Rows[0]["FileKey"];
                    byte[] keyBytes = Convert.FromBase64String(key);
                    byte[] iv = Convert.FromBase64String(dt1.Rows[0]["iv"].ToString());

                    byte[] fileBytes = Alice.Receive(Convert.FromBase64String(data_1), keyBytes, iv);

                    HttpResponse req = HttpContext.Current.Response;
                    req.AddHeader("Content-Disposition",
                        "attachment;filename=\"" + output + "\"");
                    req.BinaryWrite(fileBytes);
                    req.End();

                    txtsecret_key.Text = "";
                    Response.Redirect("Download_File.aspx");
                }

            }
            else
            {
                Response.Write("<script>alert('invalid keys')</script>");
            }

            txtsecret_key.Text = "";
        }
        else
        {
            Response.Write("<script>alert('invalid keys.')</script>");
        }
    }

    protected int joinFile(string fileName1)
    {
        try
        {
            DirectoryInfo diSource = new DirectoryInfo(Server.MapPath("../Files/"));
            FileStream fsSource = new FileStream(Server.MapPath("../Files/")+fileName1, FileMode.Append);

            foreach (FileInfo fiPart in diSource.GetFiles(fileName1+@".*.part"))
            {
                Byte[] bytePart = System.IO.File.ReadAllBytes(fiPart.FullName);
                fsSource.Write(bytePart, 0, bytePart.Length);
            }
            fsSource.Close();
            return 1;
        }

        catch (Exception e)
        { return 0; }
    }
}