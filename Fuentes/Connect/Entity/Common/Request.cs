using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Common
{
    public class Request
    {
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
        public char flag { get; set; }
    }
}
