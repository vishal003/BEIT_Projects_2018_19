using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhishDetect
{
    class Naive
    {


        public void CreateDatatable()
        {
            int countres1 = 0, countres0 = 0;
            int countip00 = 0, countip01 = 0, countip10 = 0, countip11 = 0;
            int countlen00 = 0, countlen01 = 0, countlen10 = 0, countlen11 = 0;
            int countsus00 = 0, countsus01 = 0, countsus10 = 0, countsus11 = 0;
            int countpre00 = 0, countpre01 = 0, countpre10 = 0, countpre11 = 0;
            int countdot00 = 0, countdot01 = 0, countdot10 = 0, countdot11 = 0;
            int countsub00 = 0, countsub01 = 0, countsub10 = 0, countsub11 = 0;
            int countsla00 = 0, countsla01 = 0, countsla10 = 0, countsla11 = 0;
            int counthtt00 = 0, counthtt01 = 0, counthtt10 = 0, counthtt11 = 0;
            int countphi00 = 0, countphi01 = 0, countphi10 = 0, countphi11 = 0;
            double probres0 = 0, probres1 = 0;
            double probip00 = 0, probip01 = 0, probip10 = 0, probip11 = 0;
            double problen00 = 0, problen01 = 0, problen10 = 0, problen11 = 0;
            double probsus00 = 0, probsus01 = 0, probsus10 = 0, probsus11 = 0;
            double probpre00 = 0, probpre01 = 0, probpre10 = 0, probpre11 = 0;
            double probdot00 = 0, probdot01 = 0, probdot10 = 0, probdot11 = 0;
            double probsub00 = 0, probsub01 = 0, probsub10 = 0, probsub11 = 0;
            double probsla00 = 0, probsla01 = 0, probsla10 = 0, probsla11 = 0;
            double probhtt00 = 0, probhtt01 = 0, probhtt10 = 0, probhtt11 = 0;
            double probphi00 = 0, probphi01 = 0, probphi10 = 0, probphi11 = 0;

            SqlConnection cn = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=url;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results from features_dataset", cn);
           // SqlCommand cmddel = new SqlCommand("DELETE FROM [naive_prob]", cn);
           // SqlDataReader data = cmddel.ExecuteReader();
            //string sqltrunc = "TRUNCATE TABLE" + naive_prob
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cn.Close();
            int rowCount = dt.Rows.Count;
            int columnCount = dt.Columns.Count;
            //Create 2d array
            int[,] DataArray = new int[rowCount, columnCount];
            //Fill array from DataTable
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    DataArray[i, j] = (int)dt.Rows[i][j];
                }
            }
            //Count the number of 0 and 1 in result column
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, columnCount - 1] == 0)
                    countres0 = countres0 + 1;
                else
                    countres1 = countres1 + 1;
            }
            int x = countres0 + countres1;
            //Probability of results
            probres0 = (double)countres0 / rowCount;
            probres1 = (double)countres1 / rowCount;

            //Probability of IP CONTAINS
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 0] == 0 && DataArray[i, columnCount - 1] == 0)
                    countip00++;
                else if (DataArray[i, 0] == 0 && DataArray[i, columnCount - 1] == 1)
                    countip01++;
                else if (DataArray[i, 0] == 1 && DataArray[i, columnCount - 1] == 0)
                    countip10++;
                else
                    countip11++;
            }
            
            if(countip00 == 0 || countip01 == 0 || countip10 == 0 || countip11 == 0)
            {
                probip00 = (double)(countip00 + 1) / (countres0 + 1);
                probip01 = (double)(countip01 + 1) / (countres1 + 1);
                probip10 = (double)(countip10 + 1) / (countres0 + 1);
                probip11 = (double)(countip11 + 1) / (countres1 + 1);
            }
            else
            {
                probip00 = (double)countip00 / countres0;
                probip01 = (double)countip01 / countres1;
                probip10 = (double)countip10 / countres0;
                probip11 = (double)countip11 / countres1;
            }
           


            //Probability of LENGTH OF URL
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 1] == 0 && DataArray[i, columnCount - 1] == 0)
                    countlen00++;
                else if (DataArray[i, 1] == 0 && DataArray[i, columnCount - 1] == 1)
                    countlen01++;
                else if (DataArray[i, 1] == 1 && DataArray[i, columnCount - 1] == 0)
                    countlen10++;
                else
                    countlen11++;
            }

            if (countlen00 == 0 || countlen01 == 0 || countlen10 == 0 || countlen11 == 0)
            {
                problen00 = (double)(countlen00 + 1) / (countres0 + 1);
                problen01 = (double)(countlen01 + 1) / (countres1 + 1);
                problen10 = (double)(countlen10 + 1) / (countres0 + 1);
                problen11 = (double)(countlen11 + 1) / (countres1 + 1);
            }
            else
            {
                problen00 = (double)countlen00 / countres0;
                problen01 = (double)countlen01 / countres1;
                problen10 = (double)countlen10 / countres0;
                problen11 = (double)countlen11 / countres1;
            }

  


            //Probability of SUSPICIOUS CHARACTER
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 2] == 0 && DataArray[i, columnCount - 1] == 0)
                    countsus00++;
                else if (DataArray[i, 2] == 0 && DataArray[i, columnCount - 1] == 1)
                    countsus01++;
                else if (DataArray[i, 2] == 1 && DataArray[i, columnCount - 1] == 0)
                    countsus10++;
                else
                    countsus11++;
            }

            if (countsus00 == 0 || countsus01 == 0 || countsus10 == 0 || countsus11 == 0)
            {
                probsus00 = (double)(countsus00 + 1) / (countres0 + 1);
                probsus01 = (double)(countsus01 + 1) / (countres1 + 1);
                probsus10 = (double)(countsus10 + 1) / (countres0 + 1);
                probsus11 = (double)(countsus11 + 1) / (countres1 + 1);
            }
            else
            {
                probsus00 = (double)countsus00 / countres0;
                probsus01 = (double)countsus01 / countres1;
                probsus10 = (double)countsus10 / countres0;
                probsus11 = (double)countsus11 / countres1;
            }



            //Probability of PREFIX SUFFIX
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 3] == 0 && DataArray[i, columnCount - 1] == 0)
                    countpre00++;
                else if (DataArray[i, 3] == 0 && DataArray[i, columnCount - 1] == 1)
                    countpre01++;
                else if (DataArray[i, 3] == 1 && DataArray[i, columnCount - 1] == 0)
                    countpre10++;
                else
                    countpre11++;
            }

            if (countpre00 == 0 || countpre01 == 0 || countpre10 == 0 || countpre11 == 0)
            {
                probpre00 = (double)(countpre00 + 1) / (countres0 + 1);
                probpre01 = (double)(countpre01 + 1) / (countres1 + 1);
                probpre10 = (double)(countpre10 + 1) / (countres0 + 1);
                probpre11 = (double)(countpre11 + 1) / (countres1 + 1);
            }
            else
            {
                probpre00 = (double)countpre00 / countres0;
                probpre01 = (double)countpre01 / countres1;
                probpre10 = (double)countpre10 / countres0;
                probpre11 = (double)countpre11 / countres1;
            }
   
            //Probability of DOTS
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 4] == 0 && DataArray[i, columnCount - 1] == 0)
                    countdot00++;
                else if (DataArray[i, 4] == 0 && DataArray[i, columnCount - 1] == 1)
                    countdot01++;
                else if (DataArray[i, 4] == 1 && DataArray[i, columnCount - 1] == 0)
                    countdot10++;
                else
                    countdot11++;
            }

            if (countdot00 == 0 || countdot01 == 0 || countdot10 == 0 || countdot11 == 0)
            {
                probdot00 = (double)(countdot00 + 1) / (countres0 + 1);
                probdot01 = (double)(countdot01 + 1) / (countres1 + 1);
                probdot10 = (double)(countdot10 + 1) / (countres0 + 1);
                probdot11 = (double)(countdot11 + 1) / (countres1 + 1);
            }
            else
            {
                probdot00 = (double)countdot00 / countres0;
                probdot01 = (double)countdot01 / countres1;
                probdot10 = (double)countdot10 / countres0;
                probdot11 = (double)countdot11 / countres1;
            }


            //Probability of SUB DOMAINS
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 5] == 0 && DataArray[i, columnCount - 1] == 0)
                    countsub00++;
                else if (DataArray[i, 5] == 0 && DataArray[i, columnCount - 1] == 1)
                    countsub01++;
                else if (DataArray[i, 5] == 1 && DataArray[i, columnCount - 1] == 0)
                    countsub10++;
                else
                    countsub11++;
            }

            if (countsub00 == 0 || countsub01 == 0 || countsub10 == 0 || countsub11 == 0)
            {
                probsub00 = (double)(countsub00 + 1) / (countres0 + 1);
                probsub01 = (double)(countsub01 + 1) / (countres1 + 1);
                probsub10 = (double)(countsub10 + 1) / (countres0 + 1);
                probsub11 = (double)(countsub11 + 1) / (countres1 + 1);
            }
            else
            {
                probsub00 = (double)countsub00 / countres0;
                probsub01 = (double)countsub01 / countres1;
                probsub10 = (double)countsub10 / countres0;
                probsub11 = (double)countsub11 / countres1;
            }


            //Probability of SLASHES
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 6] == 0 && DataArray[i, columnCount - 1] == 0)
                    countsla00++;
                else if (DataArray[i, 6] == 0 && DataArray[i, columnCount - 1] == 1)
                    countsla01++;
                else if (DataArray[i, 6] == 1 && DataArray[i, columnCount - 1] == 0)
                    countsla10++;
                else
                    countsla11++;
            }

            if (countsla00 == 0 || countsla01 == 0 || countsla10 == 0 || countsla11 == 0)
            {
                probsla00 = (double)(countsla00 + 1) / (countres0 + 1);
                probsla01 = (double)(countsla01 + 1) / (countres1 + 1);
                probsla10 = (double)(countsla10 + 1) / (countres0 + 1);
                probsla11 = (double)(countsla11 + 1) / (countres1 + 1);
            }
            else
            {
                probsla00 = (double)countsla00 / countres0;
                probsla01 = (double)countsla01 / countres1;
                probsla10 = (double)countsla10 / countres0;
                probsla11 = (double)countsla11 / countres1;
            }

            //Probability of HTTP HAS
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 7] == 0 && DataArray[i, columnCount - 1] == 0)
                    counthtt00++;
                else if (DataArray[i, 7] == 0 && DataArray[i, columnCount - 1] == 1)
                    counthtt01++;
                else if (DataArray[i, 7] == 1 && DataArray[i, columnCount - 1] == 0)
                    counthtt10++;
                else
                    countsla11++;
            }
            if (counthtt00 == 0 || counthtt01 == 0 || counthtt10 == 0 || counthtt11 == 0)
            {
                probhtt00 = (double)(counthtt00 + 1) / (countres0 + 1);
                probhtt01 = (double)(counthtt01 + 1) / (countres1 + 1);
                probhtt10 = (double)(counthtt10 + 1) / (countres0 + 1);
                probhtt11 = (double)(counthtt11 + 1) / (countres1 + 1);
            }
            else
            {
                probhtt00 = (double)counthtt00 / countres0;
                probhtt01 = (double)counthtt01 / countres1;
                probhtt10 = (double)counthtt10 / countres0;
                probhtt11 = (double)counthtt11 / countres1;
            }


            //Probability of PHISH TERM
            for (int i = 0; i < rowCount; i++)
            {
                if (DataArray[i, 8] == 0 && DataArray[i, columnCount - 1] == 0)
                    countphi00++;
                else if (DataArray[i, 8] == 0 && DataArray[i, columnCount - 1] == 1)
                    countphi01++;
                else if (DataArray[i, 8] == 1 && DataArray[i, columnCount - 1] == 0)
                    countphi10++;
                else
                    countphi11++;
            }
            if (countphi00 == 0 || countphi01 == 0 || countphi10 == 0 || countphi11 == 0)
            {
                probphi00 = (double)(countphi00 + 1) / (countres0 + 1);
                probphi01 = (double)(countphi01 + 1) / (countres1 + 1);
                probphi10 = (double)(countphi10 + 1) / (countres0 + 1);
                probphi11 = (double)(countphi11 + 1) / (countres1 + 1);
            }
            else
            {
                probphi00 = (double)countphi00 / countres0;
                probphi01 = (double)countphi01 / countres1;
                probphi10 = (double)countphi10 / countres0;
                probphi11 = (double)countphi11 / countres1;
            }


            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    SqlCommand cmdd = new SqlCommand("insert into naive_prob(ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results) values(@ip_contains, @length_of_URL, @suspicious_char, @prefix_suffix, @dots, @sub_domain, @slash, @http_has, @phis_term,@results)", cn);
                    cn.Open();
                    cmdd.Parameters.AddWithValue("@ip_contains", probip00);
                    cmdd.Parameters.AddWithValue("@length_of_URL", problen00);
                    cmdd.Parameters.AddWithValue("@suspicious_char", probsus00);
                    cmdd.Parameters.AddWithValue("@prefix_suffix", probpre00);
                    cmdd.Parameters.AddWithValue("@dots", probdot00);
                    cmdd.Parameters.AddWithValue("@sub_domain", probsub00);
                    cmdd.Parameters.AddWithValue("@slash", probsla00);
                    cmdd.Parameters.AddWithValue("@http_has", probhtt00);
                    cmdd.Parameters.AddWithValue("@phis_term", probphi00);
                    cmdd.Parameters.AddWithValue("@results", probres0);
                    cmdd.ExecuteNonQuery();
                    cn.Close();
                }
                if(i==1)
                {
                    SqlCommand cmdd = new SqlCommand("insert into naive_prob(ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results) values(@ip_contains, @length_of_URL, @suspicious_char, @prefix_suffix, @dots, @sub_domain, @slash, @http_has, @phis_term,@results)", cn);
                    cn.Open();
                    cmdd.Parameters.AddWithValue("@ip_contains", probip01);
                    cmdd.Parameters.AddWithValue("@length_of_URL", problen01);
                    cmdd.Parameters.AddWithValue("@suspicious_char", probsus01);
                    cmdd.Parameters.AddWithValue("@prefix_suffix", probpre01);
                    cmdd.Parameters.AddWithValue("@dots", probdot01);
                    cmdd.Parameters.AddWithValue("@sub_domain", probsub01);
                    cmdd.Parameters.AddWithValue("@slash", probsla01);
                    cmdd.Parameters.AddWithValue("@http_has", probhtt01);
                    cmdd.Parameters.AddWithValue("@phis_term", probphi01);
                    cmdd.Parameters.AddWithValue("@results", probres1);
                    cmdd.ExecuteNonQuery();
                    cn.Close();
                }
                if (i == 2)
                {
                    SqlCommand cmdd = new SqlCommand("insert into naive_prob(ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results) values(@ip_contains, @length_of_URL, @suspicious_char, @prefix_suffix, @dots, @sub_domain, @slash, @http_has, @phis_term,@results)", cn);
                    cn.Open();
                    cmdd.Parameters.AddWithValue("@ip_contains", probip10);
                    cmdd.Parameters.AddWithValue("@length_of_URL", problen10);
                    cmdd.Parameters.AddWithValue("@suspicious_char", probsus10);
                    cmdd.Parameters.AddWithValue("@prefix_suffix", probpre10);
                    cmdd.Parameters.AddWithValue("@dots", probdot10);
                    cmdd.Parameters.AddWithValue("@sub_domain", probsub10);
                    cmdd.Parameters.AddWithValue("@slash", probsla10);
                    cmdd.Parameters.AddWithValue("@http_has", probhtt10);
                    cmdd.Parameters.AddWithValue("@phis_term", probphi10);
                    cmdd.Parameters.AddWithValue("@results", 0);
                    cmdd.ExecuteNonQuery();
                    cn.Close();
                }
                if (i == 3)
                {
                    SqlCommand cmdd = new SqlCommand("insert into naive_prob(ip_contains, length_of_URL, suspicious_char, prefix_suffix, dots, sub_domain, slash, http_has, phis_term,results) values(@ip_contains, @length_of_URL, @suspicious_char, @prefix_suffix, @dots, @sub_domain, @slash, @http_has, @phis_term,@results)", cn);
                    cn.Open();
                    cmdd.Parameters.AddWithValue("@ip_contains", probip11);
                    cmdd.Parameters.AddWithValue("@length_of_URL", problen11);
                    cmdd.Parameters.AddWithValue("@suspicious_char", probsus11);
                    cmdd.Parameters.AddWithValue("@prefix_suffix", probpre11);
                    cmdd.Parameters.AddWithValue("@dots", probdot11);
                    cmdd.Parameters.AddWithValue("@sub_domain", probsub11);
                    cmdd.Parameters.AddWithValue("@slash", probsla11);
                    cmdd.Parameters.AddWithValue("@http_has", probhtt11);
                    cmdd.Parameters.AddWithValue("@phis_term", probphi11);
                    cmdd.Parameters.AddWithValue("@results", 0);
                    cmdd.ExecuteNonQuery();
                    cn.Close();
                }
              
            }
          

        }
    }
}
