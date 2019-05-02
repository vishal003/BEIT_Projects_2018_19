using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorSubstitutionCryptography
{
    public partial class readWithTranslator : Form
    {
        const int keySize = 1024;
        public readWithTranslator()
        {
            InitializeComponent();
        }
        readonly OpenFileDialog _objFileDialog = new OpenFileDialog();
        private string _imagePath = "";


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == _objFileDialog.ShowDialog())
            {
                _imagePath = _objFileDialog.FileName;
                txtBrowse.Text = _imagePath;
            }
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtKey.Text.Length < 64)
                {
                    MessageBox.Show("Invalid key");
                    return;
                }
                bool flag = false;
                string messageToShow = "";
                if (string.IsNullOrEmpty(_imagePath))
                {
                    MessageBox.Show("Please select image file");
                    return;
                    //messageToShow += "Please select image file{0}";
                    //flag = true;
                }

                if (String.IsNullOrEmpty(txtKey.Text.Trim()))
                {
                    messageToShow += "Enter decryption key{0}";
                    flag = true;
                }
                if (string.IsNullOrEmpty(txtEncryptedText.Text.Trim()))
                {
                    messageToShow += "Enter decryption Text{0}";
                    flag = true;
                }
                Image objImage = Image.FromFile(_imagePath);
                if (objImage.Width != 800 && objImage.Height != 600)
                {
                    messageToShow += "Select image of size 800*600{0}";
                    flag = true;
                }

                if (flag)
                {
                    MessageBox.Show(String.Format(messageToShow, Environment.NewLine));
                    return;
                }

                var objEncryption = AsymmetricEncryption.DecryptText(txtEncryptedText.Text, keySize, txtKey.Text);

                string[] keyStrings = objEncryption.ToString().Split('|');
                int blockSize = 0;
                bool rFlag = false, gFlag = false, bFlag = false;
                int appendedKey = 0;
                if (keyStrings.Count() == 3)
                {
                    // Featching block size
                    string[] blockStrings = keyStrings[0].Split('=');
                    blockSize = Convert.ToInt32(blockStrings[1]);

                    // Featching Channel
                    string[] channeStrings = keyStrings[1].Split('=');
                    string channel = Convert.ToString(channeStrings[1]);
                    if (channel.Equals("R"))
                        rFlag = true;
                    else if (channel.Equals("G"))
                        gFlag = true;
                    else if (channel.Equals("B"))
                        bFlag = true;

                    // Featching Key
                    string[] appendStrings = keyStrings[2].Split('=');
                    appendedKey = Convert.ToInt32(appendStrings[1]);
                }

                var objColors = new List<Color>();

                using (var objBitmap = new Bitmap(objImage))
                {
                    // Getting the no of blocks horizontaly 
                    int widthBlocks = 800 / blockSize;
                    // Getting the no of blocksverticaly
                    int heightBlocks = 600 / blockSize;

                    for (int i = 0; i < heightBlocks; i++)
                    {
                        for (int j = 0; j < widthBlocks; j++)
                        {
                            objColors.Add(objBitmap.GetPixel(((j * blockSize) + (blockSize / 2)), ((i * blockSize) + (blockSize / 2))));
                        }
                    }
                }


                var objBytes = new byte[objColors.Count];

                for (int i = 0; i < objColors.Count; i++)
                {
                    if (rFlag)
                    {
                        if (objColors[i].R != 255)
                            objBytes[i] = (byte)(Convert.ToInt32(objColors[i].R) - appendedKey);
                    }
                    else if (gFlag)
                    {
                        if (objColors[i].G != 255)
                            objBytes[i] = (byte)(Convert.ToInt32(objColors[i].G) - appendedKey);
                    }
                    else if (bFlag)
                    {
                        if (objColors[i].B != 255)
                            objBytes[i] = (byte)(Convert.ToInt32(objColors[i].B) - appendedKey);
                    }
                }

                objBytes = objBytes.Where(x => x != 0).ToArray();
                txtMessage.Text = Encoding.ASCII.GetString(objBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.OK == _objFileDialog.ShowDialog())
            {
                _imagePath = _objFileDialog.FileName;
                txtBrowse.Text = _imagePath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void readWithTranslator_Load(object sender, EventArgs e)
        {

        }
    }
}
