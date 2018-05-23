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
    public class LogicAdminRoleApplication
    {
        public ResponseAdminRoleApplicationList getAdminRoleApplicationList(RequestAdminRoleApplication request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminRoleApplication datRoleApp = new DataAdminRoleApplication();
                ResponseAdminRoleApplicationDetail adminRoleApp;
                ResponseAdminRoleApplicationList response = new ResponseAdminRoleApplicationList();

                dt = datRoleApp.getAdminRoleApplication(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponseAdminRoleApplicationDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            adminRoleApp = new ResponseAdminRoleApplicationDetail();

                            adminRoleApp.id = int.Parse(dr["id"].ToString());
                            adminRoleApp.idRole = int.Parse(dr["idRole"].ToString());
                            adminRoleApp.idApplication = int.Parse(dr["idApplication"].ToString());
                            adminRoleApp.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            adminRoleApp.userRegister = dr["userRegister"].ToString();
                            adminRoleApp.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            adminRoleApp.userUpdate = dr["userUpdate"].ToString();
                            adminRoleApp.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(adminRoleApp);
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
                error.method = "getAdminRoleApplicationList";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }

        }

        public ResponseAdminRoleApplication adminRoleApplication(RequestAdminRoleApplicationList request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dtRoleApp = LogicPrincipal.makeDt("id,idRole,idApplication,stateRecord,userRegister,dateRegister,userUpdate,dateUpdate,flag");
                DataAdminRoleApplication datRoleApplication = new DataAdminRoleApplication();
                RequestAdminRoleApplicationData requesData = new RequestAdminRoleApplicationData();
                ResponseAdminRoleApplication response = new ResponseAdminRoleApplication();

                // Transformar la lista a un DataTable
                foreach (RequestAdminRoleApplication i in request.lst) {
                    DataRow r = dtRoleApp.NewRow();

                    r["id"] = i.id.ToString();
                    r["idRole"] = i.idRole.ToString();
                    r["idApplication"] = i.idApplication.ToString();
                    r["stateRecord"] = i.stateRecord.ToString();
                    r["userRegister"] = i.userRegister.ToString();
                    r["dateRegister"] = i.dateRegister.ToString();
                    r["userUpdate"] = i.userUpdate.ToString();
                    r["dateUpdate"] = i.dateUpdate.ToString();
                    r["flag"] = "N";
                    
                    dtRoleApp.Rows.Add(r);
                }

                requesData.dtRoleApplication = dtRoleApp;

                dt = datRoleApplication.adminRoleApplication(requesData);

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
                error.method = "adminRoleApplication";
                error.errorMessage = ex.Message;
                error.moreInfo = "";

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
        }
    }
}
