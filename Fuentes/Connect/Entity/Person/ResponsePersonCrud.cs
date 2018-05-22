using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace Entity.Person
{
    public class ResponsePersonCrud : Response
    {
    }

    public class ResponsePersonCrudDetail
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string firstLastName { get; set; }
        public string secondLastName { get; set; }
        public DateTime dateBorn { get; set; }
        public int typeDocument { get; set; }
        public string document { get; set; }
        public string homeAddress { get; set; }
        public string homePhone { get; set; }
        public string workPhone { get; set; }
        public string movilPhone1 { get; set; }
        public string movilPhone2 { get; set; }
        public int profession { get; set; }
        public string workplace { get; set; }
        public bool stateRecord { get; set; }
        public string userRegister { get; set; }
        public DateTime dateRegister { get; set; }
        public string userUpdate { get; set; }
        public DateTime dateUpdate { get; set; }
    }

    public class ResponsePersonCrudList : Response
    {
        public List<ResponsePersonCrudDetail> lst { get; set; }
    }
}
