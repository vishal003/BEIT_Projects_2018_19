using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace ColorSubstitutionCryptography
{
    public partial class CreateCryptographyImage : Form
    {
        public static string ImgPath = "";
        SaveFileDialog objSaveFileDialog = new SaveFileDialog();
        readonly List<Color> _objColors = new List<Color>();
        public CreateCryptographyImage()
        {
            InitializeComponent();
        }

        private void btnGenrate_Click(object sender, EventArgs e)
        {
            try
            {


                string messageToShow = "";
                int blockSize;
                bool flag = false;
                if (String.IsNullOrEmpty(txtMessage.Text))
                {
                    messageToShow = @"Enter message!{0}";
                    flag = true;
                }
                if (String.IsNullOrEmpty(txtBlockSize.Text))
                {
                    messageToShow += @"Enter block size{0}";
                    flag = true;
                }
                if (!int.TryParse(txtBlockSize.Text.Trim(), out blockSize))
                {
                    messageToShow += "Block size must be only number{0}";
                    flag = true;
                }
                if (blockSize <= 0)
                {
                    messageToShow += "Block size shouled be more than zero{0}";
                    flag = true;
                }
                if (!rdbRed.Checked && !rdbGreen.Checked && !rdbBlue.Checked)
                {
                    messageToShow += "Select color channel{0}";
                    flag = true;
                }
                int appendKey = 0;
                if (!Int32.TryParse(nudKey.Text, out appendKey))
                {
                    messageToShow += "Select Key{0}";
                }
                if (flag)
                {
                    MessageBox.Show(String.Format(messageToShow, Environment.NewLine), @"Error");
                    return;
                }
                // Spliting each character
                // Setting color code in list
                byte[] charBytes = Encoding.ASCII.GetBytes(txtMessage.Text.Trim());
                _objColors.Clear();
                foreach (var charByte in charBytes)
                {
                    var objColor = new Color();
                    if (rdbRed.Checked)
                    {
                        objColor = Color.FromArgb(255, (Convert.ToInt32(charByte) + appendKey), Convert.ToInt32(nudGreen.Text),
                            Convert.ToInt32(nudBlue.Text));
                    }
                    else if (rdbGreen.Checked)
                    {
                        objColor = Color.FromArgb(255, Convert.ToInt32(nudRed.Text), (Convert.ToInt32(charByte) + appendKey),
                            Convert.ToInt32(nudBlue.Text));
                    }
                    else if (rdbBlue.Checked)
                    {
                        objColor = Color.FromArgb(255, Convert.ToInt32(nudRed.Text),
                            Convert.ToInt32(nudGreen.Text), (Convert.ToInt32(charByte) + appendKey));
                    }
                    _objColors.Add(objColor);
                }

                // Setting up the width and height for the image

                // Getting the no of blocks horizontaly
                int widthBlocks = 800 / blockSize;
                // Getting the no of blocksverticaly
                int heightBlocks = 600 / blockSize;

                // Seting up the canvas for the image
                using (Bitmap objBmpImage = new Bitmap(800, 600))
                {
                    using (Graphics objGraphics = Graphics.FromImage(objBmpImage))
                    {
                        // Set Background color
                        objGraphics.Clear(Color.White);
                        objGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                        int indexForColors = 0;
                        // Looping forst for verical
                        for (int i = 0; i < heightBlocks; i++)
                        {
                            for (int j = 0; j < widthBlocks; j++)
                            {
                                if (indexForColors < charBytes.Count())
                                {
                                    objGraphics.FillRectangle(new SolidBrush(_objColors[indexForColors]),
                                        new Rectangle((j * blockSize), (i * blockSize), blockSize, blockSize));
                                    indexForColors++;
                                }
                            }
                        }
                        objGraphics.Flush();
                    }

                    objSaveFileDialog.InitialDirectory = @"Desktop\";
                    objSaveFileDialog.Title = @"Browse Image File";
                    objSaveFileDialog.DefaultExt = "Image";
                    objSaveFileDialog.Filter = @"JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                    if (DialogResult.OK != objSaveFileDialog.ShowDialog()) return;
                    objBmpImage.Save(objSaveFileDialog.FileName);
                    if (DialogResult.Yes ==
                        MessageBox.Show(
                            String.Format("Your image has been saved successfully.{0} Do you want to open the image?",
                                Environment.NewLine), @"Success", MessageBoxButtons.YesNo))
                    {
                        Process.Start(objSaveFileDialog.FileName);
                    }
                    ImgPath = objSaveFileDialog.FileName;

                    // Generating the decryption key
                    string channel = "";
                    if (rdbRed.Checked)
                    {
                        channel = "R";
                    }
                    else if (rdbGreen.Checked)
                    {
                        channel = "G";
                    }
                    else if (rdbBlue.Checked)
                    {
                        channel = "B";
                    }

                    String key = String.Format(@"BlockSize={0}|Channel={1}|Key={2}", blockSize, channel, appendKey);

                    var objEncryption = new CoreEncryption();
                    txtKey.Text = objEncryption.EncryptText(key);
                    btnSend.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            nudBlue.Text = nudGreen.Text = nudRed.Text = txtBlockSize.Text = txtKey.Text = txtMessage.Text = String.Empty;
            rdbBlue.Checked = rdbGreen.Checked = rdbRed.Checked = false;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            int chars = TextCountChecker();
            lblRemain.ForeColor = chars < 0 ? Color.Red : Color.Black;
            lblRemain.Text = String.Format(@"Number of characters remaining {0}", chars);
        }

        private void txtBlockSize_TextChanged(object sender, EventArgs e)
        {
            int chars = TextCountChecker();
            lblRemain.ForeColor = chars < 0 ? Color.Red : Color.Black;
            lblRemain.Text = String.Format(@"Number of characters remaining {0}", chars);
        }

        private int TextCountChecker()
        {
            var totalChars = txtMessage.Text.Trim().Count();
            var totalBlocks = 0;
            var blockSize = 0;
            if (totalChars < 1) return 0;
            if (!Int32.TryParse(txtBlockSize.Text.Trim(), out blockSize)) return 0;
            int row = 800 / blockSize;
            int col = 600 / blockSize;
            totalBlocks = ((800 / blockSize) * (600 / blockSize));
            return totalBlocks - totalChars;
        }

        #region notUsedEvents
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBlockSize_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        #endregion

        private void rdbRed_CheckedChanged(object sender, EventArgs e)
        {
            nudRed.Enabled = !rdbRed.Checked;
            nudGreen.Enabled = !rdbGreen.Checked;
            nudBlue.Enabled = !rdbBlue.Checked;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var objDialog = new OpenFileDialog
            {
                Title = @"Open Text File",
                Filter = @"TXT files|*.txt",
                InitialDirectory = @"C:\"
            })
            {
                if (objDialog.ShowDialog() != DialogResult.OK) return;
                try
                {
                    txtMessage.Text = File.ReadAllText(objDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtKey.Text == "")
            {
                MessageBox.Show("Please enter key");
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter email id");
                return;
            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("advancemail123@gmail.com");
                mail.To.Add(txtEmail.Text);
                mail.Subject = "Encrypted Image";
                mail.Body = "I have attached you a image and " + Environment.NewLine + " Key =" + txtKey.Text + ".";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(ImgPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("advancemail123@gmail.com", "Advance@123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
