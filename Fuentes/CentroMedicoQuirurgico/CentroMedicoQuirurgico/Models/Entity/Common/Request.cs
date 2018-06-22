using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CentroMedicoQuirurgico.Models.Entity.Common
{
    public class Request
    {
        [DisplayName("Estado")]
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
        public char flag { get; set; }
    }
}