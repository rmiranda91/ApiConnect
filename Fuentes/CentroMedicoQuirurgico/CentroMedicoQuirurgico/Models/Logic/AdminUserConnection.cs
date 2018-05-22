using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity;
using Newtonsoft.Json;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class AdminUserConnection
    {
        public ValidateUserResponse validateUser(ValidateUserRequest request) {
            ValidateUserResponse response = new ValidateUserResponse();
            string URI = "http://localhost:3518/api/User/validate";
            string json = JsonConvert.SerializeObject(request);

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers[HttpRequestHeader.ContentEncoding] = "UTF-8";
                wc.Headers[HttpRequestHeader.Authorization] = "Basic " + LogicCommon.encondeBase64("clientDesktop:password");

                string HtmlResult = wc.UploadString(URI, json);

                response = JsonConvert.DeserializeObject<ValidateUserResponse>(HtmlResult);
            }


            return response;

        }

    }
}