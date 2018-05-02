using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ivivu.lib
{
    public class hash
    {
        public hash()
        {
        }

        public string hashSourceKeyP(string source, string key, string provider)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] s = sha.ComputeHash(Encoding.UTF8.GetBytes(source));
            byte[] k = sha.ComputeHash(Encoding.UTF8.GetBytes(key));
            byte[] p = sha.ComputeHash(Encoding.UTF8.GetBytes(provider));
            byte[] r = new byte[60];
            p.CopyTo(r, 0);
            s.CopyTo(r, 0); 
            k.CopyTo(r, 0);
            return HttpServerUtility.UrlTokenEncode(r);
        }

        public string hashKeyToken(string key, string token)
        {
            var keyByte = Encoding.UTF8.GetBytes(key.ToUpper());
            string tokenHashString;

            using (var hmac = new HMACSHA256(keyByte))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(token));
                tokenHashString = Convert.ToBase64String(hash);
            }

            return tokenHashString;
        }
    }
}
