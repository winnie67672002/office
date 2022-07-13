using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common
{
    public class PBKDF2Helper
    {
        public static string GetHashedPassword(string password, string salt)
        {

            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] hashBytes = KeyDerivation.Pbkdf2(
                password: password,//密碼
                salt: saltBytes,//加密的key
                prf: KeyDerivationPrf.HMACSHA1,//隨機函數
                iterationCount: 1000,//hash次數
                numBytesRequested: 16 //長度
            );
            string hashText = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hashText;

        }
    }
}
