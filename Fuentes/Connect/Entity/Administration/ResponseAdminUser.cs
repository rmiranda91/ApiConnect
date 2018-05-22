using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Administration
{
    public class ResponseAdminUser : Response { 
    }

    public class ResponseAdminUserDetail
    {
        public int id { get; set; }
        public int idPerson { get; set; }
        public string loginName { get; set; }
        public string personalKey { get; set; }
        public int attemps { get; set; }
        public string name { get; set; }
        public int idRole { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponseAdminUserList : Response
    {
        public List<ResponseAdminUserDetail> lst { get; set; }
    }
}
