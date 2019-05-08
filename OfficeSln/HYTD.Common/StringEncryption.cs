/*
 * ����ʱ�䣺2009.11.13
 * ���ߣ� ʩ��ƽ
 * �����ʼ���slpniuniu@163.com
 * QQ��114583858
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;

namespace HYTD.Common
{
    /// <summary>
    /// �ַ�������(DES����)
    /// </summary>
    public class StringEncryption
    {
        string iv = "HYTDCAPT";
        string key = "SHILPKEY";

        /// <summary>
        /// DES����ƫ������������>=8λ�����ַ���
        /// </summary>
        public string IV
        {
            get { return iv; }
            set { iv = value; }
        }

        /// <summary>
        /// DES���ܵ�˽Կ��������8λ�����ַ���
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// ���ַ�������DES����
        /// </summary>
        /// <param name="sourceString">�����ܵ��ַ���</param>
        /// <returns>���ܺ��BASE64������ַ���</returns>
        public string Encrypt(string sourceString)
        {
            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Encoding.Default.GetBytes(sourceString);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// ��DES���ܺ���ַ������н���
        /// </summary>
        /// <param name="encryptedString">�����ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public string Decrypt(string encryptedString)
        {
            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Convert.FromBase64String(encryptedString);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }

                    return Encoding.Default.GetString(ms.ToArray());
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// ���ļ����ݽ���DES����
        /// </summary>
        /// <param name="sourceFile">�����ܵ��ļ�����·��</param>
        /// <param name="destFile">���ܺ���ļ�����ľ���·��</param>
        public void EncryptFile(string sourceFile, string destFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException("ָ�����ļ�·�������ڣ�", sourceFile);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] btFile = File.ReadAllBytes(sourceFile);

            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(fs, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(btFile, 0, btFile.Length);
                        cs.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// ���ļ����ݽ���DES���ܣ����ܺ󸲸ǵ�ԭ�����ļ�
        /// </summary>
        /// <param name="sourceFile">�����ܵ��ļ��ľ���·��</param>
        public void EncryptFile(string sourceFile)
        {
            EncryptFile(sourceFile, sourceFile);
        }

        /// <summary>
        /// ���ļ����ݽ���DES����
        /// </summary>
        /// <param name="sourceFile">�����ܵ��ļ�����·��</param>
        /// <param name="destFile">���ܺ���ļ�����ľ���·��</param>
        public void DecryptFile(string sourceFile, string destFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException("ָ�����ļ�·�������ڣ�", sourceFile);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] btFile = File.ReadAllBytes(sourceFile);

            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(fs, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(btFile, 0, btFile.Length);
                        cs.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// ���ļ����ݽ���DES���ܣ����ܺ󸲸ǵ�ԭ�����ļ�
        /// </summary>
        /// <param name="sourceFile">�����ܵ��ļ��ľ���·��</param>
        public void DecryptFile(string sourceFile)
        {
            DecryptFile(sourceFile, sourceFile);
        }
    }
}
