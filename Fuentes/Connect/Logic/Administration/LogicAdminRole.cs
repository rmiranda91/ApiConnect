using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity.Administration;
using Entity.Error;
using Data.Error;
using Data.Administration;

namespace Logic.Administration
{
    public class LogicAdminRole
    {
        public ResponseAdminRoleList getAdminRoleList(RequestAdminRole request) {
            try
            {
                DataTable dt = new DataTable();
                DataAdminRole datRole = new DataAdminRole();
                ResponseAdminRoleDetail adminRole;
                ResponseAdminRoleList response = new ResponseAdminRoleList();

                dt = datRole.getAdminRole(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponseAdminRoleDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            adminRole = new ResponseAdminRoleDetail();

                            adminRole.id = int.Parse(dr["id"].ToString());
                            adminRole.name = dr["name"].ToString();
                            adminRole.detail = dr["detail"].ToString();
                            adminRole.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            adminRole.userRegister = dr["userRegister"].ToString();
                            adminRole.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            adminRole.userUpdate = dr["userUpdate"].ToString();
                            adminRole.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(adminRole);
                        }
                    }
                    else
                    {
                        response.code = 0;
                        response.message = "No se encontraron registros";
                        response.status = 0;
                    }
                }
                else
                {
                    response.code = 0;
                    response.message = "No se encontraron registros";
                    response.status = 0;
                }

                return response;
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                // Cuando sea una excepción por SQL ya vendrá el mensaje de error controlado
                throw exSql;
            }
            catch (Exception ex)
            {
                // Registrar el error real
                DataLogError datError = new DataLogError();
                LogError error = new LogError();

                error.module = "ADMIN";
                error.method = "getAdminRoleList";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
            
        }

        public ResponseAdminRole adminRole(RequestAdminRole request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminRole datRole = new DataAdminRole();
                ResponseAdminRole response = new ResponseAdminRole();

                dt = datRole.adminRole(request);

                if (dt != null) {
                    if (dt.Rows.Count > 0) {
                        response.code = int.Parse(dt.Rows[0]["code"].ToString());
                        response.message = dt.Rows[0]["message"].ToString();
                        response.status = int.Parse(dt.Rows[0]["state"].ToString());
                    }
                }

                return response;
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                // Cuando sea una excepción por SQL ya vendrá el mensaje de error controlado
                throw exSql;
            }
            catch (Exception ex) {
                // Registrar el error real
                DataLogError datError = new DataLogError();
                LogError error = new LogError();

                error.module = "ADMIN";
                error.method = "adminRole";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
        }
    }
}
