using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class ResponseAdminClsMaster : Response
    {
    }

    public class ResponseAdminClsMasterDetail
    {
        public int id { get; set; }
        public string catalogId { get; set; }
        public string value { get; set; }
        public string subValue { get; set; }
        public string detail { get; set; }
        public bool child { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponseAdminClsMasterList : Response
    {
        public List<ResponseAdminClsMasterDetail> lst { get; set; }
    }
}