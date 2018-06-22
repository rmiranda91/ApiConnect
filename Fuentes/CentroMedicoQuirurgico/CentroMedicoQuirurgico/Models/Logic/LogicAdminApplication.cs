using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;


namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminApplication
    {
        public ResponseAdminApplicationList getApplicationList(RequestAdminApplication req)
        {
            ResponseAdminApplicationList response = new ResponseAdminApplicationList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("Application/getAdminApplication", req);
                response = JsonConvert.DeserializeObject<ResponseAdminApplicationList>(json);

                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminApplication setApplication(RequestAdminApplication req)
        {
            ResponseAdminApplication response = new ResponseAdminApplication();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("Application/adminApplication", req);
                response = JsonConvert.DeserializeObject<ResponseAdminApplication>(json);

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