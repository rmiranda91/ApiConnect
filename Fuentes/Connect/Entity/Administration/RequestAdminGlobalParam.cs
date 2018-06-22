using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Administration
{
    public class RequestAdminGlobalParam : Request
    {
        public string id { get; set; }
        public string value { get; set; }
        public string detail { get; set; }
    }
}
