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
    public class DataAdminRole
    {
        public DataTable getAdminRole(RequestAdminRole request) {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                response = db.executeDataTable("spGetAdminRole", param);

                return response;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable adminRole(RequestAdminRole request) {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[9];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                param[1] = new SqlParameter("@name", request.name);
                param[2] = new SqlParameter("@detail", request.detail);
                param[3] = new SqlParameter("@stateRecord", request.stateRecord);
                param[4] = new SqlParameter("@userRegister", request.userRegister);
                param[5] = new SqlParameter("@dateRegister", request.dateRegister);
                param[6] = new SqlParameter("@userUpdate", request.userUpdate);
                param[7] = new SqlParameter("@dateUpdate", request.dateUpdate);
                param[8] = new SqlParameter("@flag", request.flag);

                response = db.executeDataTable("spAdminRole", param);

                return response;
            }
            catch (Exception ex) {
                throw ex;
            }

        }


    }
}
