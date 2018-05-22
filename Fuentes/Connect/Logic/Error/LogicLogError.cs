using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Error;
using Entity.Error;

namespace Logic.Error
{
    public class LogicLogError
    {
        public void newError(LogError error) {
            DataLogError dataError = new DataLogError();
            dataError.newError(error);
        }

    }
}
