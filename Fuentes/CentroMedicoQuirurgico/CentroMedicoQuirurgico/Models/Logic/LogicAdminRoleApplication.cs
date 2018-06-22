using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;
using System.ComponentModel;
using System.Web.Mvc;


namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminRoleApplication
    {
        public ResponseAdminRoleApplicationList getRoleApplicationList(RequestAdminRoleApplication req, string id)
        {
            ResponseAdminRoleApplicationList response = new ResponseAdminRoleApplicationList();

            try
            {
                // Primero obtener el listado de Roles
                RequestAdminRole reqRole = new RequestAdminRole();
                ResponseAdminRoleList resRole = new ResponseAdminRoleList();
                LogicAdminRole logicRole = new LogicAdminRole();

                // Obtener el listado completo de Roles
                reqRole.id = 0;
                resRole = logicRole.getRoleList(reqRole);

                // Si no se manda un Rol, obtener los permisos del primero
                if (id == null)
                {
                    req.idRole = resRole.lst[0].id;
                }
                else
                {
                    req.idRole = int.Parse(id);
                }

                // Obtener el listado completo de opciones
                RequestAdminApplication reqApp = new RequestAdminApplication();
                ResponseAdminApplicationList resApp = new ResponseAdminApplicationList();
                LogicAdminApplication logicApp = new LogicAdminApplication();

                reqApp.id = 0;
                resApp = logicApp.getApplicationList(reqApp);

                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("RoleApplication/getAdminRoleApplication", req);
                response = JsonConvert.DeserializeObject<ResponseAdminRoleApplicationList>(json);
                List<SelectListItem> lst = new List<SelectListItem>();

                // Llenar el listado de Roles
                foreach (ResponseAdminRoleDetail r in resRole.lst) {
                    lst.Add(new SelectListItem
                    {
                        Text = r.detail,
                        Value = r.id.ToString(),
                        Selected = r.id == req.idRole ? true : false
                    });
                }

                // Agregar el listado de Roles
                response.lstRole = lst;
                // Agregar el listado de aplicaciones
                response.lstApplication = resApp.lst;

                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminRoleApplication setApplication(RequestAdminRoleApplicationList req)
        {
            ResponseAdminRoleApplication response = new ResponseAdminRoleApplication();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("RoleApplication/adminRoleApplication", req);
                response = JsonConvert.DeserializeObject<ResponseAdminRoleApplication>(json);

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