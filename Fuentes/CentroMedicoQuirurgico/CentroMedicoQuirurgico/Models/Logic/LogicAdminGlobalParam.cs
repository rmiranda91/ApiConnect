using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminGlobalParam
    {
        public ResponseAdminGlobalParamList getParameterList(RequestAdminGlobalParam req)
        {
            ResponseAdminGlobalParamList response = new ResponseAdminGlobalParamList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("GlobalParam/getAdminGlobalParam", req);
                response = JsonConvert.DeserializeObject<ResponseAdminGlobalParamList>(json);

                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminGlobalParam setGlobalParam(RequestAdminGlobalParam req)
        {
            ResponseAdminGlobalParam response = new ResponseAdminGlobalParam();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("GlobalParam/adminGlobalParam", req);
                response = JsonConvert.DeserializeObject<ResponseAdminGlobalParam>(json);

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