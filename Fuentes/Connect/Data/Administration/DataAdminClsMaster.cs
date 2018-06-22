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
    public class DataAdminClsMaster
    {
        public DataTable getAdminClsMaster(RequestAdminClsMaster request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[3];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                param[1] = new SqlParameter("@catalogId", request.catalogId);
                param[2] = new SqlParameter("@filterChild", request.child);

                response = db.executeDataTable("spGetAdminClsMaster", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable adminClsMaster(RequestAdminClsMaster request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[12];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                param[1] = new SqlParameter("@catalogId", request.catalogId);
                param[2] = new SqlParameter("@value", request.value);
                param[3] = new SqlParameter("@subValue", request.subValue);
                param[4] = new SqlParameter("@detail", request.detail);
                param[5] = new SqlParameter("@child", request.child);
                param[6] = new SqlParameter("@stateRecord", request.stateRecord);
                param[7] = new SqlParameter("@userRegister", request.userRegister);
                param[8] = new SqlParameter("@dateRegister", request.dateRegister);
                param[9] = new SqlParameter("@userUpdate", request.userUpdate);
                param[10] = new SqlParameter("@dateUpdate", request.dateUpdate);
                param[11] = new SqlParameter("@flag", request.flag);

                response = db.executeDataTable("spAdminClsMaster", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
