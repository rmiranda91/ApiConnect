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
    public class DataAdminCompany
    {
        public DataTable getAdminCompany(RequestAdminCompany request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                response = db.executeDataTable("spGetAdminCompany", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable adminCompany(RequestAdminCompany request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[10];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.id);
                param[1] = new SqlParameter("@name", request.name);
                param[2] = new SqlParameter("@city", request.city);
                param[3] = new SqlParameter("@address", request.address);
                param[4] = new SqlParameter("@stateRecord", request.stateRecord);
                param[5] = new SqlParameter("@userRegister", request.userRegister);
                param[6] = new SqlParameter("@dateRegister", request.dateRegister);
                param[7] = new SqlParameter("@userUpdate", request.userUpdate);
                param[8] = new SqlParameter("@dateUpdate", request.dateUpdate);
                param[9] = new SqlParameter("@flag", request.flag);

                response = db.executeDataTable("spAdminCompany", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
