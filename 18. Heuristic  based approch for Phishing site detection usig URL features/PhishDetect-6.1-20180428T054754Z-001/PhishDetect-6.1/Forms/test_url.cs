using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml.Linq;


namespace PhishDetect.Forms
{
    public partial class test_url : Form
    {
        public test_url()
        {
            InitializeComponent();
        }
        SqlConnection cn = null;
        private void test_url_Load(object sender, EventArgs e)
        {
            txturl.Text = String.Empty;
            txturl.Text = "";
            panel2.Visible = false;
            lengthlabel.Visible = false;
            httplabel.Visible = false;
            label6.Visible = false;
            suslabel.Visible = false;
            label4.Visible = false;
            dotslabel.Visible = false;
            label11.Visible = false;
            subdomainlabel.Visible = false;
            label10.Visible = false;
            nolabel.Visible = false;
            label14.Visible = false;
            pageranklabel.Visible = false;
            agelabel.Visible = false;
            pgrankans.Visible = false;
            cn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=url;Integrated Security=True");
        }
        private const int Whois_Server_Default_PortNumber = 43;
        private const string Domain_Record_Type = "domain";
        private const string DotCom_Whois_Server = "whois.verisign-grs.com";
        private int GetAlexaRank(string domain)
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
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (jk == 1)
            {
                MessageBox.Show("Enter Valid Url");
            }
            else
            {
                panel2.Visible = true;
                lengthlabel.Visible = true;
                agelabel.Visible = true;
                label4.Visible = true;
                httplabel.Visible = true;
                label6.Visible = true;
                suslabel.Visible = true;
                pgrankans.Visible = true;
                pageranklabel.Visible = true;
                label4.Visible = true;
                dotslabel.Visible = true;
                label11.Visible = true;
                subdomainlabel.Visible = true;
                label10.Visible = true;
                nolabel.Visible = true;
                label14.Visible = true;

                try
                {
                    string pathCs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    pathCs += @"\outputs\ID3Dump";
                    //url change format 
                    string str = txturl.Text;
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
                        label8.Text = txturl.Text.Length.ToString();
                    }
                    else
                    {
                        length_of_url = 1;
                        label8.Text = txturl.Text.Length.ToString();
                    }

                    //url has http
                    if (str.Contains("http://") || str.Contains("https://"))
                    {
                        http_has = 1;
                        label7.Text = "yes";

                    }
                    else
                    {
                        http_has = 0;
                    }

                    //url has suspicious char
                    if (str.Contains("@") && str.Contains("//"))
                    {
                        suspicious_char = 1;
                        label6.ForeColor = System.Drawing.Color.Red;
                        label6.Text = "suspicious character found";
                    }
                    else
                    {
                        suspicious_char = 0;
                        label6.ForeColor = System.Drawing.Color.DeepSkyBlue;
                        label6.Text = "suspicious character not found";
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
                        int count1 = txturl.Text.Split('.').Length - 1;
                        label11.Text = count1.ToString();
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
                        label11.Text = "not found";
                    }

                    //no of slash
                    if (str.Contains("/"))
                    {
                        int count2 = txturl.Text.Split('/').Length - 1;
                        label14.Text = count2.ToString();
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
                        label14.Text = "NO";
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
                    label10.Text = c.ToString();
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
                        MetroFramework.MetroMessageBox.Show(this,txturl.Text + " is a Phishing Website", "Phishing Website", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (responce.ToString().Contains("1"))
                    {
                        label4.Text = "";
                        try
                        {
                            MetroFramework.MetroMessageBox.Show(this, txturl.Text + " is a Legitimate Website", "Legitimate Website", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string content = txturl.Text;
                            string url = txturl.Text;

                            System.Diagnostics.Process.Start(url);
                        }

                        catch
                        {

                        }
   
                    }
                    else
                    {
                        MessageBox.Show("not valid url");
                    }
                  //  int alex_rank = GetAlexaRank(txturl.Text);
                   // pgrankans.Text = alex_rank.ToString();


                }

                catch (Exception ex)
                {
                    pgrankans.Text = "-";
                    label4.Text = "-";
                    //MessageBox.Show("Suspicious Site", "Error");
                }
            }
        }
        static int jk = 0;
        private void txturl_Validating(object sender, CancelEventArgs e)
        {
            //"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$"
            //"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$"
            if (!Regex.IsMatch(txturl.Text, @"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$"))
            {
                jk = 1;
                // btnTest.Enabled = false;
                errorProvider1.SetError(txturl, "Email Id Invalid!");
            }
            else
            {
                jk = 0;
                //btnTest.Enabled = true;
                errorProvider1.SetError(txturl, null);
            }
            //if (jk == 1)
            //{
            //     btnTest.Enabled = false;
            //}
            //else
            //{
            //      btnTest.Enabled = true;
            //}

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            txturl.Text = String.Empty;
            txturl.Text = "";
            panel2.Visible = false;
            lengthlabel.Visible = false;
            httplabel.Visible = false;
            label6.Visible = false;
            suslabel.Visible = false;
            label4.Visible = false;
            dotslabel.Visible = false;
            label11.Visible = false;
            subdomainlabel.Visible = false;
            label10.Visible = false;
            nolabel.Visible = false;
            label14.Visible = false;
            pageranklabel.Visible = false;
            agelabel.Visible = false;
            pgrankans.Visible = false;

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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (jk == 1)
            {
                MessageBox.Show("Enter Valid Url");
            }
            else
            {
                panel2.Visible = true;
                lengthlabel.Visible = true;
                agelabel.Visible = true;
                label4.Visible = true;
                httplabel.Visible = true;
                label6.Visible = true;
                suslabel.Visible = true;
                pgrankans.Visible = true;
                pageranklabel.Visible = true;
                label4.Visible = true;
                dotslabel.Visible = true;
                label11.Visible = true;
                subdomainlabel.Visible = true;
                label10.Visible = true;
                nolabel.Visible = true;
                label14.Visible = true;

                try
                {
                    string pathCs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    pathCs += @"\outputs\ID3Dump";
                    //url change format 
                    string str = txturl.Text;
                    int l_url, length_of_url;
                    int http_has;
                    int suspicious_char;
                    int prefix_suffix;
                    int dots;
                    int slash;
                    int phis_term;
                    int sub_domain;
                    int ip_contain;
                    double ip1 = 0, len1 = 0, sus1 = 0, pre1 = 0, dot1 = 0, sub1 = 0, sla1 = 0, htt1 = 0, phi1 = 0;
                    double ip2 = 0, len2 = 0, sus2 = 0, pre2 = 0, dot2 = 0, sub2 = 0, sla2 = 0, htt2 = 0, phi2 = 0;
                    double probres0 = 0, probres1 = 0, probability0 = 0, probability1 = 0;
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
                        suspicious_char = 0;
                    }
                    else
                    {
                        suspicious_char = 1;
                    }

                    //prefix or suffix
                    if (str.Contains("-"))
                    {
                        prefix_suffix = 0;
                    }
                    else
                    {
                        prefix_suffix = 1;
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
                    if (str.Contains("secure") || str.Contains("secure") || str.Contains("websrc") || str.Contains("ebaysapi") || str.Contains("signin") || str.Contains("banking") || str.Contains("confirm") || str.Contains("login"))
                    {
                        phis_term = 0;
                    }
                    else
                    {
                        phis_term = 1;
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

                    // ASSIGNING PROBABILITES SqlConnection cn = new SqlConnection("Data Source=(localdb)\Projects;Initial Catalog=url;Integrated Security=True");
                    cn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=url;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("select ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results from naive_prob", cn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int rowCount = dt.Rows.Count;
                    int columnCount = dt.Columns.Count;
                    //Create 2d array
                    decimal[,] DataArray = new decimal[rowCount, columnCount];
                    //Fill array from DataTable
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int k = 0; k < columnCount; k++)
                        {
                            DataArray[i, k] = (decimal)dt.Rows[i][k];
                        }
                    }

  
                    probres0 = (double)DataArray[0, 9];
                    probres1 = (double)DataArray[1, 9];
                     




                    //IP CONTAINS
                    if (ip_contain == 0)
                    {
                        ip1 = (double)DataArray[0, 0];
                        ip2 = (double)DataArray[1, 0];

                    }
                    else 
                    {
                        ip1 = (double)DataArray[2, 0];
                        ip2 = (double)DataArray[3, 0];

                    }
                    //LENGTH OF URL
                    if (length_of_url == 0)
                    {
                        len1 = (double)DataArray[0, 1];
                        len2 = (double)DataArray[1, 1];
                    }
                    else
                    {
                        len1 = (double)DataArray[2, 1];
                        len2 = (double)DataArray[3, 1];
                    }
                    //SUSPICIOUS
                    if (suspicious_char == 0)
                    {
                        sus1 = (double)DataArray[0, 2];
                        sus2 = (double)DataArray[1, 2];
                    }
                    else
                    {
                        sus1 = (double)DataArray[2, 2];
                        sus2 = (double)DataArray[3, 2];
                    }
                    //PREFIX
                    if (prefix_suffix == 0)
                    {
                        pre1 = (double)DataArray[0, 3];
                        pre2 = (double)DataArray[1, 3];
                    }
                    else
                    {
                        pre1 = (double)DataArray[2, 3];
                        pre2 = (double)DataArray[3, 3];
                    }
                    //DOTS
                    if (dots == 0)
                    {
                        dot1 = (double)DataArray[0, 4];
                        dot2 = (double)DataArray[1, 4];
                    }
                    else
                    {
                        dot1 = (double)DataArray[2, 4];
                        dot2 = (double)DataArray[3, 4];
                    }
                    //SUB DOMAIN
                    if (sub_domain == 0)
                    {
                        sub1 = (double)DataArray[0, 5];
                        sub2 = (double)DataArray[1, 5];
                    }
                    else
                    {
                        sub1 = (double)DataArray[2, 5];
                        sub2 = (double)DataArray[3, 5];
                    }
                    //SLASH
                    if (slash == 0)
                    {
                        sla1 = (double)DataArray[0, 6];
                        sla2 = (double)DataArray[1, 6];
                    }
                    else
                    {
                        sla1 = (double)DataArray[2, 6];
                        sla2 = (double)DataArray[3, 6];
                    }
                    //HTTP HAS
                    if (http_has == 0)
                    {
                        htt1 = (double)DataArray[0, 7];
                        htt2 = (double)DataArray[1, 7];
                    }
                    else
                    {
                        htt1 = (double)DataArray[2, 7];
                        htt2 = (double)DataArray[3, 7];
                    }
                    //PHISH TERMS
                    if (phis_term == 0)
                    {
                        phi1 = (double)DataArray[0, 8];
                        phi2 = (double)DataArray[1, 8];
                    }
                    else
                    {
                        phi1 = (double)DataArray[2, 8];
                        phi2 = (double)DataArray[3, 8];
                    }

                    //CALC OF FINAL PROB
                    Debug.WriteLine(ip_contain + "\t" + length_of_url + "\t" + suspicious_char + "\t" + prefix_suffix + "\t" + dots + "\t" + sub_domain + "\t" + slash + "\t" + http_has + "\t" + phis_term);
                    Debug.WriteLine(ip1 +"\t"+ ip2 + "\t" + len1 + "\t" + len2 + "\t" + sus1 + "\t" + sus2 + "\t" + pre1 + "\t" + pre2 + "\t" + dot1 + "\t" + dot2 + "\t" + sub1 + "\t" + sub2 + "\t" + sla1 + "\t" + sla2 + "\t" + htt1 + "\t" + htt2 + "\t" + phi1 + "\t" + phi2 + "\t" + probres0 + "\t" + probres1);
                    probability0 = ip1 * len1 * sus1 * pre1 * dot1 * sub1 * sla1 * htt1 * phi1 * probres0;
                    probability1 = ip2 * len2 * sus2 * pre2 * dot2 * sub2 * sla2 * htt2 * phi2 * probres1;

                    if (probability0 > probability1)
                    {
                        Debug.WriteLine("PHISHING");
                        Debug.WriteLine(probability0);
                        Debug.WriteLine(probability1);
                    }
                    else
                    {
                        Debug.WriteLine("LEGITIMATE");
                        Debug.WriteLine(probability0);
                        Debug.WriteLine(probability1);
                    }

                }
                catch
                {

                }

            }        
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void txturl_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pageranklabel_Click(object sender, EventArgs e)
        {

        }

        private void agelabel_Click(object sender, EventArgs e)
        {

        }

        private void suslabel_Click(object sender, EventArgs e)
        {

        }
    }
}
