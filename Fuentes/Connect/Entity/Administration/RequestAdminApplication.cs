using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Administration
{
    public class RequestAdminApplication : Request
    {
        public int id { get; set; }
        public string detail { get; set; }
        public string href { get; set; }
        public string icon { get; set; }
    }
}
