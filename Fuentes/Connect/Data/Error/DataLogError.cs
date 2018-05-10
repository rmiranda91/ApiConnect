using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Error;
using System.Data.SqlClient;
using System.Data;

namespace Data.Error
{
    public class DataLogError
    {
        public void newError(LogError error) {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("module", error.module);
            param[1] = new SqlParameter("method", error.method);
            param[2] = new SqlParameter("errorMessage", error.errorMessage);
            param[3] = new SqlParameter("moreInfo", error.moreInfo);

            db.executeNonQuery("spErrorNewError", param);
        }

    }
}
