using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class AdminUserConnection
    {
        public ValidateUserResponse validateUser(ValidateUserRequest request) {
            ValidateUserResponse response = new ValidateUserResponse();

            try
            {   
                LogicCommon com = new LogicCommon();
                string result = "";
                result = com.HttpPost("user/validate", request);
                response = JsonConvert.DeserializeObject<ValidateUserResponse>(result);
            }
            catch (Exception ex) {
                response.code = -1;
                response.message = "Ocurrio un error inesperado, favor avisar al administrador.";
            }

            return response;
        }

    }
}