﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Security.Cryptography;
using System.Data;

namespace Logic
{
    public class LogicPrincipal
    {
        public static string encryptSHA1(string str) {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static DataTable makeDt(string columns) {
            DataTable dt = new DataTable();
            string[] col = columns.Split(',');

            foreach (string c in col) {
                dt.Columns.Add(c);
            }

            return dt;
        }
    }
}
