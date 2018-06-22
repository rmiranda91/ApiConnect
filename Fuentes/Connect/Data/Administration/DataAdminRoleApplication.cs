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
    public class DataAdminRoleApplication
    {
        public DataTable getAdminRoleApplication(RequestAdminRoleApplication request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@id", request.idRole);
                
                response = db.executeDataTable("spGetAdminRoleApplication", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable adminRoleApplication(RequestAdminRoleApplicationData request)
        {
            try
            {
                DataTable response = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                DataBase db = new DataBase();

                param[0] = new SqlParameter("@tblRoleApplication", "tblRoleApplication");
                param[0].Value = request.dtRoleApplication;

                response = db.executeDataTable("spAdminRoleApplication", param);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
