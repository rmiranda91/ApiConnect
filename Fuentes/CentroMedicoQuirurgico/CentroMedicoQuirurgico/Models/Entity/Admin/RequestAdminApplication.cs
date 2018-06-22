using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.ComponentModel;
using System.Web.Mvc;


namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class RequestAdminApplication : Request
    {
        public int id { get; set; }
        [DisplayName("Opción")]
        public string detail { get; set; }
        [DisplayName("Url")]
        public string href { get; set; }
        [DisplayName("Icono")]
        public string icon { get; set; }

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