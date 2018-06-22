using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.Web.Mvc;
using System.ComponentModel;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class RequestAdminClsMaster : Request
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Cod. Catálogo")]
        public string catalogId { get; set; }
        [DisplayName("Valor")]
        public string value { get; set; }
        [DisplayName("Sub Valor")]
        public string subValue { get; set; }
        [DisplayName("Detalle")]
        public string detail { get; set; }
        [DisplayName("Tipo")]
        public bool child { get; set; }

        private List<SelectListItem> lstChild { get; set; }
        private List<SelectListItem> lstState;

        public List<SelectListItem> getLstTypeOption()
        {
            lstChild = new List<SelectListItem>();

            lstChild.Add(new SelectListItem
            {
                Text = "Hijo",
                Value = "True"
            });
            lstChild.Add(new SelectListItem
            {
                Text = "Padre",
                Value = "False"
            });

            return lstChild;
        }

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