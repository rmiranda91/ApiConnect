using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity.Administration;

namespace Data.Administration
{
    public class DataAdminUser
    {
        public object validateUser(string user, string password) { 
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                DataBase db = new DataBase();
                object response = new object();

                param[0] = new SqlParameter("loginName", user);
                param[1] = new SqlParameter("personalKey", password);

                response = db.executeScalar("spAdminValidateUser", param);

                return response;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable getAdminUser(RequestAdminUser request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                response = db.executeDataTable("spGetAdminUser", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable adminUser(RequestAdminUser request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[13];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                param[1] = new SqlParameter("@idPerson", request.idPerson);
                param[2] = new SqlParameter("@loginName", request.loginName);
                param[3] = new SqlParameter("@personalKey", request.personalKey);
                param[4] = new SqlParameter("@attemps", request.attemps);
                param[5] = new SqlParameter("@name", request.name);
                param[6] = new SqlParameter("@idRole", request.idRole);
                param[7] = new SqlParameter("@stateRecord", request.stateRecord);
                param[8] = new SqlParameter("@userRegister", request.userRegister);
                param[9] = new SqlParameter("@dateRegister", request.dateRegister);
                param[10] = new SqlParameter("@userUpdate", request.userUpdate);
                param[11] = new SqlParameter("@dateUpdate", request.dateUpdate);
                param[12] = new SqlParameter("@flag", request.flag);

                response = db.executeDataTable("spAdminUser", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
