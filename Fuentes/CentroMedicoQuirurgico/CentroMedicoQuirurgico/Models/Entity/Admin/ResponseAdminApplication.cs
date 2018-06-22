using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.ComponentModel;
using System.Web.Mvc;


namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class ResponseAdminApplication : Response
    {
    }

    public class ResponseAdminApplicationDetail
    {
        public int id { get; set; }
        public string detail { get; set; }
        public string href { get; set; }
        public string icon { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponseAdminApplicationList : Response
    {
        public List<ResponseAdminApplicationDetail> lst { get; set; }
    }
}