using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Admin;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminClsMaster
    {
        public ResponseAdminClsMasterList getClsMasterList(RequestAdminClsMaster req)
        {
            ResponseAdminClsMasterList response = new ResponseAdminClsMasterList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("ClsMaster/getAdminClsMaster", req);
                response = JsonConvert.DeserializeObject<ResponseAdminClsMasterList>(json);

                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminClsMaster setClsMaster(RequestAdminClsMaster req)
        {
            ResponseAdminClsMaster response = new ResponseAdminClsMaster();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("ClsMaster/adminClsMaster", req);
                response = JsonConvert.DeserializeObject<ResponseAdminClsMaster>(json);

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