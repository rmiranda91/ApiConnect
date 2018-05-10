using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Error
{
    public class LogError
    {
        public int id { get; set; }
        public string module { get; set; }
        public string method { get; set; }
        public string errorMessage { get; set; }
        public string moreInfo { get; set; }

        public LogError() { 
        }

    }
}
