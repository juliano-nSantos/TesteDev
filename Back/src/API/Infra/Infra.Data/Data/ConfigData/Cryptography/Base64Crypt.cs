using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infra.Infra.Data.ConfigData.Cryptography
{
    public class Base64Crypt
    {
        public Encoding Encode { get; private set; }

        public Base64Crypt() : this(Encoding.Default)
        {            
        }

        public Base64Crypt(Encoding encode)
        {
            this.Encode = encode;
        }

        public string Encrypt(string text)
        {
            byte[] bytes = Encode.GetBytes(text);

            return Convert.ToBase64String(bytes);
        }

        public string Decrypt(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);

            return Encode.GetString(bytes);
        }
    }
}