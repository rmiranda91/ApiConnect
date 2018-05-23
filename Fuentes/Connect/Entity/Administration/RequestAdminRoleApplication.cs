using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;
using System.Data;

namespace Entity.Administration
{
    public class RequestAdminRoleApplication : Request
    {
        public int id { get; set; }
        public int idRole { get; set; }
        public int idApplication { get; set; }
    }

    public class RequestAdminRoleApplicationList {
        public List<RequestAdminRoleApplication> lst { get; set; }
    }

    public class RequestAdminRoleApplicationData {
        public DataTable dtRoleApplication { get; set; }
    }

}
