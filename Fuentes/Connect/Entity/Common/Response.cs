using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Common
{
    public class Response
    {
        public int code { get; set; }
        public string message { get; set; }
        public int status { get; set; }
    }
}
