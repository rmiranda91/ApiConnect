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
    public class LogicAdminApplication
    {
        public ResponseAdminApplicationList getAdminApplicationList(RequestAdminApplication request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminApplication datApplication = new DataAdminApplication();
                ResponseAdminApplicationDetail adminApplication;
                ResponseAdminApplicationList response = new ResponseAdminApplicationList();

                dt = datApplication.getAdminApplication(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponseAdminApplicationDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            adminApplication = new ResponseAdminApplicationDetail();

                            adminApplication.id = int.Parse(dr["id"].ToString());
                            adminApplication.detail = dr["detail"].ToString();
                            adminApplication.href = dr["href"].ToString();
                            adminApplication.icon = dr["icon"].ToString();
                            adminApplication.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            adminApplication.userRegister = dr["userRegister"].ToString();
                            adminApplication.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            adminApplication.userUpdate = dr["userUpdate"].ToString();
                            adminApplication.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(adminApplication);
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
                error.method = "getAdminApplicationList";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }

        }

        public ResponseAdminApplication adminApplication(RequestAdminApplication request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminApplication datApplication = new DataAdminApplication();
                ResponseAdminApplication response = new ResponseAdminApplication();

                dt = datApplication.adminApplication(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
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
            catch (Exception ex)
            {
                // Registrar el error real
                DataLogError datError = new DataLogError();
                LogError error = new LogError();

                error.module = "ADMIN";
                error.method = "adminApplication";
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
