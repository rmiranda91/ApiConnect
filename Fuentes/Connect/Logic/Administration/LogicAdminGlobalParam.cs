using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Administration;
using Data.Administration;
using Data.Error;
using Entity.Error;
using System.Data;

namespace Logic.Administration
{
    public class LogicAdminGlobalParam
    {
        public ResponseAdminGlobalParamList getAdminGlobalParamList(RequestAdminGlobalParam request) {
            try {
                DataTable dt = new DataTable();
                DataAdminGlobalParam datGlobalParam = new DataAdminGlobalParam();
                ResponseAdminGlobalParamDetail adminGlobalParam;
                ResponseAdminGlobalParamList response = new ResponseAdminGlobalParamList();

                dt = datGlobalParam.getAdminGlobalParam(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponseAdminGlobalParamDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            adminGlobalParam = new ResponseAdminGlobalParamDetail();

                            adminGlobalParam.id = dr["id"].ToString();
                            adminGlobalParam.value = dr["value"].ToString();
                            adminGlobalParam.detail = dr["detail"].ToString();
                            adminGlobalParam.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            adminGlobalParam.userRegister = dr["userRegister"].ToString();
                            adminGlobalParam.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            adminGlobalParam.userUpdate = dr["userUpdate"].ToString();
                            adminGlobalParam.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(adminGlobalParam);
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
                error.method = "getAdminGlobalParam";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
        }

        public ResponseAdminGlobalParam adminGlobalParam(RequestAdminGlobalParam request) {
            try {
                DataTable dt = new DataTable();
                DataAdminGlobalParam datGlobalParam = new DataAdminGlobalParam();
                ResponseAdminGlobalParam response = new ResponseAdminGlobalParam();

                dt = datGlobalParam.adminGlobalParam(request);

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
                error.method = "adminGlobalParam";
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
