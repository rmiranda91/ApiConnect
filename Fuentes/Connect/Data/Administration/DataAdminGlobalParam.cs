using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Administration;
using System.Data;
using System.Data.SqlClient;

namespace Data.Administration
{
    public class DataAdminGlobalParam
    {
        public DataTable getAdminGlobalParam(RequestAdminGlobalParam request) {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                response = db.executeDataTable("spGetAdminGlobalParam", param);

                return response;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable adminGlobalParam(RequestAdminGlobalParam request) {
            try {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[9];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                param[1] = new SqlParameter("@detail", request.detail);
                param[2] = new SqlParameter("@value", request.value);
                param[3] = new SqlParameter("@stateRecord", request.stateRecord);
                param[4] = new SqlParameter("@userRegister", request.userRegister);
                param[5] = new SqlParameter("@dateRegister", request.dateRegister);
                param[6] = new SqlParameter("@userUpdate", request.userUpdate);
                param[7] = new SqlParameter("@dateUpdate", request.dateUpdate);
                param[8] = new SqlParameter("@flag", request.flag);
                
                response = db.executeDataTable("spAdminGlobalParam", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
