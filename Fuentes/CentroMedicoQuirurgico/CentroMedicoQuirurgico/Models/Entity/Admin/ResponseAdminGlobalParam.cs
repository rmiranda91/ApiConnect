using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class ResponseAdminGlobalParam : Response
    {
    }

    public class ResponseAdminGlobalParamDetail
    {
        public string id { get; set; }
        public string detail { get; set; }
        public string value { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponseAdminGlobalParamList : Response
    {
        public List<ResponseAdminGlobalParamDetail> lst { get; set; }
    }
}