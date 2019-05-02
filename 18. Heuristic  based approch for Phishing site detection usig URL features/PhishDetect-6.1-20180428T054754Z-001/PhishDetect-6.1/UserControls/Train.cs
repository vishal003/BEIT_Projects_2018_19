using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PhishDetect.UserControls
{
    public partial class Train : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=url;Integrated Security=True");

        public Train()
        {
            InitializeComponent();

        }





        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuThinButton22.Visible = false;
                bunifuProgressBar1.Visible = true;
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView2.Refresh();

                string pathconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + Upload.datafile + "';Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
                OleDbConnection conn = new OleDbConnection(pathconn);

                OleDbDataAdapter dataadp = new OleDbDataAdapter("select * from [Sheet1$]", conn);
                DataTable ds = new DataTable();
                ds.Clear();
                dataadp.Fill(ds);
                dataGridView1.DataSource = ds;



                dataGridView1.Rows.RemoveAt(0);
                //generating training features
                int i;
                // bunifuProgressBar1.Minimum = 0;
                bunifuProgressBar1.MaximumValue = dataGridView1.Rows.Count - 1;
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    bunifuProgressBar1.Value = i;
                    string reslt = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    //int alex_rank = GetAlexaRank(reslt);
                    int l_url, length_of_url;
                    int http_has;
                    int suspicious_char;
                    int prefix_suffix;
                    int dots;
                    int slash;
                    int phis_term;
                    int sub_domain;
                    int ip_contain;
                    int r = 0;
                    l_url = (int)reslt.Count();

                    //length of url
                    if (l_url > 54)
                    {
                        length_of_url = 0;
                    }
                    else
                    {
                        length_of_url = 1;
                    }

                    //url has http
                    if (reslt.Contains("http://") || reslt.Contains("https://"))
                    {
                        http_has = 1;
                    }
                    else
                    {
                        http_has = 0;
                    }

                    //url has suspicious char
                    if (reslt.Contains("@") && reslt.Contains("//"))
                    {
                        suspicious_char = 1;
                    }
                    else
                    {
                        suspicious_char = 0;
                    }

                    //prefix or suffix
                    if (reslt.Contains("-"))
                    {
                        prefix_suffix = 1;
                    }
                    else
                    {
                        prefix_suffix = 0;
                    }

                    //no of dots
                    if (reslt.Contains("."))
                    {
                        int count = reslt.Split('.').Length - 1;
                        if (count > 5)
                        {
                            dots = 0;
                        }
                        else
                        {
                            dots = 1;
                        }
                    }
                    else
                    {
                        dots = 0;
                    }

                    //no of slash
                    if (reslt.Contains("/"))
                    {
                        int count = reslt.Split('.').Length - 1;
                        if (count > 5)
                        {
                            slash = 0;
                        }
                        else
                        {
                            slash = 1;
                        }
                    }
                    else
                    {
                        slash = 0;
                    }

                    //url has phishing terms
                    if (reslt.Contains("secure") || reslt.Contains("secure") || reslt.Contains("websrc") || reslt.Contains("ebaysapi") || reslt.Contains("signin") || reslt.Contains("banking") || reslt.Contains("confirm") || reslt.Contains("login"))
                    {
                        phis_term = 1;
                    }
                    else
                    {
                        phis_term = 0;
                    }

                    //length of subdomain
                    int it = reslt.IndexOf("//") + 2;
                    int j = reslt.IndexOf(".");
                    int c = j - it;
                    if (c > 5)
                    {
                        sub_domain = 0;
                    }
                    else
                    {
                        sub_domain = 1;
                    }

                    //url contains ip address
                    var match = Regex.Match(reslt, @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\b");
                    if (match.Success)
                    {
                        ip_contain = 1;
                    }
                    else
                    {
                        ip_contain = 0;
                    }
                    string yn = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    if (yn == "yes")
                    {
                        r = 0;
                    }
                    else
                    {
                        r = 1;
                    }
                    //if (ip_contain.Equals(0) && length_of_url.Equals(1) && suspicious_char.Equals(0) && prefix_suffix.Equals(0) && dots.Equals(1) && sub_domain.Equals(1) && slash.Equals(1) && http_has.Equals(1) && phis_term.Equals(0))
                    //{
                    //    r = 1;
                    //}
                    //else
                    //{
                    //    r = 0;
                    //}
                    SqlCommand cmd = new SqlCommand("insert into features_dataset(ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results) values(@ip_contains, @length_of_URL, @suspicious_char, @prefix_suffix, @dots, @sub_domain, @slash, @http_has, @phis_term,@results)", cn);
                    cn.Open();
                    cmd.Parameters.AddWithValue("@ip_contains", ip_contain);
                    cmd.Parameters.AddWithValue("@length_of_URL", length_of_url);
                    cmd.Parameters.AddWithValue("@suspicious_char", suspicious_char);
                    cmd.Parameters.AddWithValue("@prefix_suffix", prefix_suffix);
                    cmd.Parameters.AddWithValue("@dots", dots);
                    cmd.Parameters.AddWithValue("@sub_domain", sub_domain);
                    cmd.Parameters.AddWithValue("@slash", slash);
                    cmd.Parameters.AddWithValue("@http_has", http_has);
                    cmd.Parameters.AddWithValue("@phis_term", phis_term);
                    cmd.Parameters.AddWithValue("@results", r);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                //create file of dataset
                string pathCsT = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                pathCsT += @"\outputs";
                if (!Directory.Exists(pathCsT))
                    Directory.CreateDirectory(pathCsT);
                TextWriter sw = new StreamWriter(pathCsT+ @"\dataset-id3.txt");
                SqlCommand sc = new SqlCommand("select ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results from features_dataset", cn);
                SqlDataAdapter sdap = new SqlDataAdapter(sc);
                DataTable dta = new DataTable();
                sdap.Fill(dta);
                dataGridView2.DataSource = dta;
                int rowcount = dataGridView2.Rows.Count;
                sw.WriteLine("ip" + "\t" + "ln" + "\t" + "sc" + "\t" + "ps" + "\t" + "d0" + "\t" + "sd" + "\t" + "sl " + "\t" + "ht" + "\t" + "ph" + "\t" + "r");

                for (int m = 1; m < rowcount - 1; m++)
                {
                    sw.WriteLine(dataGridView2.Rows[m].Cells[0].Value.ToString() + "\t" +
                    dataGridView2.Rows[m].Cells[1].Value.ToString() + "\t" +
                     dataGridView2.Rows[m].Cells[2].Value.ToString() + "\t" +
                      dataGridView2.Rows[m].Cells[3].Value.ToString() + "\t" +
                      dataGridView2.Rows[m].Cells[4].Value.ToString() + "\t" +
                      dataGridView2.Rows[m].Cells[5].Value.ToString() + "\t" +
                   dataGridView2.Rows[m].Cells[6].Value.ToString() + "\t" +
                     dataGridView2.Rows[m].Cells[7].Value.ToString() + "\t" +
                       dataGridView2.Rows[m].Cells[8].Value.ToString() + "\t" +
                       dataGridView2.Rows[m].Cells[9].Value.ToString());
                }
                sw.Close();

                MetroFramework.MetroMessageBox.Show(this, "Text file generated at " + pathCsT, "Feature Extraction Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //end of export


                // groupBox1.Visible = true;


                bunifuProgressBar1.Visible = false;
                dataGridView1.Visible = true;
                //button2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "ERROR");
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuThinButton22.Visible = false;
                bunifuThinButton21.Visible = false;
                bunifuProgressBar1.Visible = true;
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView2.Refresh();

                string pathconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + Upload.datafile + "';Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
                OleDbConnection conn = new OleDbConnection(pathconn);

                OleDbDataAdapter dataadp = new OleDbDataAdapter("select * from [Sheet1$]", conn);
                DataTable dsn = new DataTable();
                dsn.Clear();
                dataadp.Fill(dsn);
                dataGridView1.DataSource = dsn;



                dataGridView1.Rows.RemoveAt(0);
                //generating training features
                int i;
                // bunifuProgressBar1.Minimum = 0;
                bunifuProgressBar1.MaximumValue = dataGridView1.Rows.Count - 1;
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    bunifuProgressBar1.Value = i;
                    string reslt = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    //int alex_rank = GetAlexaRank(reslt);
                    int l_url, length_of_url;
                    int http_has;
                    int suspicious_char;
                    int prefix_suffix;
                    int dots;
                    int slash;
                    int phis_term;
                    int sub_domain;
                    int ip_contain;
                    int r = 0;
                    l_url = (int)reslt.Count();

                    //length of url
                    if (l_url > 54)
                    {
                        length_of_url = 0;
                    }
                    else
                    {
                        length_of_url = 1;
                    }

                    //url has http
                    if (reslt.Contains("http://") || reslt.Contains("https://"))
                    {
                        http_has = 1;
                    }
                    else
                    {
                        http_has = 0;
                    }

                    //url has suspicious char
                    if (reslt.Contains("@") && reslt.Contains("//"))
                    {
                        suspicious_char = 0;
                    }
                    else
                    {
                        suspicious_char = 1;
                    }

                    //prefix or suffix
                    if (reslt.Contains("-"))
                    {
                        prefix_suffix = 0;
                    }
                    else
                    {
                        prefix_suffix = 1;
                    }

                    //no of dots
                    if (reslt.Contains("."))
                    {
                        int count = reslt.Split('.').Length - 1;
                        if (count > 5)
                        {
                            dots = 0;
                        }
                        else
                        {
                            dots = 1;
                        }
                    }
                    else
                    {
                        dots = 0;
                    }

                    //no of slash
                    if (reslt.Contains("/"))
                    {
                        int count = reslt.Split('.').Length - 1;
                        if (count > 5)
                        {
                            slash = 0;
                        }
                        else
                        {
                            slash = 1;
                        }
                    }
                    else
                    {
                        slash = 0;
                    }

                    //url has phishing terms
                    if (reslt.Contains("secure") || reslt.Contains("secure") || reslt.Contains("websrc") || reslt.Contains("ebaysapi") || reslt.Contains("signin") || reslt.Contains("banking") || reslt.Contains("confirm") || reslt.Contains("login"))
                    {
                        phis_term = 0;
                    }
                    else
                    {
                        phis_term = 1;
                    }

                    //length of subdomain
                    int it = reslt.IndexOf("//") + 2;
                    int j = reslt.IndexOf(".");
                    int c = j - it;
                    if (c > 5)
                    {
                        sub_domain = 0;
                    }
                    else
                    {
                        sub_domain = 1;
                    }

                    //url contains ip address
                    var match = Regex.Match(reslt, @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\b");
                    if (match.Success)
                    {
                        ip_contain = 1;
                    }
                    else
                    {
                        ip_contain = 0;
                    }
                    string yn = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    if (yn == "yes")
                    {
                        r = 0;
                    }
                    else
                    {
                        r = 1;
                    }
                    //if (ip_contain.Equals(0) && length_of_url.Equals(1) && suspicious_char.Equals(0) && prefix_suffix.Equals(0) && dots.Equals(1) && sub_domain.Equals(1) && slash.Equals(1) && http_has.Equals(1) && phis_term.Equals(0))
                    //{
                    //    r = 1;
                    //}
                    //else
                    //{
                    //    r = 0;
                    //}
                    SqlCommand cmd = new SqlCommand("insert into features_dataset_naive(ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results) values(@ip_contains, @length_of_URL, @suspicious_char, @prefix_suffix, @dots, @sub_domain, @slash, @http_has, @phis_term,@results)", cn);
                    cn.Open();
                    cmd.Parameters.AddWithValue ("@ip_contains", ip_contain);
                    cmd.Parameters.AddWithValue("@length_of_URL", length_of_url);
                    cmd.Parameters.AddWithValue("@suspicious_char", suspicious_char);
                    cmd.Parameters.AddWithValue("@prefix_suffix", prefix_suffix);
                    cmd.Parameters.AddWithValue("@dots", dots);
                    cmd.Parameters.AddWithValue("@sub_domain", sub_domain);
                    cmd.Parameters.AddWithValue("@slash", slash);
                    cmd.Parameters.AddWithValue("@http_has", http_has);
                    cmd.Parameters.AddWithValue("@phis_term", phis_term);
                    cmd.Parameters.AddWithValue("@results", r);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                //create file of dataset
                string pathCsT = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                pathCsT += @"\outputs";
                if (!Directory.Exists(pathCsT))
                    Directory.CreateDirectory(pathCsT);
                TextWriter sw = new StreamWriter(pathCsT + @"\dataset-naive.txt");
                SqlCommand sc = new SqlCommand("select ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results from features_dataset_naive", cn);
                SqlDataAdapter sdap = new SqlDataAdapter(sc);
                DataTable dta = new DataTable();
                sdap.Fill(dta);
                dataGridView2.DataSource = dta;
                int rowcount = dataGridView2.Rows.Count;
                sw.WriteLine("ip" + "\t" + "ln" + "\t" + "sc" + "\t" + "ps" + "\t" + "d0" + "\t" + "sd" + "\t" + "sl " + "\t" + "ht" + "\t" + "ph" + "\t" + "r");

                for (int m = 1; m < rowcount - 1; m++)
                {
                    sw.WriteLine(dataGridView2.Rows[m].Cells[0].Value.ToString() + "\t" +
                    dataGridView2.Rows[m].Cells[1].Value.ToString() + "\t" +
                     dataGridView2.Rows[m].Cells[2].Value.ToString() + "\t" +
                      dataGridView2.Rows[m].Cells[3].Value.ToString() + "\t" +
                      dataGridView2.Rows[m].Cells[4].Value.ToString() + "\t" +
                      dataGridView2.Rows[m].Cells[5].Value.ToString() + "\t" +
                   dataGridView2.Rows[m].Cells[6].Value.ToString() + "\t" +
                     dataGridView2.Rows[m].Cells[7].Value.ToString() + "\t" +
                       dataGridView2.Rows[m].Cells[8].Value.ToString() + "\t" +
                       dataGridView2.Rows[m].Cells[9].Value.ToString());
                }
                sw.Close();

                MetroFramework.MetroMessageBox.Show(this, "Text file generated at " + pathCsT, "Feature Extraction Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //end of export


                // groupBox1.Visible = true;


                bunifuProgressBar1.Visible = false;
                dataGridView1.Visible = true;
                //button2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "ERROR");
            }
        }
    }
}