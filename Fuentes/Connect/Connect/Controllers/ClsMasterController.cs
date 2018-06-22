using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Administration;
using Logic.Administration;
using Entity.Error;
using Logic.Error;

namespace Connect.Controllers
{
    public class ClsMasterController : ApiController
    {
        [HttpPost]
        public ResponseAdminClsMasterList getAdminClsMaster(RequestAdminClsMaster request)
        {
            ResponseAdminClsMasterList response = new ResponseAdminClsMasterList();

            try
            {
                LogicAdminClsMaster logic = new LogicAdminClsMaster();
                response = logic.getAdminClsMasterList(request);
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
                error.method = "getClsMaster";
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
        public ResponseAdminClsMaster adminClsMaster(RequestAdminClsMaster request)
        {
            ResponseAdminClsMaster response = new ResponseAdminClsMaster();

            try
            {
                LogicAdminClsMaster logic = new LogicAdminClsMaster();
                request.dateRegister = System.DateTime.Now;
                request.dateUpdate = System.DateTime.Now;

                response = logic.adminClsMaster(request);
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
                error.method = "adminClsMaster";
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
