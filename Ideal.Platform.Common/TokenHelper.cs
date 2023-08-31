using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Common
{
    public static class TokenHelper
    {

        public static string  GetTokenValue(string UserID)
        {
            string token = string.Empty;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            token = day + UserID + hour;
            token = MD5.MD5.Encrypt(token);
            return token;
        }
        public static string DecryptToken(string Token)
        {
            string encryptToken = MD5.MD5.Decrypt(Token);
            encryptToken = encryptToken.Substring(2, encryptToken.Length - 2);
            encryptToken = encryptToken.Substring(2, encryptToken.Length - 4);
            return encryptToken;
        }
    }
}
