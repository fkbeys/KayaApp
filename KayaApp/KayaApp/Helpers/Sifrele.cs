using System;
using System.Security.Cryptography;
using System.Text;

namespace KayaApp.Helpers
{
    public class Sifrele
    {
        private static Sifrele mysifrele;



        public static Sifrele Getinstance()
        {
            if (mysifrele == null)
            {
                mysifrele = new Sifrele();

            }
            return mysifrele;

        }
        public static string SSifrele(string mytext)
        {
            Getinstance();
            byte[] data = UTF8Encoding.UTF8.GetBytes(mytext);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("kaya"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public static string Sifrecoz(string mytext, string myhash)
        {
            Getinstance();

            byte[] data = Convert.FromBase64String(mytext);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(myhash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }


    }
}