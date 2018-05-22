using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroMedicoQuirurgico.Models.Entity
{
    public class ValidateUserRequest
    {
        public string user { get; set; }
        public string password { get; set; }
    }
}