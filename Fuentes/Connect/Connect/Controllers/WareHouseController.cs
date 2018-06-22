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
    public class WareHouseController : ApiController
    {
        [HttpPost]
        public ResponseAdminWareHouseList getAdminWareHouse(RequestAdminWareHouse request)
        {
            ResponseAdminWareHouseList response = new ResponseAdminWareHouseList();

            try
            {
                LogicAdminWareHouse logic = new LogicAdminWareHouse();
                response = logic.getAdminWareHouseList(request);
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
                error.method = "getAdminWareHouseList";
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
        public ResponseAdminWareHouse adminWareHouse(RequestAdminWareHouse request)
        {
            ResponseAdminWareHouse response = new ResponseAdminWareHouse();

            try
            {
                LogicAdminWareHouse logic = new LogicAdminWareHouse();
                request.dateRegister = System.DateTime.Now;
                request.dateUpdate = System.DateTime.Now;

                response = logic.adminWareHouse(request);
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
                error.method = "adminWareHouse";
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
