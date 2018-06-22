using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Administration
{
    public class ResponseAdminWareHouse : Response
    {
    }

    public class ResponseAdminWareHouseDetail {
        public int id { get; set; }
        public int idCompany { get; set; }
        public string description { get; set; }
        public string responsable { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponseAdminWareHouseList : Response {
        public List<ResponseAdminWareHouseDetail> lst { get; set; }
    }

}
