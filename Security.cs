using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassBook
{
    internal class Security
    {

        private const string initVector = "lu08veji530t48u2";     // Change this string what ever you want
        private const string passPhrase = "z2dfc4d738504886890z"; // Change this string what ever you want
        private const int keysize = 256;

        public static string Encrypt(string plainText)
        {
            try
            {
                byte[] bytes1 = Encoding.UTF8.GetBytes(initVector);
                byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
                byte[] bytes3 = new PasswordDeriveBytes(passPhrase, (byte[])null).GetBytes(32);
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(bytes3, bytes1);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(bytes2, 0, bytes2.Length);
                cryptoStream.FlushFinalBlock();
                byte[] array = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                return Convert.ToBase64String(array);
            }
            catch
            {
                return (string)null;
            }
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                byte[] bytes1 = Encoding.ASCII.GetBytes(initVector);
                byte[] buffer = Convert.FromBase64String(cipherText);
                byte[] bytes2 = new PasswordDeriveBytes(passPhrase, (byte[])null).GetBytes(32);
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes2, bytes1);
                MemoryStream memoryStream = new MemoryStream(buffer);
                CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] numArray = new byte[buffer.Length];
                int count = cryptoStream.Read(numArray, 0, numArray.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(numArray, 0, count);
            }
            catch
            {
                return (string)null;
            }
        }

    }
}
