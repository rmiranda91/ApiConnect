using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminCompany
    {
        public ResponseAdminCompanyList getCompanyList(RequestAdminCompany req)
        {
            ResponseAdminCompanyList response = new ResponseAdminCompanyList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("Company/getAdminCompany", req);
                response = JsonConvert.DeserializeObject<ResponseAdminCompanyList>(json);

                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminCompany setCompany(RequestAdminCompany req)
        {
            ResponseAdminCompany response = new ResponseAdminCompany();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("Company/adminCompany", req);
                response = JsonConvert.DeserializeObject<ResponseAdminCompany>(json);

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