using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Alice
/// </summary>
public class Alice
{
    public static byte[] alicePublicKey;

  

    public static void Send(byte[] key, Byte[] secretMessage, out byte[] encryptedMessage, out byte[] iv)
    {
        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.Key = key;
            iv = aes.IV;

            // Encrypt the message 
            using (var ciphertext = new MemoryStream())
            using (var cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] plaintextMessage = secretMessage;
                cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                cs.Close();
                encryptedMessage = ciphertext.ToArray();
            }
        }
    }

    public static Byte[] Receive(byte[] encryptedMessage, byte[] bobKey, byte[] iv)
    {
        using (Aes aes = new AesCryptoServiceProvider())
        {
            aes.Key = bobKey;
            aes.IV = iv;

            // Decrypt the message 
            using (var plaintext = new MemoryStream())
            {
                using (var cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                    cs.Close();
                    return plaintext.ToArray();
                }
            }
        }
    }


}
public class Bob
{
    public byte[] bobKey;
    public byte[] bobPublicKey;

    public Bob()
    {
        using (var bob = new ECDiffieHellmanCng())
        {
            bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            bob.HashAlgorithm = CngAlgorithm.Sha256;
            bobPublicKey = bob.PublicKey.ToByteArray();
            bobKey = bob.DeriveKeyMaterial(CngKey.Import(Alice.alicePublicKey, CngKeyBlobFormat.EccPublicBlob));
        }
    }
}