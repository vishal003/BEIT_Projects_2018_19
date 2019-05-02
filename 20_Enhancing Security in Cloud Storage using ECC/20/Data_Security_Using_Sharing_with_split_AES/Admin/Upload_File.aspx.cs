using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Diagnostics;



public partial class Upload_File : System.Web.UI.Page
{
    public int i, j, k;

    public static string fileName;
    public static string fileExtension;
    public static string file_path;
    public static string hashData;

    //Build the File Path for the original (input) and the encrypted (output) file.
    public static string input;
    public static string file_name1;
    public static string output1, output;
    public static string select_id;

    public static byte[] iv;
    public static byte[] encryptedMessage = null;
    public static string combindedString;
    public static byte[] bobKey;
    public static byte[] aliceKey;
    public static string data;
    string publicPrivateKeyXML;
    string publicOnlyKeyXML;
    private static RSACryptoServiceProvider rsa = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["a_id"] == "")
            {
                Response.Redirect("Login.aspx?msg=logout");

            }
            encryptedMessage = iv = bobKey = aliceKey = null;
            input = file_name1 = output1 = output = select_id = combindedString = data = string.Empty;
            lblPrivate.Visible = lblPublic.Visible = lblViewPrivate.Visible = lblViewPublic.Visible = btnEncryptData.Visible = false;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {

            fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
            fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            file_path = Path.GetFileName(FileUpload1.PostedFile.FileName);


            //Build the File Path for the original (input) and the encrypted (output) file.
            input = Server.MapPath("../Files/") + fileName + fileExtension;
            file_name1 = fileName + "_enc1" + fileExtension;
            output1 = Server.MapPath("../Files/" + file_name1);
            select_id = "select * from File_Info where file_name='" + file_path + "'";
            DataTable dt = Database.Getdata(select_id);
            if (dt.Rows.Count > 0)
            {
                Alert.Show("File Name Already Exists");
            }
            else
            {
                output = Server.MapPath("../Files/") + fileName + "_enc1" + fileExtension;
                //Save the Input File, Encrypt it and save the encrypted file in output path.
                FileUpload1.SaveAs(input);




                if (FileUpload1.HasFile)
                {

                    StreamReader reader = new StreamReader(FileUpload1.FileContent);
                    do
                    {
                        string textLine = reader.ReadLine();
                        //string.Concat(data,textLine);
                        if (data == string.Empty)
                            data = textLine;
                        else
                            data = data + "\n" + textLine;
                    } while (reader.Peek() != -1);
                    reader.Close();
                }

                #region hashing
                hashData = performHash(data);
                #endregion

                #region Keyword retrieving
                List<string> proses_tokenizing1;
                List<string> proses_stopword1;
                proses_tokenizing1 = tokenizing(data);
                proses_stopword1 = stopword(proses_tokenizing1);
                //string keywords_=string.Empty;
                combindedString = string.Join(" ", proses_stopword1.ToArray());
                #endregion



                byte[] bobPublicKey;

                using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
                {
                    string test = data;
                    alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                    alice.HashAlgorithm = CngAlgorithm.Sha256;
                    #region key generation
                    byte[] alicePublicKey = alice.PublicKey.ToByteArray();




                    using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
                    {

                        bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                        bob.HashAlgorithm = CngAlgorithm.Sha256;
                        bobPublicKey = bob.PublicKey.ToByteArray();
                        bobKey = bob.DeriveKeyMaterial(CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob));

                    }



                    CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);


                    aliceKey = alice.DeriveKeyMaterial(CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob));

                    #endregion



                    #region Encryption
                    using (Aes aes = new AesCryptoServiceProvider())
                    {
                        aes.Key = aliceKey;
                        iv = aes.IV;

                        using (MemoryStream ciphertext = new MemoryStream())
                        using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] plaintextMessage = Encoding.UTF8.GetBytes(data);
                            cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                            cs.Close();
                            encryptedMessage = ciphertext.ToArray();
                        }
                    }
                    #endregion




                    #region
                    lblPrivate.Visible = lblPublic.Visible = lblViewPrivate.Visible = lblViewPublic.Visible = btnEncryptData.Visible = true;

                    lblViewPublic.Text = Convert.ToBase64String(alicePublicKey);
                    lblViewPrivate.Text = Convert.ToBase64String(bobPublicKey);

                    #endregion

                }

            }
        }

    }


    private string performHash(string data)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(data);
        //SHA256Managed hashstring = new SHA256Managed();
        MD5 hashstring = System.Security.Cryptography.MD5.Create();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }
        return hashString;
    }

    private List<string> stopword(List<string> token)
    {
        string[] stopword = new string[1000];
        int m = stopword.GetLength(0);
        int n = token.Count();
        string[] _ceksplit = new string[n];
        bool sama = true;
        int jmlh = 0;
        FileStream sr = new FileStream(Server.MapPath("../Admin/stopwords.txt"), FileMode.Open);
        StreamReader str = new StreamReader(sr);
        int a = 0;
        while (!str.EndOfStream)
        {
            stopword[a] = str.ReadLine();
            a++;
        }
        sr.Close();
        str.Close();
        for (int j = 0; j < n; j++)
        {
            sama = true;
            for (int k = 0; k < m; k++)
            {
                if (token[j] == stopword[k])
                    sama = false;
            }
            if (sama != false)
            {
                _ceksplit[j] = token[j];
                jmlh++;
            }
        }
        List<string> words = new List<string>();
        for (int l = 0; l < n; l++)
        {
            if (_ceksplit[l] != null)
            {
                words.Add(_ceksplit[l]);
            }
        }
        return words;
    }

    private List<string> tokenizing(string isifile)
    {
        isifile = isifile.ToLower();
        char[] pemisah = new char[] { '~', '}', '{', '|', '*', ':', '\\', '_', '[', ']', '/', ';', '<', '>', ' ', '-', '=', '+', '.', ',', ',', '"', '!', '?', '@', '#', '$', '%', '^', '&', '(', ')', '\r', '\n', '\t', '\v', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        List<string> token = isifile.Split(pemisah, StringSplitOptions.RemoveEmptyEntries).ToList();
        return token;
    }

    protected void btnEncryptData_Click(object sender, EventArgs e)
    {


        #region Encryption
        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.Key = aliceKey;
            iv = aes.IV;

            using (MemoryStream ciphertext = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] plaintextMessage = Encoding.UTF8.GetBytes(data);
                cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                cs.Close();
                encryptedMessage = ciphertext.ToArray();
            }
        }
        #endregion
        //lblEnc.Text = Convert.ToBase64String(encryptedMessage);

        string data_t = Convert.ToBase64String(encryptedMessage);
        #region encrpted file
        StreamWriter writer = File.CreateText(output);
        writer.WriteLine(data_t);
        writer.Close();
        #endregion
        File.Delete(input);


        string connection_string = Database.cs;

        SqlCommand cmd = new SqlCommand("upload_data");
        var sqltype = CommandType.StoredProcedure;
        SqlParameter[] sqlpara = {
                                     new SqlParameter("@path",file_name1),
                                     new SqlParameter("@name",file_path),
                                     new SqlParameter("@key", Convert.ToBase64String(bobKey)),
                                     new SqlParameter("@iv",Convert.ToBase64String(iv)),
                                     new SqlParameter("@keyword",combindedString)
                                 };
        Database.Insertdata(connection_string, cmd, sqlpara, sqltype);

        cmd = new SqlCommand("uploadHashData");
        sqltype = CommandType.StoredProcedure;
        SqlParameter[] sqlpara2 = {
                                     new SqlParameter("@fname",file_path),
                                     new SqlParameter("@key1",Convert.ToBase64String(bobKey)),
                                     new SqlParameter("@hValue",hashData )
                                 };
        Database.Insertdata(connection_string, cmd, sqlpara2, sqltype);
        splitFile("test");
        File.Delete(Server.MapPath("../Files/" + file_name1));
        Response.Redirect("Manage Files.aspx?msg=add");//&time=" + time.ToString());


    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage Files.aspx");
    }

    protected void splitFile(string EncfilePath)
    {
        Byte[] byteSource = System.IO.File.ReadAllBytes(Server.MapPath("../Files/" + file_name1));

        FileInfo fiSource = new FileInfo(Server.MapPath("../Files/" + file_name1));

        int partSize = (int)Math.Ceiling((double)(fiSource.Length / 2));

        int sizeRemaining = (int)fiSource.Length;

        int fileOffset = 0;

        string currPartPath;

        FileStream fsPart;

        for (int i = 0; i < 2; i++)
        {

            currPartPath = Server.MapPath("../Files/") + fiSource.Name + "." + String.Format(@"{0:D4}", i) + ".part";

            if (!File.Exists(currPartPath))
            {
                fsPart = new FileStream(currPartPath, FileMode.CreateNew);

                sizeRemaining = (int)fiSource.Length - (i * partSize);

                if (sizeRemaining < partSize)
                {
                    partSize = sizeRemaining;
                }
                if (i != 1)
                {
                    fsPart.Write(byteSource, fileOffset, partSize);
                }
                else { fsPart.Write(byteSource, fileOffset, sizeRemaining); }
                fsPart.Close();
                fileOffset += partSize;
            }

        }
    }
}
