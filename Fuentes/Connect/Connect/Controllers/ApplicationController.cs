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
    public class ApplicationController : ApiController
    {
        [HttpPost]
        public ResponseAdminApplicationList getAdminApplication(RequestAdminApplication request)
        {
            ResponseAdminApplicationList response = new ResponseAdminApplicationList();

            try
            {
                LogicAdminApplication logicApplication = new LogicAdminApplication();
                response = logicApplication.getAdminApplicationList(request);
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
                error.method = "getAdminApplication";
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
        public ResponseAdminApplication adminApplication(RequestAdminApplication request)
        {
            ResponseAdminApplication response = new ResponseAdminApplication();

            try
            {
                LogicAdminApplication logicApplication = new LogicAdminApplication();
                request.dateRegister = System.DateTime.Now;
                request.dateUpdate = System.DateTime.Now;

                response = logicApplication.adminApplication(request);
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
                error.method = "adminApplication";
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
