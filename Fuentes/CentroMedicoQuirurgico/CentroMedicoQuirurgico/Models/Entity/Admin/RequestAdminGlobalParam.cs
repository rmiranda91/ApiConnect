using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.ComponentModel;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class RequestAdminGlobalParam : Request
    {
        [DisplayName("Código")]
        public string id { get; set; }
        [DisplayName("Valor")]
        public string value { get; set; }
        [DisplayName("Descripción")]
        public string detail { get; set; }
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