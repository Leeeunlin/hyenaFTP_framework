using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TripleDES
{

    public class TripleDES_Encryptor
    {
        //Variable
        public static byte[] INIT_VEC = { 0x01, 0x02, 0x01, 0x06, 0x02, 0x09, 0x05, 0x03 };
        public static byte[] BYTES_KEY = { 0x71, 0x81, 0x3C, 0x72, 0x4A, 0x43, 0xD6, 0x82, 0xA2, 0x66, 0xD7, 0xB7, 0x31, 0x61, 0x71, 0x17 };


        //TripleDES_Encryptor()
        public TripleDES_Encryptor()
        {
        }

        //Encrypt(string strData)
        public static string Encrypt(string strData)
        {
            if (strData == null)
            {

            }
            else
            {
                if (strData.Trim().Length > 0)
                {
                    return Encrypt(strData, null);
                }
            }

            return "";
        }


        //Encrypt(string strData, string key)
        public static string Encrypt(string strData, string key)
        {
            string trim_key = key;

            if (key != null)
            {
                if (trim_key.Length > 15)
                {
                    trim_key = trim_key.Substring(0, 15);
                }
            }

            System.Text.UTF8Encoding oEncoding = new System.Text.UTF8Encoding();
            byte[] ba = oEncoding.GetBytes(strData);
            byte[] ba2 = Encrypt(ba, GetKeyByteArray(trim_key));

            //Normal

            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(System.Convert.ToBase64String(ba2)));


        }


        //Encrypt(byte[] bytesData)
        public static byte[] Encrypt(byte[] bytesData)
        {
            return Encrypt(bytesData, null);
        }


        //Encrypt(byte[] bytesData, byte[] key)
        public static byte[] Encrypt(byte[] bytesData, byte[] key)
        {
            MemoryStream memStreamEncryptedData = null;
            ICryptoTransform transform = null;
            CryptoStream encStream = null;

            byte[] rt = null;

            try
            {
                memStreamEncryptedData = new MemoryStream();
                transform = GetCryptoServiceProvider(key);
                encStream = new CryptoStream(memStreamEncryptedData,
                    transform,
                    CryptoStreamMode.Write);

                encStream.Write(bytesData, 0, bytesData.Length);
                encStream.FlushFinalBlock();

                rt = memStreamEncryptedData.ToArray();
            }
            finally
            {
                if (encStream != null) encStream.Close();
                if (transform != null) transform.Dispose();
                if (memStreamEncryptedData != null) memStreamEncryptedData.Close();
            }

            return rt;
        }


        //GetCryptoServiceProvider(byte[] key)
        private static ICryptoTransform GetCryptoServiceProvider(byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;
            if (key == null) des.Key = TripleDES_Encryptor.BYTES_KEY;
            else des.Key = key;
            des.IV = TripleDES_Encryptor.INIT_VEC;

            return des.CreateEncryptor();
        }


        //GetKeyByteArray
        private static byte[] GetKeyByteArray(string str)
        {
            if (str == null)
            {
                return null;
            }

            byte[] byteTemp = new byte[16];

            str = str.PadRight(16);

            byteTemp = Encoding.Default.GetBytes(str);

            return byteTemp;
        }

    }

    public class TripleDES_Decryptor
    {
        //TripleDES_Decryptor()
        public TripleDES_Decryptor()
        {
        }


        //Decrypt(string strData)
        public static string Decrypt(string strData)
        {
            if (strData.Trim().Length > 0)
            {
                return Decrypt(strData, null);
            }
            else
            {
                return "";
            }
        }


        //Decrypt(string strData, string key)
        public static string Decrypt(string strData, string key)
        {
            string trim_key = key;

            if (key != null)
            {
                if (trim_key.Length > 15)
                {
                    trim_key = trim_key.Substring(0, 15);
                }
            }

            System.Text.UTF8Encoding oEncoding = null;

            //Normal

            byte[] ba0 = System.Convert.FromBase64String(strData);
            byte[] ba1 = System.Convert.FromBase64String(Encoding.UTF8.GetString(ba0));

            byte[] ba2 = Decrypt(ba1, GetKeyByteArray(trim_key));
            oEncoding = new System.Text.UTF8Encoding();
            return oEncoding.GetString(ba2);


        }


        //Decrypt(byte[] bytesData)
        public static byte[] Decrypt(byte[] bytesData)
        {
            return Decrypt(bytesData, null);
        }


        //Decrypt(byte[] bytesData, byte[] key)
        public static byte[] Decrypt(byte[] bytesData, byte[] key)
        {
            MemoryStream memStreamDecryptedData = null;
            ICryptoTransform transform = null;
            CryptoStream decStream = null;

            byte[] rt = null;

            try
            {
                memStreamDecryptedData = new MemoryStream();
                transform = GetCryptoServiceProvider(key);
                decStream = new CryptoStream(memStreamDecryptedData,
                    transform,
                    CryptoStreamMode.Write);

                decStream.Write(bytesData, 0, bytesData.Length);
                decStream.FlushFinalBlock();

                rt = memStreamDecryptedData.ToArray();
            }
            finally
            {
                if (decStream != null) decStream.Close();
                if (transform != null) transform.Dispose();
                if (memStreamDecryptedData != null) memStreamDecryptedData.Close();
            }

            return rt;
        }


        //GetCryptoServiceProvider(byte[] key)
        private static ICryptoTransform GetCryptoServiceProvider(byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;
            if (key == null) des.Key = TripleDES_Encryptor.BYTES_KEY;
            else des.Key = key;
            des.IV = TripleDES_Encryptor.INIT_VEC;

            return des.CreateDecryptor();
        }


        //GetKeyByteArray
        private static byte[] GetKeyByteArray(string str)
        {
            if (str == null)
            {
                return null;
            }

            byte[] byteTemp = new byte[16];

            str = str.PadRight(16);

            byteTemp = Encoding.Default.GetBytes(str);

            return byteTemp;
        }

    }

}
