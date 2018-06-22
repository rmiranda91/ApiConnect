using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class ResponseAdminRole : Response
    {
    }

    public class ResponseAdminRoleDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponseAdminRoleList : Response
    {
        public List<ResponseAdminRoleDetail> lst { get; set; }
    }
}