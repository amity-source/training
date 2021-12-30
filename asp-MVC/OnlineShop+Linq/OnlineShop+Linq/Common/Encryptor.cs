using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OnlineShop_Linq.Common
{
    public static class Encryptor
    {
        public static string MD5Hash(string password)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            byte[] result = mD5.Hash;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            return stringBuilder.ToString();

        }
    }
}