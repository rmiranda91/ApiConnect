using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Text;

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

        public string HttpPost(string method, Object request) {
            try
            {
                string uri = ConfigurationManager.AppSettings["urlApi"];
                string user = ConfigurationManager.AppSettings["usr"];
                string pwd = ConfigurationManager.AppSettings["pwd"];
                string json = JsonConvert.SerializeObject(request);
                string HtmlResult = "";

                // Completar la url agregandole el método
                uri += method;

                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
                    wc.Headers[HttpRequestHeader.ContentEncoding] = "UTF-8";
                    wc.Headers[HttpRequestHeader.Authorization] = "Basic " + LogicCommon.encondeBase64(user + ":" + pwd);

                    // Pasar a encoding UTF-8 el json
                    byte[] bytes = Encoding.UTF8.GetBytes(json);
                    json = Encoding.UTF8.GetString(bytes);

                    HtmlResult = wc.UploadString(uri, json);                    
                }

                return HtmlResult;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public string HttpGet(string method, string[] parameters = null) {
            try
            {
                string uri = ConfigurationManager.AppSettings["urlApi"];
                string user = ConfigurationManager.AppSettings["usr"];
                string pwd = ConfigurationManager.AppSettings["pwd"];
                string HtmlResult = "";
                int first = 0;

                // Completar la url agregandole el método
                uri += method;

                // Completar la url agregandole los parámetros
                if (parameters != null) {
                    foreach (string p in parameters) {
                        if (first == 0)
                            uri += "?" + p;
                        else
                            uri += "&" + p;
                    }
                }

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json;charset=utf-8";
                    wc.Headers[HttpRequestHeader.ContentEncoding] = "UTF-8";
                    wc.Headers[HttpRequestHeader.Authorization] = "Basic " + LogicCommon.encondeBase64(user + ":" + pwd);

                    HtmlResult = wc.DownloadString(uri);
                }

                return HtmlResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}