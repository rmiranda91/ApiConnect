using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;
using CentroMedicoQuirurgico.Models.Entity.Person;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminUser
    {
        public ResponseAdminUserList getUserList(RequestAdminUser req)
        {
            ResponseAdminUserList response = new ResponseAdminUserList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("User/getAdminUser", req);
                response = JsonConvert.DeserializeObject<ResponseAdminUserList>(json);

                // Cargar el listado completo de Roles
                RequestAdminRole reqRole = new RequestAdminRole();
                ResponseAdminRoleList resRole = new ResponseAdminRoleList();
                LogicAdminRole logicRole = new LogicAdminRole();
                List<SelectListItem> lstTmpRole = new List<SelectListItem>();

                // Obtener el listado completo de Roles
                reqRole.id = 0;
                resRole = logicRole.getRoleList(reqRole);

                // Llenar el listado de Roles
                foreach (ResponseAdminRoleDetail r in resRole.lst)
                {
                    lstTmpRole.Add(new SelectListItem
                    {
                        Text = r.detail,
                        Value = r.id.ToString(),
                        Selected = r.id == req.idRole ? true : false
                    });
                }

                // Agregar el listado de Roles
                response.lstRole = lstTmpRole;

                // Cargar el catálogo de tipos de documentos
                RequestAdminClsMaster reqCls = new RequestAdminClsMaster();
                ResponseAdminClsMasterList resCls = new ResponseAdminClsMasterList();
                LogicAdminClsMaster logicCls = new LogicAdminClsMaster();
                List<SelectListItem> lstTmpCls = new List<SelectListItem>();

                // Obtener el catálogo de tipos de documentos
                reqCls.catalogId = "TIPOSDOCUMENTO";
                reqCls.child = true;
                resCls = logicCls.getClsMasterList(reqCls);

                // Llenar el listado de acuerdo al catálogo
                foreach (ResponseAdminClsMasterDetail r in resCls.lst)
                {
                    lstTmpCls.Add(new SelectListItem
                    {
                        Text = r.detail,
                        Value = r.id.ToString(),
                        Selected = r.id == req.typeDocument ? true : false
                    });
                }

                // Agregar el listado del catálogo documentos
                response.lstTypeDocument = lstTmpCls;


                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminUser setUser(RequestAdminUser req)
        {
            ResponseAdminUser rUser = new ResponseAdminUser();
            ResponsePerson rPerson = new ResponsePerson();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = "";
                int idPerson = req.idPerson;
                int idUser = req.id;

                // Primero Registrar la persona
                if (req.flag != 'N')
                {
                    req.id = idPerson;
                }
                
                json = com.HttpPost("Person/crudPerson", req);
                rPerson = JsonConvert.DeserializeObject<ResponsePerson>(json);

                if (rPerson.code == 50000)
                {
                    if (req.flag == 'N')
                    {
                        req.idPerson = rPerson.status;
                    }
                    else {
                        req.id = idUser;
                    }
                    

                    // Completar el nombre completo para el usuario
                    req.name = req.firstName + " ";
                    req.name += req.secondName == null ? "" : req.secondName + " ";
                    req.name += req.firstLastName == null ? "" : req.firstLastName + " ";
                    req.name += req.secondLastName == null ? "" : req.secondLastName;

                    req.name = req.name.Trim();
                    // Ahora registrar el usuario
                    json = com.HttpPost("User/adminUser", req);
                    rUser = JsonConvert.DeserializeObject<ResponseAdminUser>(json);

                    // Revertir perfil de la persona, ya que no fue posible crear el usuario
                    if (rUser.code != 50000) { 

                    }
                }
                else {
                    rUser.code = -1;
                    rUser.message = "Error creando el perfil de la persona, favor contactar con el administrador del sistema";
                }

                return rUser;
            }
            catch (Exception ex)
            {
                rUser.code = -1;
                rUser.message = ex.Message;
            }

            return rUser;

        }
    }
}