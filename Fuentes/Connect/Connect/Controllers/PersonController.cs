using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Person;
using Entity.Error;
using Logic.Person;
using Logic.Error;


namespace Connect.Controllers
{
    public class PersonController : ApiController
    {
        [HttpPost]
        public ResponsePersonCrudList getPerson(RequestPersonCrud request)
        {
            ResponsePersonCrudList response = new ResponsePersonCrudList();

            try
            {
                LogicPersonCrud logicPerson = new LogicPersonCrud();
                response = logicPerson.getPersonCrudList(request);
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

                error.module = "PERSON";
                error.method = "getPerson";
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
        public ResponsePersonCrud crudPerson(RequestPersonCrud request)
        {
            ResponsePersonCrud response = new ResponsePersonCrud();

            try
            {
                LogicPersonCrud logicPerson = new LogicPersonCrud();
                request.dateRegister = System.DateTime.Now;
                request.dateUpdate = System.DateTime.Now;

                response = logicPerson.personCrud(request);
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

                error.module = "PERSON";
                error.method = "crudPerson";
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
