using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.ComponentModel;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class ResponseAdminRoleApplication : Response
    {
    }

    public class ResponseAdminRoleApplicationDetail
    {
        public int id { get; set; }
        public int idRole { get; set; }
        public int idApplication { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponseAdminRoleApplicationList : Response
    {
        public List<ResponseAdminRoleApplicationDetail> lst { get; set; }
        public List<SelectListItem> lstRole { get; set; }
        public List<ResponseAdminApplicationDetail> lstApplication { get; set; }
    }
}