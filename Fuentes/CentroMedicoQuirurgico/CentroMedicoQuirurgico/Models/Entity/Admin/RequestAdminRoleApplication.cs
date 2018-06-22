using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.ComponentModel;
using System.Web.Mvc;
using System.Data;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class RequestAdminRoleApplication : Request
    {
        [DisplayName("Identificador")]
        public int id { get; set; }
        [DisplayName("Código de Rol")]
        public int idRole { get; set; }
        [DisplayName("Código de Opción")]
        public int idApplication { get; set; }
    }

    public class RequestAdminRoleApplicationList
    {
        public List<RequestAdminRoleApplication> lst { get; set; }
    }

    public class RequestAdminRoleApplicationData
    {
        public DataTable dtRoleApplication { get; set; }
    }
}