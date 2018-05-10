using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Administration;
using Data.Error;
using Entity.Error;

namespace Logic.Administration
{
    public class LogicAdminUserApi : LogicPrincipal
    {
        public bool validateUserApi(string user, string password) {
            try
            {
                object objresponse = new object();
                bool response = false;
                DataAdminUserApi datUserApi = new DataAdminUserApi();
                objresponse = datUserApi.validateUserApi(user, password);

                if (objresponse != null)
                {
                    if (objresponse.ToString() == "ok")
                    {
                        response = true;
                    }
                }

                return response;
            }
            catch (Exception ex) { 
                // Registrar el error real
                DataLogError datError = new DataLogError();
                LogError error = new LogError();

                error.module = "ADMIN";
                error.method = "validateUserApi";
                error.errorMessage = ex.Message;
                error.moreInfo = null;

                datError.newError(error);
                
                // Modificar la excepción
                Exception exResult = new Exception("Error validando usuario API");
                throw exResult;
            }
        }

    }
}
