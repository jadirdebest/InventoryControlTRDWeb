using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.CrossCutting.Security
{
    public static class Utilities
    {
        public static string CreateMD5(string word)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(word));
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    strBuilder.Append(data[i].ToString("x2"));
                }
                return strBuilder.ToString();
            }
        }

        public static bool MD5IsMatch(string word, string hash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var wordCript = CreateMD5(word);
                StringComparer compara = StringComparer.OrdinalIgnoreCase;

                if (0 == compara.Compare(wordCript, hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
