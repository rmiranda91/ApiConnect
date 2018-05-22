using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Administration;
using Data.Error;
using Entity.Error;
using Entity.Administration;
using System.Data;

namespace Logic.Administration
{
    public class LogicAdminUser
    {
        public bool validateUser(string user, string password)
        {
            try
            {
                object objresponse = new object();
                bool response = false;
                DataAdminUser datUser = new DataAdminUser();
                string passwordEncrypt = LogicPrincipal.encryptSHA1(password);
                objresponse = datUser.validateUser(user, passwordEncrypt);

                if (objresponse != null)
                {
                    if (objresponse.ToString() == "ok")
                    {
                        response = true;
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                // Registrar el error real
                DataLogError datError = new DataLogError();
                LogError error = new LogError();

                error.module = "LOGIN";
                error.method = "validateUser";
                error.errorMessage = ex.Message;
                error.moreInfo = user + "\\" + password;

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error validando usuario API");
                throw exResult;
            }
        }

        public ResponseAdminUserList getAdminUserList(RequestAdminUser request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminUser datUser = new DataAdminUser();
                ResponseAdminUserDetail adminUser;
                ResponseAdminUserList response = new ResponseAdminUserList();

                dt = datUser.getAdminUser(request);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        response.code = 1;
                        response.message = "Se encontraron registros";
                        response.status = 1;
                        response.lst = new List<ResponseAdminUserDetail>();

                        foreach (DataRow dr in dt.Rows)
                        {
                            adminUser = new ResponseAdminUserDetail();

                            adminUser.id = int.Parse(dr["id"].ToString());
                            adminUser.idPerson = int.Parse(dr["idPerson"].ToString());
                            adminUser.loginName = dr["loginName"].ToString();
                            adminUser.personalKey = dr["personalKey"].ToString();
                            adminUser.attemps = int.Parse(dr["attemps"].ToString());
                            adminUser.name = dr["name"].ToString();
                            adminUser.idRole = int.Parse(dr["idRole"].ToString());
                            adminUser.stateRecord = bool.Parse(dr["stateRecord"].ToString());
                            adminUser.userRegister = dr["userRegister"].ToString();
                            adminUser.dateRegister = DateTime.Parse(dr["dateRegister"].ToString());
                            adminUser.userUpdate = dr["userUpdate"].ToString();
                            adminUser.dateUpdate = DateTime.Parse(dr["dateUpdate"].ToString());

                            response.lst.Add(adminUser);
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
                error.method = "getAdminUserList";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                datError.newError(error);

                // Modificar la excepción
                Exception exResult = new Exception("Error no controlado, favor consultar con el administrador del sistema.");
                throw exResult;
            }
        }

        public ResponseAdminUser adminUser(RequestAdminUser request)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAdminUser datUser = new DataAdminUser();
                ResponseAdminUser response = new ResponseAdminUser();
                request.personalKey = LogicPrincipal.encryptSHA1(request.personalKey);

                dt = datUser.adminUser(request);

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
                error.method = "adminUser";
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
