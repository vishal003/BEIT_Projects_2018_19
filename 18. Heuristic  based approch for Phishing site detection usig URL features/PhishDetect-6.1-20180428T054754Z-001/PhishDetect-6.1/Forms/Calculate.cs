using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhishDetect.Forms
{
    public partial class Calculate : Form
    {
        public Calculate()
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
                
                this.Close();
                
            }
            else
            {
               
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("select count(*) as false_negative from dbo.output_master where file_result='legitimate' and output_='phishing'", cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter dp = new SqlDataAdapter(cmd))
                {
                    dp.Fill(dt);
                }
                label2.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            using (SqlCommand cmd1 = new SqlCommand("select count(*) as false_positive from dbo.output_master where file_result='phishing' and output_='legitimate'", cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter dp = new SqlDataAdapter(cmd1))
                {
                    dp.Fill(dt);
                }
                label4.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            using (SqlCommand cmd2 = new SqlCommand("select count(*) as true_positive from dbo.output_master where file_result='legitimate' and output_='legitimate'", cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter dp = new SqlDataAdapter(cmd2))
                {
                    dp.Fill(dt);
                }
                label6.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            using (SqlCommand cmd3 = new SqlCommand("select count(*) as true_negative from dbo.output_master where file_result='phishing' and output_='phishing'", cn))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter dp = new SqlDataAdapter(cmd3))
                {
                    dp.Fill(dt);
                }
                label8.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            double fn = Convert.ToDouble(label2.Text);
            double fp = Convert.ToDouble(label4.Text);
            double tp = Convert.ToDouble(label6.Text);
            double tn = Convert.ToDouble(label8.Text);
            double tpr = tp / (tp + fn);
            double tnr = tn / (tn + fp);
            double fpr = fp / (fp + tn);
            double fnr = fn / (fn + tp);
            double precision = tp / (tp + fp);
            double recall = tp / (tp + fn);
            double fmeasure = 2 * (precision * recall) / (precision + recall);
            tpr = Math.Round(tpr, 2);
            tnr = Math.Round(tnr, 2);
            fpr = Math.Round(fpr, 2);
            fnr = Math.Round(fnr, 2);
            label10.Text = tpr.ToString();
            label12.Text = tnr.ToString();
            label14.Text = fpr.ToString();
            label16.Text = fnr.ToString();
            //label17
            //(tp+tn)/(tp+tn+fp+fn)
            double accuracy = (tp + tn) / (fp + fn + tp + tn);
            accuracy = accuracy * 100;
            label17.Text = accuracy.ToString() + " %";
            label20.Text = precision.ToString();
            label22.Text = recall.ToString();
            label24.Text = fmeasure.ToString();
            using (SqlCommand cmd1 = new SqlCommand("truncate table graph_table", cn))
            {
                cn.Open();
                cmd1.ExecuteNonQuery();
                cn.Close();
            }
            using (SqlCommand cmdd = new SqlCommand("insert into graph_table(data_,value_) values(@data_,@value_)", cn))
            {
                //data_,value_
                cmdd.Parameters.AddWithValue("@data_", "tpr");
                cmdd.Parameters.AddWithValue("@value_", tpr);
                cn.Open();
                cmdd.ExecuteNonQuery();
                cn.Close();
            }
            using (SqlCommand cmdd = new SqlCommand("insert into graph_table(data_,value_) values(@data_,@value_)", cn))
            {
                //data_,value_
                cmdd.Parameters.AddWithValue("@data_", "tnr");
                cmdd.Parameters.AddWithValue("@value_", tnr);
                cn.Open();
                cmdd.ExecuteNonQuery();
                cn.Close();
            }
            using (SqlCommand cmdd = new SqlCommand("insert into graph_table(data_,value_) values(@data_,@value_)", cn))
            {
                //data_,value_
                cmdd.Parameters.AddWithValue("@data_", "fpr");
                cmdd.Parameters.AddWithValue("@value_", fpr);
                cn.Open();
                cmdd.ExecuteNonQuery();
                cn.Close();
            }
            using (SqlCommand cmdd = new SqlCommand("insert into graph_table(data_,value_) values(@data_,@value_)", cn))
            {
                //data_,value_
                cmdd.Parameters.AddWithValue("@data_", "fnr");
                cmdd.Parameters.AddWithValue("@value_", fnr);
                cn.Open();
                cmdd.ExecuteNonQuery();
                cn.Close();
            }
            using (SqlCommand cmdd = new SqlCommand("insert into graph_table(data_,value_) values(@data_,@value_)", cn))
            {
                //data_,value_
                cmdd.Parameters.AddWithValue("@data_", "precision");
                cmdd.Parameters.AddWithValue("@value_", precision);
                cn.Open();
                cmdd.ExecuteNonQuery();
                cn.Close();
            }
            using (SqlCommand cmdd = new SqlCommand("insert into graph_table(data_,value_) values(@data_,@value_)", cn))
            {
                //data_,value_
                cmdd.Parameters.AddWithValue("@data_", "recall");
                cmdd.Parameters.AddWithValue("@value_", recall);
                cn.Open();
                cmdd.ExecuteNonQuery();
                cn.Close();
            }
            using (SqlCommand cmdd = new SqlCommand("insert into graph_table(data_,value_) values(@data_,@value_)", cn))
            {
                //data_,value_
                cmdd.Parameters.AddWithValue("@data_", "fmeasure");
                cmdd.Parameters.AddWithValue("@value_", fmeasure);
                cn.Open();
                cmdd.ExecuteNonQuery();
                cn.Close();
            }
            DataTable dt4 = new DataTable();
            using (SqlCommand cmdr = new SqlCommand("select data_,value_ from graph_table", cn))
            {
                using (SqlDataAdapter dp = new SqlDataAdapter(cmdr))
                {
                    dp.Fill(dt4);
                }
                chart1.DataSource = dt4;
                chart1.Series["Series1"].XValueMember = "data_";
                chart1.Series["Series1"].YValueMembers = "value_";
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            }
        }
        SqlConnection cn = null;

        private void Calculate_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=url;Integrated Security=True");
        }

        private void fn_Click(object sender, EventArgs e)
        {
            false_negative obj = new false_negative();
            obj.Show();
            obj.WindowState = FormWindowState.Normal;

        }

        private void fp_Click(object sender, EventArgs e)
        {
            false_positive obj = new false_positive();
            obj.Show();
            obj.WindowState = FormWindowState.Normal;
        }

        private void tp_Click(object sender, EventArgs e)
        {
            true_positive obj = new true_positive();
            obj.Show();
            obj.WindowState = FormWindowState.Normal;
        }

        private void tn_Click(object sender, EventArgs e)
        {
            true_negative obj = new true_negative();
            obj.Show();
            obj.WindowState = FormWindowState.Normal;
        }
    }
}
