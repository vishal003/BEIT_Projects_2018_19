using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConsoleApplication1;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace PhishDetect.UserControls
{
    public partial class Ruleset : UserControl
    {
        private static string returnString = "";
        string path;
        // Create datatable
        private readonly DataTable _dataTable = new DataTable();

        public Ruleset()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
    

        }
 

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            _dataTable.Clear();
            // Load Data in grid
            if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
            {
                
                MetroFramework.MetroMessageBox.Show(this, "Select the Dataset File", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show(@"Select the dataset file");
                return;
            }
            // Featch lines
            String[] lineStrings = File.ReadAllLines(TextBox1.Text.Trim());



            if (!lineStrings.Any())
            {
                MetroFramework.MetroMessageBox.Show(this, "Text file does not contain any data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show(@"Text file does not contain any data");
                return;
            }


            // Featch Header
            var headerStrings = lineStrings[0].Split('\t');

            _dataTable.Clear();
            // Add coloumn in the datatable
            foreach (var header in headerStrings)
            {
                _dataTable.Columns.Add(header);
            }

            // Add Records
            // Starting from two because first is header and second line is comment
            for (int i = 1; i < lineStrings.Count(); i++)
            {
                String[] dataStrings = lineStrings[i].Split('\t');
                DataRow row = _dataTable.NewRow();
                for (int j = 0; j < dataStrings.Count(); j++)
                {
                    row[j] = dataStrings[j];
                }
                _dataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = _dataTable;
            Generate_ID3.Visible = true;
            Generate_Naive.Visible = false;
            pictureBox1.Visible = false;
            TextBox1.Visible = false;
            bunifuThinButton21.Visible = false;
            bunifuThinButton22.Visible = false;

        }





        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
         
            try
            {
                string pathCs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
               
                var objFileDialog = new OpenFileDialog
                {
                    Title = @"Open Text File",
                    Filter = @"TXT files|*.txt",
                    InitialDirectory = pathCs + @"\outputs"
            };
                if (objFileDialog.ShowDialog() != DialogResult.OK) return;
                   TextBox1.Text = objFileDialog.FileName;
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("SELECT FILE!!", "ERROR");
            }
        }




        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (String file in files)
                TextBox1.Text = files.First();
        }


        private void Genrate_ID3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            richTextBox1.Visible = true;
            var objId3 = new ID3();
            int status = objId3.ReadData(TextBox1.Text.Trim());
                if (status <= 0)
                {
                    return;
                }
                else
                {
                  
                    objId3.CreateDecisionTree();
                    string decisionTreeString = objId3.ReturnString;
                    richTextBox1.Text = decisionTreeString;
                    // Create File for project
                    var objBuilder = new StringBuilder();

                    objBuilder.AppendLine("using System; using System.IO; using System.Linq;");
                    objBuilder.Append("public class test {").AppendLine();

                    string createConstructor = "public test (";

                    for (int i = 0; i < _dataTable.Columns.Count; i++)
                    {

                        objBuilder.AppendFormat(" public String {0} ", _dataTable.Columns[i].ColumnName).Append("{get;set;}").AppendLine();

                    }
                    
                    for (int i = 0; i < _dataTable.Columns.Count - 1; i++)
                    {

                        createConstructor += String.Format("String {0}, ", _dataTable.Columns[i].ColumnName.ToLower());
                    }
                
                    objBuilder.Append(createConstructor.Substring(0, createConstructor.Length - 2)).Append(") {").AppendLine();
                    // Set parameter to properties
                    for (int i = 0; i < _dataTable.Columns.Count; i++)
                    {
                        objBuilder.AppendFormat("this.{0} = {1};", _dataTable.Columns[i].ColumnName,
                            _dataTable.Columns[i].ColumnName.ToLower()).AppendLine();
                    }
                
                    objBuilder.Append("}").AppendLine(); // End Of Constructor

                    // Start of method
                    objBuilder.AppendLine("public String UseRule() {");
                    objBuilder.AppendLine(decisionTreeString);
                    objBuilder.Append("}").AppendLine(); // End of Method

                    // Creatinon of main method
                    objBuilder.AppendLine("public static void Main(String[] args) {");
                    //objBuilder.AppendLine("String[] lineStrings = File.ReadAllLines(args[0]);");
                    //objBuilder.AppendLine(
                    //    "string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),\"test2014.txt\");");
                    //objBuilder.AppendLine("using(StreamWriter sw = File.AppendText(path)){");
                    //objBuilder.AppendLine("for (int i = 1; i < lineStrings.Count(); i++) {");//start of for
                    //objBuilder.AppendLine("String[] dataStrings = lineStrings[i].Split(' ');");
                    objBuilder.Append("test objTest = new test(");
                    for (int i = 0; i < _dataTable.Columns.Count; i++)
                    {
                                                if (i == _dataTable.Columns.Count - 1)
                            objBuilder.Append(");").AppendLine();
                        else
                            if (i < _dataTable.Columns.Count - 2)
                        {
                            objBuilder.AppendFormat("Convert.ToString(args[{0}]), ", i);
                        }
                        else
                        {
                            objBuilder.AppendFormat("Convert.ToString(args[{0}])", i);
                        }
                    }
                
                    objBuilder.AppendLine("string res=objTest.UseRule();");
                    objBuilder.AppendLine("Console.WriteLine(res);");
                    objBuilder.AppendLine("}");
                    // string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test2014.txt");

                    objBuilder.Append("}").AppendLine(); // End of class
                    var r = objBuilder.ToString();

                    string pathCs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    pathCs += @"\outputs\ID3Dump";
                if (!Directory.Exists(pathCs))
                    Directory.CreateDirectory(pathCs);

                // Delete existing files 
                Array.ForEach(Directory.GetFiles(pathCs), File.Delete);

                    using (var sw = new StreamWriter(pathCs + @"\test.cs"))
                    {
                        sw.Write(objBuilder.ToString());
                    }

                    // Compile the file
                    var frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
                    var cscPath = Path.Combine(frameworkPath, "csc.exe");
                

                    Process objProcess = new Process();
                    objProcess.StartInfo.WorkingDirectory = pathCs;

                    objProcess.StartInfo.FileName = cscPath;
                    objProcess.StartInfo.Arguments = "test.cs";
                    objProcess.StartInfo.UseShellExecute = false;
                    objProcess.StartInfo.RedirectStandardError = true;
                    objProcess.StartInfo.RedirectStandardOutput = true;
                    objProcess.StartInfo.CreateNoWindow = true;
                    objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    objProcess.StartInfo.RedirectStandardOutput = true;
                    objProcess.Start();
                    objProcess.WaitForExit();
                    StreamReader sr = objProcess.StandardOutput;
                    var responce = sr.ReadToEnd();
                }

            //    path = @"\\Projectideas\\h\\Project_2017_18\\final_version_code_id3_naive_bayes\\dataset.txt";
            //richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
            //MetroFramework.MetroMessageBox.Show(this, "Ruleset Generated at "+path, "System Training Done Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Generate_Naive_Click(object sender, EventArgs e)
        {
            var objNaive = new Naive();
            objNaive.CreateDatatable();
            SqlConnection cn = new SqlConnection("Data Source=Swapnli-pc;Initial Catalog=url;Integrated Security=True");
            MetroFramework.MetroMessageBox.Show(this, "Naive Bayes Training Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
