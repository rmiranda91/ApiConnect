using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Administration
{
    public class RequestAdminClsMaster : Request
    {
        public int id { get; set; }
        public string catalogId { get; set; }
        public string value { get; set; }
        public string subValue { get; set; }
        public string detail { get; set; }
        public bool child { get; set; }
    }
}
