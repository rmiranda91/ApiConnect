using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Person;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminPerson
    {
        public ResponsePersonList getPerson(RequestPerson req)
        {
            ResponsePersonList response = new ResponsePersonList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("Person/getPerson", req);
                response = JsonConvert.DeserializeObject<ResponsePersonList>(json);

                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }


    }
}