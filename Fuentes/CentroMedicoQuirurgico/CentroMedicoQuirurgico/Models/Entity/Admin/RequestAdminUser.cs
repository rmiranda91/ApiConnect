using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using CentroMedicoQuirurgico.Models.Entity.Person;
using System.ComponentModel;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class RequestAdminUser : RequestPerson
    {
        public int id { get; set; }
        public int idPerson { get; set; }
        [DisplayName("Usuario")]
        public string loginName { get; set; }
        [DisplayName("Contraseña")]
        public string personalKey { get; set; }
        [DisplayName("Intentos")]
        public int attemps { get; set; }
        [DisplayName("Nombre Completo")]
        public string name { get; set; }
        [DisplayName("Rol")]
        public int idRole { get; set; }
        private List<SelectListItem> lstState;

        public List<SelectListItem> getLstState()
        {
            lstState = new List<SelectListItem>();

            lstState.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "True"
            });
            lstState.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "False"
            });

            return lstState;
        }
    }
}