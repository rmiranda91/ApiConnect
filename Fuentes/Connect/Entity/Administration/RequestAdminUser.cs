using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Administration
{
    public class RequestAdminUser : Request
    {
        public int id { get; set; }
        public int idPerson { get; set; }
        public string loginName { get; set; }
        public string personalKey { get; set; }
        public int attemps { get; set; }
        public string name { get; set; }
        public int idRole { get; set; }
    }
}
