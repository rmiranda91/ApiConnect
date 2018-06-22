using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroMedicoQuirurgico.Models.Entity.Common
{
    public class Response
    {
        public int code { get; set; }
        public string message { get; set; }
        public int status { get; set; }
    }
}