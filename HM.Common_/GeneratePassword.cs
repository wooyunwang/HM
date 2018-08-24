using System;
using System.Security.Cryptography;
using System.Text;

namespace HM.Common_
{
    public class GeneratePassword
    {
        public static string GeneratePasswordByUserName(string text)
        {
            text = ArrayReverse(text) + "vanke";

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(text));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static string ArrayReverse(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
