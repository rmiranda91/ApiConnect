using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using CentroMedicoQuirurgico.Models.Entity.Admin;
using System.Web.Mvc;

namespace CentroMedicoQuirurgico.Models.Logic
{
    public class LogicAdminWareHouse
    {
        public ResponseAdminWareHouseList getWareHouseList(RequestAdminWareHouse req)
        {
            ResponseAdminWareHouseList response = new ResponseAdminWareHouseList();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("WareHouse/getAdminWareHouse", req);
                response = JsonConvert.DeserializeObject<ResponseAdminWareHouseList>(json);

                // Obtener el listado de sedes
                RequestAdminCompany reqCompany = new RequestAdminCompany();
                ResponseAdminCompanyList resCompany = new ResponseAdminCompanyList();
                LogicAdminCompany logicCompany = new LogicAdminCompany();
                List<SelectListItem> lstTmpCompany = new List<SelectListItem>();

                // Obtener el listado completo de sedes
                reqCompany.id = 0;
                resCompany = logicCompany.getCompanyList(reqCompany);

                // Llenar el listado de sedes
                foreach (ResponseAdminCompanyDetail r in resCompany.lst)
                {
                    lstTmpCompany.Add(new SelectListItem
                    {
                        Text = r.name,
                        Value = r.id.ToString(),
                        Selected = r.id == req.idCompany ? true : false
                    });
                }

                // Agregar el listado de sede
                response.lstCompany = lstTmpCompany;


                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;
        }

        public ResponseAdminWareHouse setWareHouse(RequestAdminWareHouse req)
        {
            ResponseAdminWareHouse response = new ResponseAdminWareHouse();

            try
            {
                LogicCommon com = new LogicCommon();
                string json = com.HttpPost("WareHouse/adminWareHouse", req);
                response = JsonConvert.DeserializeObject<ResponseAdminWareHouse>(json);

                return response;
            }
            catch (Exception ex)
            {
                response.code = -1;
                response.message = ex.Message;
            }

            return response;

        }
    }
}