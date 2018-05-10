using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data.Administration
{
    public class DataAdminUserApi
    {
        /// <summary>
        /// Validar si las credenciales proporcionadas para ejecutar métodos de la API son correctas
        /// </summary>
        /// <param name="user">usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns></returns>
        public object validateUserApi(string user, string password) {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                DataBase db = new DataBase();
                object response = new object();

                param[0] = new SqlParameter("loginName", user);
                param[1] = new SqlParameter("personalKey", password);

                response = db.executeScalar("spAdminValidateUserApi", param);

                return response;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

    }
}
