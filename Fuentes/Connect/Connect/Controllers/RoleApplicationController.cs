using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic.Administration;
using Entity.Administration;
using Logic.Error;
using Entity.Error;

namespace Connect.Controllers
{
    public class RoleApplicationController : ApiController
    {
        [HttpPost]
        public ResponseAdminRoleApplicationList getAdminRoleApplication(RequestAdminRoleApplication request)
        {
            ResponseAdminRoleApplicationList response = new ResponseAdminRoleApplicationList();

            try
            {
                LogicAdminRoleApplication logicRoleApp = new LogicAdminRoleApplication();
                response = logicRoleApp.getAdminRoleApplicationList(request);
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
                error.method = "getAdminRole";
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
        public ResponseAdminRoleApplication adminRoleApplication(RequestAdminRoleApplicationList request)
        {
            ResponseAdminRoleApplication response = new ResponseAdminRoleApplication();

            try
            {
                LogicAdminRoleApplication logicRoleApp = new LogicAdminRoleApplication();
                response = logicRoleApp.adminRoleApplication(request);
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
                error.method = "adminRoleApplication";
                error.errorMessage = ex.Message;
                error.moreInfo = "";

                logicError.newError(error);

                response.code = -1;
                response.message = "Error no controlado, favor consultar con el administrador del sistema.";
            }

            return response;
        }
    }
}
