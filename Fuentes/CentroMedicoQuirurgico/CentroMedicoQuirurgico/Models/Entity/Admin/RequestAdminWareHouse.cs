using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentroMedicoQuirurgico.Models.Entity.Common;
using System.Web.Mvc;
using System.ComponentModel;

namespace CentroMedicoQuirurgico.Models.Entity.Admin
{
    public class RequestAdminWareHouse : Request
    {
        [DisplayName("Código")]
        public int id { get; set; }
        [DisplayName("Cod. Sede")]
        public int idCompany { get; set; }
        [DisplayName("Descripcion")]
        public string description { get; set; }
        [DisplayName("Responsable")]
        public string responsable { get; set; }
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