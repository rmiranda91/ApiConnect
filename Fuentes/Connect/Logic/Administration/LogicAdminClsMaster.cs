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
    public class LogicAdminClsMaster
    {
        public ResponseAdminClsMasterList getAdminClsMasterList(RequestAdminClsMaster request) {
            try {
                ResponseAdminClsMasterList response = new ResponseAdminClsMasterList();
                DataTable dt = new DataTable();
                DataAdminClsMaster data = new DataAdminClsMaster();
                ResponseAdminClsMasterDetail detail;

                request.catalogId = request.catalogId == null ? "" : request.catalogId;
                
                dt = data.getAdminClsMaster(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponseAdminClsMasterDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            detail = new ResponseAdminClsMasterDetail();

                            detail.id = int.Parse(dr["id"].ToString());
                            detail.catalogId = dr["catalogId"].ToString();
                            detail.value = dr["value"].ToString();
                            detail.subValue = dr["subValue"].ToString();
                            detail.detail = dr["detail"].ToString();
                            detail.child = bool.Parse(dr["child"].ToString());
                            detail.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            detail.userRegister = dr["userRegister"].ToString();
                            detail.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            detail.userUpdate = dr["userUpdate"].ToString();
                            detail.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(detail);
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
                error.method = "getAdminClsMasterList";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
        }

        public ResponseAdminClsMaster adminClsMaster(RequestAdminClsMaster request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminClsMaster dat = new DataAdminClsMaster();
                ResponseAdminClsMaster response = new ResponseAdminClsMaster();

                if (request.subValue == null) {
                    request.subValue = "";
                }
                if (request.detail == null) {
                    request.detail = "";
                }

                dt = dat.adminClsMaster(request);

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
                error.method = "adminClsMaster";
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
