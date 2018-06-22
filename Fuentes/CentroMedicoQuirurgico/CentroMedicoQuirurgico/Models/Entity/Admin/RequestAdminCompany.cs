using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.ComponentModel;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class RequestAdminCompany : Request
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Ciudad")]
        public string city { get; set; }
        [DisplayName("Dirección")]
        public string address { get; set; }
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