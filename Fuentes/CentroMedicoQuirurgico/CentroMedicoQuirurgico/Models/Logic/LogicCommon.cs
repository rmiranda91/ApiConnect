using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicCommon
    {
        public static string encondeBase64(string str) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string decodeBase64(string strBase64)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(strBase64);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}