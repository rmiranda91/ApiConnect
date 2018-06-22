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
    public class LogicAdminCompany
    {
        public ResponseAdminCompanyList getAdminCompanyList(RequestAdminCompany request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminCompany dat = new DataAdminCompany();
                ResponseAdminCompanyDetail admin;
                ResponseAdminCompanyList response = new ResponseAdminCompanyList();

                dt = dat.getAdminCompany(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponseAdminCompanyDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            admin = new ResponseAdminCompanyDetail();

                            admin.id = int.Parse(dr["id"].ToString());
                            admin.name = dr["name"].ToString();
                            admin.city = dr["city"].ToString();
                            admin.address = dr["address"].ToString();
                            admin.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            admin.userRegister = dr["userRegister"].ToString();
                            admin.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            admin.userUpdate = dr["userUpdate"].ToString();
                            admin.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(admin);
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
                error.method = "getAdminCompanyList";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }

        }

        public ResponseAdminCompany adminCompany(RequestAdminCompany request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminCompany datRole = new DataAdminCompany();
                ResponseAdminCompany response = new ResponseAdminCompany();

                dt = datRole.adminCompany(request);

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
                error.method = "adminCompany";
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
