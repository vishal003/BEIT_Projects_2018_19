using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PhishDetect.Forms
{
    public partial class test_graph : Form
    {
        public test_graph()
        {
            InitializeComponent();
      
        }
        
        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                bunifuImageButton1.Image = Properties.Resources.maximize;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                bunifuImageButton1.Image = Properties.Resources.min;
            }
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                Home obj = new Home();
                obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                this.Close();
            }
            else
            {
                Home obj = new Home();
                obj.Show();
                this.Close();
            }
        }


       /* private int GetAlexaRank(string domain)
        {
            var alexaRank = 0;
            try
            {
                var url = string.Format("http://data.alexa.com/data?cli=10&dat=snbamz&url={0}", domain);

                var doc = XDocument.Load(url);

                var rank = doc.Descendants("POPULARITY")
                .Select(node => node.Attribute("TEXT").Value)
                .FirstOrDefault();

                if (!int.TryParse(rank, out alexaRank))
                    alexaRank = -1;

            }
            catch (Exception e)
            {
                return -1;
            }

            return alexaRank;
        }*/
        private void btnTest_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            bunifuProgressBar1.Visible = true;
           

            string pathconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "';Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
            OleDbConnection conn = new OleDbConnection(pathconn);
            OleDbDataAdapter dataadp = new OleDbDataAdapter("select * from [Sheet1$]", conn);
            DataTable ds = new DataTable();
            dataadp.Fill(ds);
            ds.Rows[0].Delete();
            bunifuProgressBar1.MaximumValue = ds.Rows.Count - 1;
            for (int i = 1; i < ds.Rows.Count; i++)
            {
                bunifuProgressBar1.Value = i;
                try
                {
                    string pathCs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    pathCs += @"\outputs\ID3Dump";
                    //url change format 
                    //string str = txturl.Text;
                    string str = ds.Rows[i].ItemArray[0].ToString();
                    int l_url, length_of_url;
                    int http_has;
                    int suspicious_char;
                    int prefix_suffix;
                    int dots;
                    int slash;
                    int phis_term;
                    int sub_domain;
                    int ip_contain;
                    l_url = (int)str.Count();

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
                    if (str.Contains("http://") || str.Contains("https://"))
                    {
                        http_has = 1;
                    }
                    else
                    {
                        http_has = 0;
                    }

                    //url has suspicious char
                    if (str.Contains("@") && str.Contains("//"))
                    {
                        suspicious_char = 1;
                    }
                    else
                    {
                        suspicious_char = 0;
                    }

                    //prefix or suffix
                    if (str.Contains("-"))
                    {
                        prefix_suffix = 1;
                    }
                    else
                    {
                        prefix_suffix = 0;
                    }

                    //no of dots
                    if (str.Contains("."))
                    {
                        int count = str.Split('.').Length - 1;
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
                    if (str.Contains("/"))
                    {
                        int count = str.Split('.').Length - 1;
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
                    if (str.Contains("secure") || str.Contains("secure") || str.Contains("websrc") || str.Contains("ebaysapi") || str.Contains("signin") || str.Contains("baking") || str.Contains("confirm") || str.Contains("login"))
                    {
                        phis_term = 1;
                    }
                    else
                    {
                        phis_term = 0;
                    }

                    //length of subdomain
                    int it = str.IndexOf("//") + 2;
                    int j = str.IndexOf(".");
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
                    var match = Regex.Match(str, @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\b");
                    if (match.Success)
                    {
                        ip_contain = 1;
                    }
                    else
                    {
                        ip_contain = 0;
                    }

                    //url change format 
                    var objProcess = new Process
                    {
                        StartInfo =
                        {
                            WorkingDirectory = pathCs,
                            FileName = Path.Combine(pathCs, "test.exe"),
                            Arguments = ip_contain + " " + length_of_url + " " + suspicious_char + " " + prefix_suffix + " " + dots + " " + sub_domain + " " + slash + " " + http_has + " " + phis_term,
                            //  Arguments = Convert.ToString(ip_contain) + " " + Convert.ToString(length_of_url) + " " + Convert.ToString(suspicious_char) + " " + Convert.ToString(prefix_suffix) + " " + Convert.ToString(dots) + " " + Convert.ToString(sub_domain) + " " + Convert.ToString(slash) + " " + Convert.ToString(http_has) + " " + Convert.ToString(phis_term),
                            //execute test.exe program  
                            UseShellExecute = false,
                            //for display no warning at runtime
                            RedirectStandardError = true,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            RedirectStandardOutput = true,
                        }
                    };
                    objProcess.Start();
                    objProcess.WaitForExit();
                    StreamReader sr = objProcess.StandardOutput;
                    String responce = sr.ReadToEnd();

                    objProcess.Close();
                    if (responce.ToString().Contains("0"))
                    {
                        //MessageBox.Show("phishing");
                        label7.Text = "phishing";
                    }
                    else if (responce.ToString().Contains("1"))
                    {
                        //label4.Text = "";
                        try
                        {
                            // MessageBox.Show("legitimate");
                            label7.Text = "legitimate";
                            //legitimate
                            string content = ds.Rows[i].ItemArray[0].ToString();
                          /*  content = content.Replace("http://www.", "");
                            content = content.Replace("https://www.", "");
                            content = content.Replace("http://in.", "");
                            content = content.Replace("https://in.", "");

                            content = content.Replace("http://web1.", "");
                            content = content.Replace("https://web1.", "");

                            content = content.Replace("http://in.", "");
                            content = content.Replace("https://in.", "");

                            content = content.Replace("http://in.", "");
                            content = content.Replace("https://in.", "");
                            content = content.Replace("/", "");

                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://bulk-whois-api.com/try-it/?query=" + content + "");
                            request.Accept = "language=en";
                            request.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
                            request.Headers.Add("Accept-Language:en");
                            WebHeaderCollection myWebHeaderCollection = request.Headers;
                            request.Method = "GET";
                            request.ContentType = "application/x-www-form-urlencoded";
                            //try
                            //{
                            var response = (HttpWebResponse)request.GetResponse();
                            var reader = new StreamReader(response.GetResponseStream());
                            var objText = reader.ReadToEnd();
                            //XmlDocument MyRssDocument = new XmlDocument();
                            //MyRssDocument.Load(objText);
                            string contentz = objText.ToString();
                            var regex = new System.Text.RegularExpressions.Regex("<div id=(.*?)>(.*?)</div>");
                            var m = regex.Match(contentz);
                            string mz = m.ToString();
                            string val = Regex.Replace(mz, "<.*?>", String.Empty);
                            string[] spll = val.Split(',');
                            //int pos = Array.IndexOf(spll, "created_on");
                            string creat = spll[6].ToString();
                            string expp = spll[8].ToString();
                            creat = creat.Replace("created_on", "");
                            creat = creat.Replace(":", "");
                            creat = creat.Replace("UTC", "");
                            creat = creat.Replace("\"", "");
                            string[] fin = creat.Split(' ');
                            string ex = fin[0].ToString();
                            //SELECT DATEDIFF(year,'2011-06-14',GETDATE()) AS DiffDate
                            using (SqlCommand cmd = new SqlCommand("SELECT DATEDIFF(year,'" + ex + "',GETDATE()) AS DiffDate", cn))
                            {
                                DataTable dt = new DataTable();
                                using (SqlDataAdapter dp = new SqlDataAdapter(cmd))
                                {
                                    dp.Fill(dt);
                                }
                                label4.Text = dt.Rows[0].ItemArray[0].ToString();
                            }*/

                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                /*string content = ds.Rows[i].ItemArray[0].ToString();
                                content = content.Replace("http://www.", "");
                                content = content.Replace("https://www.", "");
                                content = content.Replace("http://in.", "");
                                content = content.Replace("https://in.", "");

                                content = content.Replace("http://web1.", "");
                                content = content.Replace("https://web1.", "");

                                content = content.Replace("http://in.", "");
                                content = content.Replace("https://in.", "");

                                content = content.Replace("http://in.", "");
                                content = content.Replace("https://in.", "");
                                content = content.Replace("/", "");

                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://bulk-whois-api.com/try-it/?query=" + content + "");
                                request.Accept = "language=en";
                                request.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
                                request.Headers.Add("Accept-Language:en");
                                WebHeaderCollection myWebHeaderCollection = request.Headers;
                                request.Method = "GET";
                                request.ContentType = "application/x-www-form-urlencoded";
                                //try
                                //{
                                var response = (HttpWebResponse)request.GetResponse();
                                var reader = new StreamReader(response.GetResponseStream());
                                var objText = reader.ReadToEnd();
                                //XmlDocument MyRssDocument = new XmlDocument();
                                //MyRssDocument.Load(objText);
                                string contentz = objText.ToString();
                                var regex = new System.Text.RegularExpressions.Regex("<div id=(.*?)>(.*?)</div>");
                                var m = regex.Match(contentz);
                                string mz = m.ToString();
                                string val = Regex.Replace(mz, "<.*?>", String.Empty);
                                string[] spll = val.Split(',');
                                //int pos = Array.IndexOf(spll, "created_on");
                                string creat = spll[11].ToString();
                                string expp = spll[8].ToString();
                                creat = creat.Replace("created_on", "");
                                creat = creat.Replace(":", "");
                                creat = creat.Replace("UTC", "");
                                creat = creat.Replace("\"", "");
                                string[] fin = creat.Split(' ');
                                string exz = fin[0].ToString();
                                //SELECT DATEDIFF(year,'2011-06-14',GETDATE()) AS DiffDate
                                using (SqlCommand cmd = new SqlCommand("SELECT DATEDIFF(year,'" + exz + "',GETDATE()) AS DiffDate", cn))
                                {
                                    DataTable dt = new DataTable();
                                    using (SqlDataAdapter dp = new SqlDataAdapter(cmd))
                                    {
                                        dp.Fill(dt);
                                    }
                                    label4.Text = dt.Rows[0].ItemArray[0].ToString();
                                }*/
                            }
                            catch (Exception exx)
                            {
                                string content = ds.Rows[i].ItemArray[0].ToString();
                               /* content = content.Replace("http://www.", "");
                                content = content.Replace("https://www.", "");
                                content = content.Replace("http://in.", "");
                                content = content.Replace("https://in.", "");
                                content = content.Replace("http://web1.", "");
                                content = content.Replace("https://web1.", "");
                                content = content.Replace("http://in.", "");
                                content = content.Replace("https://in.", "");
                                content = content.Replace("http://in.", "");
                                content = content.Replace("https://in.", "");
                                content = content.Replace("/", "");
                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://bulk-whois-api.com/try-it/?query=" + content + "");
                                request.Accept = "language=en";
                                request.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
                                request.Headers.Add("Accept-Language:en");
                                WebHeaderCollection myWebHeaderCollection = request.Headers;
                                request.Method = "GET";
                                request.ContentType = "application/x-www-form-urlencoded";
                                //try
                                //{
                                var response = (HttpWebResponse)request.GetResponse();
                                var reader = new StreamReader(response.GetResponseStream());
                                var objText = reader.ReadToEnd();
                                //XmlDocument MyRssDocument = new XmlDocument();
                                //MyRssDocument.Load(objText);
                                string contentz = objText.ToString();
                                var regex = new System.Text.RegularExpressions.Regex("<div id=(.*?)>(.*?)</div>");
                                var m = regex.Match(contentz);
                                string mz = m.ToString();
                                string val = Regex.Replace(mz, "<.*?>", String.Empty);
                                string[] spll = val.Split(',');
                                //int pos = Array.IndexOf(spll, "created_on");
                                string creat = spll[8].ToString();
                                string expp = spll[8].ToString();
                                creat = creat.Replace("created_on", "");
                                creat = creat.Replace(":", "");
                                creat = creat.Replace("UTC", "");
                                creat = creat.Replace("\"", "");
                                string[] fin = creat.Split(' ');
                                string exz = fin[0].ToString();
                                //SELECT DATEDIFF(year,'2011-06-14',GETDATE()) AS DiffDate
                                using (SqlCommand cmd = new SqlCommand("SELECT DATEDIFF(year,'" + exz + "',GETDATE()) AS DiffDate", cn))
                                {
                                    DataTable dt = new DataTable();
                                    using (SqlDataAdapter dp = new SqlDataAdapter(cmd))
                                    {
                                        dp.Fill(dt);
                                    }
                                    label4.Text = dt.Rows[0].ItemArray[0].ToString();
                                }*/
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("not valid url");
                    }
                   // int alex_rank = GetAlexaRank(ds.Rows[i].ItemArray[0].ToString());
                   // label3.Text = alex_rank.ToString();


                }
                catch (Exception ex)
                {

                }
                using (SqlCommand cmdd = new SqlCommand("insert into output_master(url_, file_result, output_, pagerank_, age_) values(@url_, @file_result, @output_, @pagerank_, @age_)", cn))
                {
                    //url_, file_result, output_, pagerank_, age_, actual_result
                    cmdd.Parameters.AddWithValue("@url_", ds.Rows[i].ItemArray[0].ToString());
                    cmdd.Parameters.AddWithValue("@file_result", ds.Rows[i].ItemArray[1].ToString());
                    cmdd.Parameters.AddWithValue("@output_", label7.Text);
                    cmdd.Parameters.AddWithValue("@pagerank_", label3.Text);
                    cmdd.Parameters.AddWithValue("@age_", label4.Text);
                    //cmdd.Parameters.AddWithValue("@actual_result",);
                    cn.Open();
                    cmdd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            bunifuProgressBar1.Visible = false;
            MetroFramework.MetroMessageBox.Show(this, "Testing Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnTest.Visible = false;
            button3.Visible = true;
            


        }
       // private const int Whois_Server_Default_PortNumber = 43;
       // private const string Domain_Record_Type = "domain";
       // private const string DotCom_Whois_Server = "whois.verisign-grs.com";
        private void button1_Click(object sender, EventArgs e)
        { //{
            //    using (TcpClient whoisClient = new TcpClient())
            //    {
            //        whoisClient.Connect(DotCom_Whois_Server, Whois_Server_Default_PortNumber);
            //        string domainQuery = Domain_Record_Type + " " + txturl.Text + "\r\n";
            //        byte[] domainQueryBytes = Encoding.ASCII.GetBytes(domainQuery.ToCharArray());
            //        Stream whoisStream = whoisClient.GetStream();
            //        whoisStream.Write(domainQueryBytes, 0, domainQueryBytes.Length);
            //        StreamReader whoisStreamReader = new StreamReader(whoisClient.GetStream(), Encoding.ASCII);
            //        string streamOutputContent = "";
            //        List<string> whoisData = new List<string>();
            //        while (null != (streamOutputContent = whoisStreamReader.ReadLine()))
            //        {
            //            whoisData.Add(streamOutputContent);
            //        }
            //        whoisClient.Close();
            //        label4.Text = whoisData.Count.ToString();
            //        // return String.Join(Environment.NewLine, whoisData);
            //    }
        }
        SqlConnection cn = null;
        private void test_graph_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            cn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=url;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand("truncate table output_master", cn))
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        static string path;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string pathCst = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                OpenFileDialog opd = new OpenFileDialog();
                opd.Filter = "Excelfiles|*.xlsx";
                opd.InitialDirectory = pathCst + @"\Dataset\Testing";
                DialogResult dr = opd.ShowDialog();
                label6.Text = opd.FileName;
                path = label6.Text;
                //button2.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SELECT EXCEL FILE!!", "ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculate ccl = new Calculate();
            ccl.Show();
            this.Close();
        }

 
    }
}
