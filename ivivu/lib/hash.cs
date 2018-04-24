using System;
using System.Security.Cryptography;
using System.Text;

namespace ivivu.lib
{
    public class hash
    {
        public hash()
        {
        }

        public string hashMD5(string source, string key)
        {
            HashAlgorithm md5hash = MD5.Create(key);
            byte[] hashResult = md5hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hashResult.Length; i++)
            {
                sBuilder.Append(hashResult[i].ToString("x2"));
            }
            return sBuilder.ToString();  
        }
    }
}
