using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkLibrary.Web
{
    public class Security : ISecurity
    {
        public string GetStringToHash(string @string)
        {
            return @string.Hash();
        }

        public string GetEncryptString(string plainText, string password)
        {
            return StringCrypt.Encrypt(plainText, password);

        }

        public string GetDecryptedString(string plainText, string password)
        {
            return StringCrypt.Decrypt(plainText, password);
        }
    }
}
