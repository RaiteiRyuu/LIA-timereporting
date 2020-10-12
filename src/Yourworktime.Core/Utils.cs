﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Yourworktime.Core
{
    internal static class Utils
    {
        public static string ComputeSha256Hash(string rawData)
        { 
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString());
                }
                return builder.ToString();
            }
        }

        public static string GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < salt.Length; i++)
            {
                builder.Append(salt[i].ToString());
            }
            return builder.ToString();
        }
    }

    internal static class Extensions
    {
        public static string UppercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}