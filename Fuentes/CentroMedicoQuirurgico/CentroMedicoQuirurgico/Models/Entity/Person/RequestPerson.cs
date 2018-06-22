using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.ComponentModel;

namespace CentroMedicoQuirurgico.Models.Entity.Person
{
    public class RequestPerson : Request
    {
        public int id { get; set; }
        [DisplayName("Primer Nombre")]
        public string firstName { get; set; }
        [DisplayName("Segundo Nombre")]
        public string secondName { get; set; }
        [DisplayName("Primer Apellido")]
        public string firstLastName { get; set; }
        [DisplayName("Segundo Apellido")]
        public string secondLastName { get; set; }
        [DisplayName("Fecha Nacimiento")]
        public DateTime dateBorn { get; set; }
        [DisplayName("Tipo Documento")]
        public int typeDocument { get; set; }
        [DisplayName("Documento")]
        public string document { get; set; }
        [DisplayName("Dir. Casa")]
        public string homeAddress { get; set; }
        [DisplayName("Tel. Casa")]
        public string homePhone { get; set; }
        [DisplayName("Tel. Trabajo")]
        public string workPhone { get; set; }
        [DisplayName("Tel. Movil 1")]
        public string movilPhone1 { get; set; }
        [DisplayName("Tel. Movil 2")]
        public string movilPhone2 { get; set; }
        [DisplayName("Profesión")]
        public int profession { get; set; }
        [DisplayName("Lugar Trabajo")]
        public string workplace { get; set; }
    }
}