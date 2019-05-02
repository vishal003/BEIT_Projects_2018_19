using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.API.Translate;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Mail;



namespace ColorSubstitutionCryptography
{
    public partial class createWithTranslator : Form
    {
        SaveFileDialog objSaveFileDialog = new SaveFileDialog();
        readonly List<Color> _objColors = new List<Color>();

        const int keySize = 1024;
        string publicAndPrivateKey;
        string publicKey;
        public static string ImgPath = "";

        byte[] plaintext;
        byte[] encryptedtext;
        public createWithTranslator()
        {
            InitializeComponent();
        }

        private void btnTranslator_Click(object sender, EventArgs e)
        {
            if (txtHindi.Text == "")
            {
                MessageBox.Show("Input Text is Blank");
                return;
            }
            //// WebClient client = new WebClient();
            //// string URL = ("https://www.googleapis.com/language/translate/v2?key=AIzaSyDFGyXxeZ2fCZpGo5ahEiolIqDR3NwU6PE");
            //// string value = client.DownloadString(URL);

            //// var a = JObject.Parse(value).SelectToken("data.translations");
            //// foreach (var item in a)
            //// {
            ////     txtMessage.Text = item.SelectToken("translatedText").ToString();
            ////}

            //// string URL = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", txtHindi.Text, "hi");


            //string URL = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=hi&dt=t&q=test";

            //////string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
            ////                                  Translator.LanguageEnumToIdentifier(sourceLanguage),
            ////                                  Translator.LanguageEnumToIdentifier(targetLanguage),
            ////                                  HttpUtility.UrlEncode(sourceText));

            ////string URL = "http://translate.google.com/?hl=&langpair=" + txtHindi.Text + "&source=hi&target=en";

            //WebClient webClient = new WebClient();
            //webClient.Encoding = System.Text.Encoding.UTF8;
            //string result = webClient.DownloadString(URL);
            //result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
            //result = result.Substring(result.IndexOf(">") + 1);
            //result = result.Substring(0, result.IndexOf("</span>"));
            Translator t = new Translator();
            //Hindi
            txtMessage.Text = t.Translate(txtHindi.Text.Trim(), "English", "Hindi");
            //return result.Trim();



        }

        public TimeSpan TranslationTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the url used to speak the translation.
        /// </summary>
        /// <value>The url used to speak the translation.</value>
        public string TranslationSpeechUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public Exception Error
        {
            get;
            private set;
        }




        private void rdbRed_CheckedChanged(object sender, EventArgs e)
        {
            nudRed.Enabled = !rdbRed.Checked;
            nudGreen.Enabled = !rdbGreen.Checked;
            nudBlue.Enabled = !rdbBlue.Checked;
        }

        private void rdbGreen_CheckedChanged(object sender, EventArgs e)
        {
            nudRed.Enabled = !rdbRed.Checked;
            nudGreen.Enabled = !rdbGreen.Checked;
            nudBlue.Enabled = !rdbBlue.Checked;
        }

        private void rdbBlue_CheckedChanged(object sender, EventArgs e)
        {
            nudRed.Enabled = !rdbRed.Checked;
            nudGreen.Enabled = !rdbGreen.Checked;
            nudBlue.Enabled = !rdbBlue.Checked;
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
                    messageToShow += "Select color chanal{0}";
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
                            String.Format("Your image has been saved successfully.{0} Do you want to open image?",
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
                    //var objEncryption = new CoreEncryption();
                    //txtKey.Text = objEncryption.EncryptText(key);

                    AsymmetricEncryption.GenerateKeys(keySize, out publicKey, out publicAndPrivateKey);
                    //string text = key;
                    string encrypted = AsymmetricEncryption.EncryptText(key, keySize, publicKey);
                    txtEncryptedText.Text = encrypted;
                    txtKey.Text = publicAndPrivateKey;
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
            Dispose();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter email id");
                return;
            }
            if (txtKey.Text == "")
            {
                MessageBox.Show("Please enter key");
                return;
            }
            if (txtEncryptedText.Text == "")
            {
                MessageBox.Show("Please enter encrypted text");
                return;
            }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("advancemail123@gmail.com");
                mail.To.Add(txtEmail.Text);
                mail.Subject = "Encrypted Image";
                mail.Body = "I have attached you a image and Key =" + txtKey.Text + "  and" + Environment.NewLine + " Text=" + txtEncryptedText.Text + "" + Environment.NewLine + " You can use this for decryption.";

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

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void createWithTranslator_Load(object sender, EventArgs e)
        {

        }
    }
}
