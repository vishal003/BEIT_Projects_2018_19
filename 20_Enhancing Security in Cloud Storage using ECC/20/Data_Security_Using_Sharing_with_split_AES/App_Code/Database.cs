using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for Database
/// </summary>
public static class Database
{
    public static string cs = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
    //public static string cs1 = ConfigurationManager.ConnectionStrings["dbConnection1"].ConnectionString;
    //public static string cs2 = ConfigurationManager.ConnectionStrings["dbConnection2"].ConnectionString;
    public static DataTable Getdata(string query)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(cs);
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        con.Open();
        da.Fill(dt);
        con.Close();
        return dt;

    }

    public static DataTable Getdata_Store(string cs, SqlCommand query, SqlParameter[] sqlpara, CommandType sqltype)
    {
        SqlCommand cmd = new SqlCommand();
        cmd = query;
        cmd.CommandType = sqltype;
        if (sqlpara != null)
        {
            cmd.Parameters.AddRange(sqlpara);
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        return null;
    }
    public static void Insertdata(string cs, SqlCommand query, SqlParameter[] sqlpara, CommandType sqltype)
    {
        SqlCommand cmd = new SqlCommand();
        cmd = query;
        cmd.CommandType = sqltype;
        if (sqlpara != null)
        {
            cmd.Parameters.AddRange(sqlpara);
            SqlConnection con = new SqlConnection(cs);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public static void InsertData_direct(string query)
    {
        SqlConnection con = new SqlConnection(cs);
        SqlCommand cmd = new SqlCommand(query,con);
        
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }

}