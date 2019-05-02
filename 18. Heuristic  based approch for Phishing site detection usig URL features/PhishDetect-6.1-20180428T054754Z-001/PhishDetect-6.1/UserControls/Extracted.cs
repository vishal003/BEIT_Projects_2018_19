using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhishDetect.UserControls
{
    public partial class Extracted : UserControl
    {
        public Extracted()
        {
            InitializeComponent();
        }

        private void bunifuThinButton1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=url;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results from features_dataset", cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
    }
}
