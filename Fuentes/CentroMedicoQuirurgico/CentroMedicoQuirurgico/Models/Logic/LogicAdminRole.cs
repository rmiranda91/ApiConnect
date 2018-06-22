using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminRole
    {
        public ResponseAdminRoleList getRoleList(RequestAdminRole req) {
            ResponseAdminRoleList response = new ResponseAdminRoleList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("Role/getAdminRole", req);
                response = JsonConvert.DeserializeObject<ResponseAdminRoleList>(json);
                
                return response;
            }
            catch (Exception ex) {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminRole setRole(RequestAdminRole req) {
            ResponseAdminRole response = new ResponseAdminRole();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("Role/adminRole", req);
                response = JsonConvert.DeserializeObject<ResponseAdminRole>(json);

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