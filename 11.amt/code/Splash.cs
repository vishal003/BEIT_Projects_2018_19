using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Reflection;

namespace ColorSubstitutionCryptography
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i < 101; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(5);
                // Report progress.
                bgWorker.ReportProgress(i);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            Text = e.ProgressPercentage.ToString(CultureInfo.InvariantCulture);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(5);
            Hide();
            var objLogin = new Login();
            objLogin.Show();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync();
        }
    }
}
