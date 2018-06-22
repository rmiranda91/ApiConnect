using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Administration
{
    public class RequestAdminWareHouse : Request
    {
        public int id { get; set; }
        public int idCompany { get; set; }
        public string description { get; set; }
        public string responsable { get; set; }
    }
}
