using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Administration;
using Entity.Error;
using Logic.Administration;
using Logic.Error;

namespace Connect.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public ResponseUserValidate validate(RequestUserValidate request) {
            ResponseUserValidate response = new ResponseUserValidate();

            try
            {
                LogicAdminUser logicUser = new LogicAdminUser();
                string userName = "";

                if (logicUser.validateUser(request.user, request.password, ref userName))
                {
                    response.code = 0;
                    response.message = "Correcto";
                    response.userName = userName;
                }
                else {
                    response.code = 1;
                    response.message = "Usuario y/o contraseña erroneos";
                }

            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                // Cuando sea una excepción por SQL ya vendrá el mensaje de error controlado
                response.code = exSql.ErrorCode;
                response.message = exSql.Message;
                response.status = exSql.State;
            }
            catch (Exception ex) {
                // Registrar el error real
                LogicLogError logicError = new LogicLogError();
                LogError error = new LogError();

                error.module = "LOGIN";
                error.method = "validateUser";
                error.errorMessage = ex.Message;
                error.moreInfo = null;

                logicError.newError(error);

                response.code = -1;
                response.message = "Ocurrio un error inesperado, favor avisar al administrador";
            }

            return response;
        }

        [HttpPost]
        public ResponseAdminUserList getAdminUser(RequestAdminUser request)
        {
            ResponseAdminUserList response = new ResponseAdminUserList();

            try
            {
                LogicAdminUser logicRole = new LogicAdminUser();
                response = logicRole.getAdminUserList(request);
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                // Cuando sea una excepción por SQL ya vendrá el mensaje de error controlado
                response.code = exSql.ErrorCode;
                response.message = exSql.Message;
                response.status = exSql.State;
            }
            catch (Exception ex)
            {
                // Registrar el error real
                LogicLogError logicError = new LogicLogError();
                LogError error = new LogError();

                error.module = "ADMIN";
                error.method = "getAdminUser";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                logicError.newError(error);

                response.code = -1;
                response.message = "Error no controlado, favor consultar con el administrador del sistema.";
                response.status = -1;
            }

            return response;
        }

        [HttpPost]
        public ResponseAdminUser adminUser(RequestAdminUser request)
        {
            ResponseAdminUser response = new ResponseAdminUser();

            try
            {
                LogicAdminUser logicUser = new LogicAdminUser();
                request.dateRegister = System.DateTime.Now;
                request.dateUpdate = System.DateTime.Now;

                response = logicUser.adminUser(request);
            }
            catch (System.Data.SqlClient.SqlException exSql)
            {
                // Cuando sea una excepción por SQL ya vendrá el mensaje de error controlado
                response.code = exSql.ErrorCode;
                response.message = exSql.Message;
                response.status = exSql.State;
            }
            catch (Exception ex)
            {
                // Registrar el error real
                LogicLogError logicError = new LogicLogError();
                LogError error = new LogError();

                error.module = "ADMIN";
                error.method = "adminUser";
                error.errorMessage = ex.Message;
                error.moreInfo = request.id.ToString();

                logicError.newError(error);

                response.code = -1;
                response.message = "Error no controlado, favor consultar con el administrador del sistema.";
            }

            return response;
        }
    }
}
