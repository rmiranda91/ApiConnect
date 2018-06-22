using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedicoQuirurgico.Models.Entity.Admin;
using CentroMedicoQuirurgico.Models.Entity.Person;
using CentroMedicoQuirurgico.Models.Logic;

namespace CentroMedicoQuirurgico.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Management() {
            return View();
        }

        #region Métodos Rol
        [HttpGet]
        public ActionResult Role()
        {
            // Obtener el listado de Roles
            RequestAdminRole req = new RequestAdminRole();
            ResponseAdminRoleList res = new ResponseAdminRoleList();
            LogicAdminRole logic = new LogicAdminRole();

            req.id = 0;
            res = logic.getRoleList(req);

            req.stateRecord = true;
            Tuple<ResponseAdminRoleList, RequestAdminRole, ResponseAdminRoleDetail, ResponseAdminRole> response = 
                new Tuple<ResponseAdminRoleList, RequestAdminRole, ResponseAdminRoleDetail, ResponseAdminRole>(res, null, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult addRole(ResponseAdminRoleList item1, RequestAdminRole item2, ResponseAdminRoleDetail item3, ResponseAdminRole item4)
        {
            // Método para agregar Rol 
            if (ModelState.IsValid) {
                LogicAdminRole adm = new LogicAdminRole();
                
                item2.id = 0;
                item2.stateRecord = true;
                item2.flag = 'N';
                item2.dateRegister = DateTime.Now;
                item2.userRegister = Session["user"].ToString();
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item4 = adm.setRole(item2);

                if (item4.code == 50000)
                {
                    Session.Add("msgOk", item4.message);
                }
                else {
                    Session.Add("msgEr", item4.message);
                }
            }

            Tuple<ResponseAdminRoleList, RequestAdminRole, ResponseAdminRoleDetail, ResponseAdminRole> response = 
                new Tuple<ResponseAdminRoleList, RequestAdminRole, ResponseAdminRoleDetail, ResponseAdminRole>(item1, item2, item3, item4);

            return RedirectToAction("Role");
        }

        [HttpGet]
        public ActionResult UpdateRole(string id) {
            // Cargar los datos del rol a modificar
            RequestAdminRole req = new RequestAdminRole();
            ResponseAdminRoleList res = new ResponseAdminRoleList();
            LogicAdminRole logic = new LogicAdminRole();

            req.id = int.Parse(id);
            res = logic.getRoleList(req);

            req.flag = 'M';
            req.detail = res.lst[0].detail;
            req.name = res.lst[0].name;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }

        [HttpPost]
        public ActionResult UpdateRole(RequestAdminRole request) {
            if (ModelState.IsValid) {
                LogicAdminRole adm = new LogicAdminRole();
                ResponseAdminRole response = new ResponseAdminRole();

                request.flag = 'M';
                request.dateUpdate = DateTime.Now;
                request.userUpdate = Session["user"].ToString();
                request.userRegister = "";
                response = adm.setRole(request);
                
                if (response.code == 50000)
                {
                    Session.Add("msgOk", response.message);
                }
                else
                {
                    Session.Add("msgEr", response.message);
                }
            }

            return RedirectToAction("Role");
        }

        [HttpGet]
        public ActionResult ShowRole(string id) {
            // Cargar los datos del rol a modificar
            RequestAdminRole req = new RequestAdminRole();
            ResponseAdminRoleList res = new ResponseAdminRoleList();
            LogicAdminRole logic = new LogicAdminRole();

            req.id = int.Parse(id);
            res = logic.getRoleList(req);

            req.detail = res.lst[0].detail;
            req.name = res.lst[0].name;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }
        #endregion

        #region Métodos Aplicación 
        [HttpGet]
        public ActionResult Application() { 
            // Obtener el listado de aplicaciones
            RequestAdminApplication req = new RequestAdminApplication();
            ResponseAdminApplicationList res = new ResponseAdminApplicationList();
            LogicAdminApplication logic = new LogicAdminApplication();

            req.id = 0;
            res = logic.getApplicationList(req);

            req.stateRecord = true;
            Tuple<ResponseAdminApplicationList, RequestAdminApplication, ResponseAdminApplicationDetail, ResponseAdminApplication> response =
                new Tuple<ResponseAdminApplicationList, RequestAdminApplication, ResponseAdminApplicationDetail, ResponseAdminApplication>(res, null, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult addApplication(ResponseAdminApplicationList item1, RequestAdminApplication item2, ResponseAdminApplicationDetail item3, ResponseAdminApplication item4)
        {
            // Método para agregar Rol 
            if (ModelState.IsValid)
            {
                LogicAdminApplication adm = new LogicAdminApplication();

                item2.id = 0;
                item2.stateRecord = true;
                item2.flag = 'N';
                item2.dateRegister = DateTime.Now;
                item2.userRegister = Session["user"].ToString();
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item4 = adm.setApplication(item2);

                if (item4.code == 50000)
                {
                    Session.Add("msgOk", item4.message);
                }
                else
                {
                    Session.Add("msgEr", item4.message);
                }
            }

            Tuple<ResponseAdminApplicationList, RequestAdminApplication, ResponseAdminApplicationDetail, ResponseAdminApplication> response =
                new Tuple<ResponseAdminApplicationList, RequestAdminApplication, ResponseAdminApplicationDetail, ResponseAdminApplication>(item1, item2, item3, item4);

            return RedirectToAction("Application");
        }

        [HttpGet]
        public ActionResult UpdateApplication(string id)
        {
            // Cargar los datos del rol a modificar
            RequestAdminApplication req = new RequestAdminApplication();
            ResponseAdminApplicationList res = new ResponseAdminApplicationList();
            LogicAdminApplication logic = new LogicAdminApplication();

            req.id = int.Parse(id);
            res = logic.getApplicationList(req);

            req.flag = 'M';
            req.detail = res.lst[0].detail;
            req.href = res.lst[0].href;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }

        [HttpPost]
        public ActionResult UpdateApplication(RequestAdminApplication request)
        {
            if (ModelState.IsValid)
            {
                LogicAdminApplication adm = new LogicAdminApplication();
                ResponseAdminApplication response = new ResponseAdminApplication();

                request.flag = 'M';
                request.dateUpdate = DateTime.Now;
                request.userUpdate = Session["user"].ToString();
                request.userRegister = "";
                response = adm.setApplication(request);

                if (response.code == 50000)
                {
                    Session.Add("msgOk", response.message);
                }
                else
                {
                    Session.Add("msgEr", response.message);
                }
            }

            return RedirectToAction("Application");
        }

        [HttpGet]
        public ActionResult ShowApplication(string id)
        {
            // Cargar los datos del rol a modificar
            RequestAdminApplication req = new RequestAdminApplication();
            ResponseAdminApplicationList res = new ResponseAdminApplicationList();
            LogicAdminApplication logic = new LogicAdminApplication();

            req.id = int.Parse(id);
            res = logic.getApplicationList(req);

            req.detail = res.lst[0].detail;
            req.href = res.lst[0].href;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }
        #endregion

        #region Métodos de Permisos
        [HttpGet]
        public ActionResult RoleApplication(string id) { 
            // Luego obtener los permisos del Rol
            RequestAdminRoleApplication req = new RequestAdminRoleApplication();
            ResponseAdminRoleApplicationList res = new ResponseAdminRoleApplicationList();
            LogicAdminRoleApplication logic = new LogicAdminRoleApplication();

            res = logic.getRoleApplicationList(req, id);
            
            req.stateRecord = true;
            Tuple<ResponseAdminRoleApplicationList, RequestAdminRoleApplication, ResponseAdminRoleApplication> response =
                new Tuple<ResponseAdminRoleApplicationList, RequestAdminRoleApplication, ResponseAdminRoleApplication>(res, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult updateRoleApplication(int[] chk_approle,string ddl_role)
        {
            RequestAdminRoleApplication item;
            RequestAdminRoleApplicationList req = new RequestAdminRoleApplicationList();
            ResponseAdminRoleApplication response = new ResponseAdminRoleApplication();
            LogicAdminRoleApplication log = new LogicAdminRoleApplication();
            req.lst = new List<RequestAdminRoleApplication>();
            

            int opc = 0;
            for(int i=0;i<chk_approle.Length;i++){
                item = new RequestAdminRoleApplication();
                item.dateRegister = System.DateTime.Now;
                item.userRegister = Session["user"].ToString();
                item.dateUpdate = System.DateTime.Now;
                item.userUpdate = Session["user"].ToString();
                item.stateRecord = true;
                item.idRole = int.Parse(ddl_role);
                item.idApplication = chk_approle[i];
                item.flag = 'N';
                req.lst.Add(item);
            }

            response = log.setApplication(req);

            return RedirectToAction("RoleApplication");
        }
        #endregion

        #region Métodos Usuario
        [HttpGet]
        public ActionResult User()
        {
            // Obtener el listado de Usuarios
            RequestAdminUser req = new RequestAdminUser();
            ResponseAdminUserList res = new ResponseAdminUserList();
            LogicAdminUser logic = new LogicAdminUser();

            req.id = 0;
            res = logic.getUserList(req);
            req.stateRecord = true;

            Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser> response =
                new Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser>(res, null, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult addUser(ResponseAdminUserList item1, RequestAdminUser item2, ResponseAdminUserDetail item3, ResponseAdminUser item4)
        {
            // Método para agregar Rol 
            if (ModelState.IsValid)
            {
                LogicAdminUser adm = new LogicAdminUser();

                item2.id = 0;
                item2.stateRecord = true;
                item2.flag = 'N';
                item2.dateRegister = DateTime.Now;
                item2.userRegister = Session["user"].ToString();
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item2.profession = 9; // Profesión genérica
                item4 = adm.setUser(item2);

                if (item4.code == 50000)
                {
                    Session.Add("msgOk", item4.message);
                }
                else
                {
                    Session.Add("msgEr", item4.message);
                }
            }

            Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser> response =
                new Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser>(item1, item2, item3, item4);

            return RedirectToAction("User");
        }

        [HttpGet]
        public ActionResult UpdateUser(string id)
        {
            // Cargar los datos del usuario a modificar
            RequestAdminUser req = new RequestAdminUser();
            ResponseAdminUserList res = new ResponseAdminUserList();
            LogicAdminUser logic = new LogicAdminUser();
            

            req.id = int.Parse(id);
            res = logic.getUserList(req);

            // Recuperar los campos de la persona
            RequestPerson reqPer = new RequestPerson();
            ResponsePersonList resPer = new ResponsePersonList();
            LogicAdminPerson logicPer = new LogicAdminPerson();

            reqPer.id = res.lst[0].idPerson;
            resPer = logicPer.getPerson(reqPer);

            // Setear los campos del modelo
            req.attemps = res.lst[0].attemps;
            req.dateBorn = resPer.lst[0].dateBorn;
            req.dateRegister = res.lst[0].dateRegister;
            req.dateUpdate = res.lst[0].dateUpdate;
            req.document = resPer.lst[0].document;
            req.firstLastName = resPer.lst[0].firstLastName;
            req.firstName = resPer.lst[0].firstName;
            req.flag = 'M';
            req.homeAddress = resPer.lst[0].homeAddress;
            req.homePhone = resPer.lst[0].homePhone;
            req.idRole = res.lst[0].idRole;
            req.idPerson = res.lst[0].idPerson;
            req.loginName = res.lst[0].loginName;
            req.movilPhone1 = resPer.lst[0].movilPhone1;
            req.movilPhone2 = resPer.lst[0].movilPhone2;
            req.name = res.lst[0].name;
            req.personalKey = res.lst[0].personalKey;
            req.profession = resPer.lst[0].profession;
            req.secondLastName = resPer.lst[0].secondLastName;
            req.secondName = resPer.lst[0].secondName;
            req.stateRecord = res.lst[0].stateRecord;
            req.typeDocument = resPer.lst[0].typeDocument;
            req.userRegister = res.lst[0].userRegister;
            req.userUpdate = res.lst[0].userUpdate;
            req.workPhone = resPer.lst[0].workPhone;
            req.workplace = resPer.lst[0].workplace;

            Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser> response =
                new Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser>(res, req, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult UpdateUser(ResponseAdminUserList item1, RequestAdminUser item2, ResponseAdminUserDetail item3, ResponseAdminUser item4)
        {
            if (ModelState.IsValid)
            {
                LogicAdminUser adm = new LogicAdminUser();
                ResponseAdminUser response = new ResponseAdminUser();

                item2.flag = 'M';
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item2.userRegister = "";
                response = adm.setUser(item2);

                if (response.code == 50000)
                {
                    Session.Add("msgOk", response.message);
                }
                else
                {
                    Session.Add("msgEr", response.message);
                }
            }

            return RedirectToAction("User");
        }

        [HttpGet]
        public ActionResult ShowUser(string id) {
            // Cargar los datos del usuario a modificar
            RequestAdminUser req = new RequestAdminUser();
            ResponseAdminUserList res = new ResponseAdminUserList();
            LogicAdminUser logic = new LogicAdminUser();

            req.id = int.Parse(id);
            res = logic.getUserList(req);

            // Recuperar los campos de la persona
            RequestPerson reqPer = new RequestPerson();
            ResponsePersonList resPer = new ResponsePersonList();
            LogicAdminPerson logicPer = new LogicAdminPerson();

            reqPer.id = res.lst[0].idPerson;
            resPer = logicPer.getPerson(reqPer);

            // Setear los campos del modelo
            req.attemps = res.lst[0].attemps;
            req.dateBorn = resPer.lst[0].dateBorn;
            req.dateRegister = res.lst[0].dateRegister;
            req.dateUpdate = res.lst[0].dateUpdate;
            req.document = resPer.lst[0].document;
            req.firstLastName = resPer.lst[0].firstLastName;
            req.firstName = resPer.lst[0].firstName;
            req.flag = 'M';
            req.homeAddress = resPer.lst[0].homeAddress;
            req.homePhone = resPer.lst[0].homePhone;
            req.idRole = res.lst[0].idRole;
            req.idPerson = res.lst[0].idPerson;
            req.loginName = res.lst[0].loginName;
            req.movilPhone1 = resPer.lst[0].movilPhone1;
            req.movilPhone2 = resPer.lst[0].movilPhone2;
            req.name = res.lst[0].name;
            req.personalKey = res.lst[0].personalKey;
            req.profession = resPer.lst[0].profession;
            req.secondLastName = resPer.lst[0].secondLastName;
            req.secondName = resPer.lst[0].secondName;
            req.stateRecord = res.lst[0].stateRecord;
            req.typeDocument = resPer.lst[0].typeDocument;
            req.userRegister = res.lst[0].userRegister;
            req.userUpdate = res.lst[0].userUpdate;
            req.workPhone = resPer.lst[0].workPhone;
            req.workplace = resPer.lst[0].workplace;

            Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser> response =
                new Tuple<ResponseAdminUserList, RequestAdminUser, ResponseAdminUserDetail, ResponseAdminUser>(res, req, null, null);

            return View(response);
        }

        #endregion

        #region Métodos Parámetros Globales
        [HttpGet]
        public ActionResult Parameter()
        {
            // Obtener el listado de Roles
            RequestAdminGlobalParam req = new RequestAdminGlobalParam();
            ResponseAdminGlobalParamList res = new ResponseAdminGlobalParamList();
            LogicAdminGlobalParam logic = new LogicAdminGlobalParam();

            req.id = "";
            res = logic.getParameterList(req);

            req.stateRecord = true;
            Tuple<ResponseAdminGlobalParamList, RequestAdminGlobalParam, ResponseAdminGlobalParamDetail, ResponseAdminGlobalParam> response =
                new Tuple<ResponseAdminGlobalParamList, RequestAdminGlobalParam, ResponseAdminGlobalParamDetail, ResponseAdminGlobalParam>(res, null, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult addGlobalParam(ResponseAdminGlobalParamList item1, RequestAdminGlobalParam item2, ResponseAdminGlobalParamDetail item3,
            ResponseAdminGlobalParam item4)
        {
            // Método para agregar parámetro 
            if (ModelState.IsValid)
            {
                LogicAdminGlobalParam adm = new LogicAdminGlobalParam();

                item2.stateRecord = true;
                item2.flag = 'N';
                item2.dateRegister = DateTime.Now;
                item2.userRegister = Session["user"].ToString();
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item4 = adm.setGlobalParam(item2);

                if (item4.code == 50000)
                {
                    Session.Add("msgOk", item4.message);
                }
                else
                {
                    Session.Add("msgEr", item4.message);
                }
            }

            Tuple<ResponseAdminGlobalParamList, RequestAdminGlobalParam, ResponseAdminGlobalParamDetail, ResponseAdminGlobalParam> response =
                new Tuple<ResponseAdminGlobalParamList, RequestAdminGlobalParam, ResponseAdminGlobalParamDetail, ResponseAdminGlobalParam>(item1, item2, item3, item4);

            return RedirectToAction("Parameter");
        }

        [HttpGet]
        public ActionResult UpdateGlobalParam(string id)
        {
            // Cargar los datos del parámetro a modificar
            RequestAdminGlobalParam req = new RequestAdminGlobalParam();
            ResponseAdminGlobalParamList res = new ResponseAdminGlobalParamList();
            LogicAdminGlobalParam logic = new LogicAdminGlobalParam();

            req.id = id;
            res = logic.getParameterList(req);

            req.flag = 'M';
            req.detail = res.lst[0].detail;
            req.value = res.lst[0].value;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }

        [HttpPost]
        public ActionResult UpdateGlobalParam(RequestAdminGlobalParam request)
        {
            if (ModelState.IsValid)
            {
                LogicAdminGlobalParam adm = new LogicAdminGlobalParam();
                ResponseAdminGlobalParam response = new ResponseAdminGlobalParam();

                request.flag = 'M';
                request.dateUpdate = DateTime.Now;
                request.userUpdate = Session["user"].ToString();
                request.userRegister = "";
                response = adm.setGlobalParam(request);

                if (response.code == 50000)
                {
                    Session.Add("msgOk", response.message);
                }
                else
                {
                    Session.Add("msgEr", response.message);
                }
            }

            return RedirectToAction("Parameter");
        }

        [HttpGet]
        public ActionResult ShowGlobalParam(string id)
        {
            // Cargar los datos del rol a modificar
            RequestAdminGlobalParam req = new RequestAdminGlobalParam();
            ResponseAdminGlobalParamList res = new ResponseAdminGlobalParamList();
            LogicAdminGlobalParam logic = new LogicAdminGlobalParam();

            req.id = id;
            res = logic.getParameterList(req);

            req.detail = res.lst[0].detail;
            req.value = res.lst[0].value;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }

        #endregion

        #region Métodos Catálogos de sistema
        [HttpGet]
        public ActionResult ClsMaster()
        {
            // Obtener el listado de catálogos
            RequestAdminClsMaster req = new RequestAdminClsMaster();
            ResponseAdminClsMasterList res = new ResponseAdminClsMasterList();
            LogicAdminClsMaster logic = new LogicAdminClsMaster();

            req.id = 0;
            req.catalogId = "";
            req.child = true;
            res = logic.getClsMasterList(req);

            req.stateRecord = true;
            Tuple<ResponseAdminClsMasterList, RequestAdminClsMaster, ResponseAdminClsMasterDetail, ResponseAdminClsMaster> response =
                new Tuple<ResponseAdminClsMasterList, RequestAdminClsMaster, ResponseAdminClsMasterDetail, ResponseAdminClsMaster>(res, req, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult addClsMaster(ResponseAdminClsMasterList item1, RequestAdminClsMaster item2,
            ResponseAdminClsMasterDetail item3, ResponseAdminClsMaster item4)
        {
            // Método para agregar opciones de catálogo 
            if (ModelState.IsValid)
            {
                LogicAdminClsMaster adm = new LogicAdminClsMaster();

                item2.stateRecord = true;
                item2.flag = 'N';
                item2.dateRegister = DateTime.Now;
                item2.userRegister = Session["user"].ToString();
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item4 = adm.setClsMaster(item2);

                if (item4.code == 50000)
                {
                    Session.Add("msgOk", item4.message);
                }
                else
                {
                    Session.Add("msgEr", item4.message);
                }
            }

            Tuple<ResponseAdminClsMasterList, RequestAdminClsMaster, ResponseAdminClsMasterDetail, ResponseAdminClsMaster> response =
                new Tuple<ResponseAdminClsMasterList, RequestAdminClsMaster, ResponseAdminClsMasterDetail, ResponseAdminClsMaster>(item1, item2, item3, item4);

            return RedirectToAction("ClsMaster");
        }

        [HttpGet]
        public ActionResult UpdateClsMaster(string id)
        {
            // Cargar los datos de la opción a modificar
            RequestAdminClsMaster req = new RequestAdminClsMaster();
            ResponseAdminClsMasterList res = new ResponseAdminClsMasterList();
            LogicAdminClsMaster logic = new LogicAdminClsMaster();

            req.id = int.Parse(id);
            res = logic.getClsMasterList(req);

            req.flag = 'M';
            req.catalogId = res.lst[0].catalogId;
            req.child = res.lst[0].child;
            req.subValue = res.lst[0].subValue;
            req.detail = res.lst[0].detail;
            req.value = res.lst[0].value;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }

        [HttpPost]
        public ActionResult UpdateClsMaster(RequestAdminClsMaster request)
        {
            if (ModelState.IsValid)
            {
                LogicAdminClsMaster adm = new LogicAdminClsMaster();
                ResponseAdminClsMaster response = new ResponseAdminClsMaster();

                request.flag = 'M';
                request.dateUpdate = DateTime.Now;
                request.userUpdate = Session["user"].ToString();
                request.userRegister = "";
                response = adm.setClsMaster(request);

                if (response.code == 50000)
                {
                    Session.Add("msgOk", response.message);
                }
                else
                {
                    Session.Add("msgEr", response.message);
                }
            }

            return RedirectToAction("ClsMaster");
        }

        [HttpGet]
        public ActionResult ShowClsMaster(string id)
        {
            // Cargar los datos de la opción a modificar
            RequestAdminClsMaster req = new RequestAdminClsMaster();
            ResponseAdminClsMasterList res = new ResponseAdminClsMasterList();
            LogicAdminClsMaster logic = new LogicAdminClsMaster();

            req.id = int.Parse(id);
            res = logic.getClsMasterList(req);

            req.catalogId = res.lst[0].catalogId;
            req.child = res.lst[0].child;
            req.subValue = res.lst[0].subValue;
            req.detail = res.lst[0].detail;
            req.value = res.lst[0].value;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }
        #endregion

        #region Métodos de Sede
        [HttpGet]
        public ActionResult Company()
        {
            // Obtener el listado de sedes
            RequestAdminCompany req = new RequestAdminCompany();
            ResponseAdminCompanyList res = new ResponseAdminCompanyList();
            LogicAdminCompany logic = new LogicAdminCompany();

            req.id = 0;
            res = logic.getCompanyList(req);

            req.stateRecord = true;
            Tuple<ResponseAdminCompanyList, RequestAdminCompany, ResponseAdminCompanyDetail, ResponseAdminCompany> response =
                new Tuple<ResponseAdminCompanyList, RequestAdminCompany, ResponseAdminCompanyDetail, ResponseAdminCompany>(res, null, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult addCompany(ResponseAdminCompanyList item1, RequestAdminCompany item2,
            ResponseAdminCompanyDetail item3, ResponseAdminCompany item4)
        {
            // Método para agregar opciones de catálogo 
            if (ModelState.IsValid)
            {
                LogicAdminCompany adm = new LogicAdminCompany();

                item2.stateRecord = true;
                item2.flag = 'N';
                item2.dateRegister = DateTime.Now;
                item2.userRegister = Session["user"].ToString();
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item4 = adm.setCompany(item2);

                if (item4.code == 50000)
                {
                    Session.Add("msgOk", item4.message);
                }
                else
                {
                    Session.Add("msgEr", item4.message);
                }
            }

            Tuple<ResponseAdminCompanyList, RequestAdminCompany, ResponseAdminCompanyDetail, ResponseAdminCompany> response =
                new Tuple<ResponseAdminCompanyList, RequestAdminCompany, ResponseAdminCompanyDetail, ResponseAdminCompany>(item1, item2, item3, item4);

            return RedirectToAction("Company");
        }

        [HttpGet]
        public ActionResult UpdateCompany(string id)
        {
            // Cargar los datos de la opción a modificar
            RequestAdminCompany req = new RequestAdminCompany();
            ResponseAdminCompanyList res = new ResponseAdminCompanyList();
            LogicAdminCompany logic = new LogicAdminCompany();

            req.id = int.Parse(id);
            res = logic.getCompanyList(req);

            req.flag = 'M';
            req.name = res.lst[0].name;
            req.city = res.lst[0].city;
            req.address = res.lst[0].address;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }

        [HttpPost]
        public ActionResult UpdateCompany(RequestAdminCompany request)
        {
            if (ModelState.IsValid)
            {
                LogicAdminCompany adm = new LogicAdminCompany();
                ResponseAdminCompany response = new ResponseAdminCompany();

                request.flag = 'M';
                request.dateUpdate = DateTime.Now;
                request.userUpdate = Session["user"].ToString();
                request.userRegister = "";
                response = adm.setCompany(request);

                if (response.code == 50000)
                {
                    Session.Add("msgOk", response.message);
                }
                else
                {
                    Session.Add("msgEr", response.message);
                }
            }

            return RedirectToAction("Company");
        }

        [HttpGet]
        public ActionResult ShowCompany(string id)
        {
            // Cargar los datos de la sede
            RequestAdminCompany req = new RequestAdminCompany();
            ResponseAdminCompanyList res = new ResponseAdminCompanyList();
            LogicAdminCompany logic = new LogicAdminCompany();

            req.id = int.Parse(id);
            res = logic.getCompanyList(req);

            req.name = res.lst[0].name;
            req.city = res.lst[0].city;
            req.address = res.lst[0].address;
            req.stateRecord = res.lst[0].stateRecord;

            return View(req);
        }
        #endregion

        #region Métodos de Bodega
        [HttpGet]
        public ActionResult WareHouse()
        {
            // Obtener el listado de sedes
            RequestAdminWareHouse req = new RequestAdminWareHouse();
            ResponseAdminWareHouseList res = new ResponseAdminWareHouseList();
            LogicAdminWareHouse logic = new LogicAdminWareHouse();

            req.id = 0;
            res = logic.getWareHouseList(req);

            req.stateRecord = true;
            Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse> response =
                new Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse>(res, null, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult addWareHouse(ResponseAdminWareHouseList item1, RequestAdminWareHouse item2,
            ResponseAdminWareHouseDetail item3, ResponseAdminWareHouse item4)
        {
            // Método para agregar opciones de catálogo 
            if (ModelState.IsValid)
            {
                LogicAdminWareHouse adm = new LogicAdminWareHouse();

                item2.stateRecord = true;
                item2.flag = 'N';
                item2.dateRegister = DateTime.Now;
                item2.userRegister = Session["user"].ToString();
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item4 = adm.setWareHouse(item2);

                if (item4.code == 50000)
                {
                    Session.Add("msgOk", item4.message);
                }
                else
                {
                    Session.Add("msgEr", item4.message);
                }
            }

            Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse> response =
                new Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse>(item1, item2, item3, item4);

            return RedirectToAction("WareHouse");
        }

        [HttpGet]
        public ActionResult UpdateWareHouse(string id)
        {
            // Cargar los datos de la opción a modificar
            RequestAdminWareHouse req = new RequestAdminWareHouse();
            ResponseAdminWareHouseList res = new ResponseAdminWareHouseList();
            LogicAdminWareHouse logic = new LogicAdminWareHouse();

            req.id = int.Parse(id);
            res = logic.getWareHouseList(req);

            req.flag = 'M';
            req.idCompany = res.lst[0].idCompany;
            req.responsable = res.lst[0].responsable;
            req.description = res.lst[0].description;
            req.stateRecord = res.lst[0].stateRecord;

            Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse> response =
                new Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse>(res, req, null, null);

            return View(response);
        }

        [HttpPost]
        public ActionResult UpdateWareHouse(ResponseAdminWareHouseList item1, RequestAdminWareHouse item2, ResponseAdminWareHouseDetail item3, ResponseAdminWareHouse item4)
        {
            if (ModelState.IsValid)
            {
                LogicAdminWareHouse adm = new LogicAdminWareHouse();
                ResponseAdminWareHouse response = new ResponseAdminWareHouse();

                item2.flag = 'M';
                item2.dateUpdate = DateTime.Now;
                item2.userUpdate = Session["user"].ToString();
                item2.userRegister = "";
                response = adm.setWareHouse(item2);

                if (response.code == 50000)
                {
                    Session.Add("msgOk", response.message);
                }
                else
                {
                    Session.Add("msgEr", response.message);
                }
            }

            return RedirectToAction("WareHouse");
        }

        [HttpGet]
        public ActionResult ShowWareHouse(string id)
        {
            // Cargar los datos de la sede
            RequestAdminWareHouse req = new RequestAdminWareHouse();
            ResponseAdminWareHouseList res = new ResponseAdminWareHouseList();
            LogicAdminWareHouse logic = new LogicAdminWareHouse();

            req.id = int.Parse(id);
            res = logic.getWareHouseList(req);

            req.description = res.lst[0].description;
            req.idCompany = res.lst[0].idCompany;
            req.responsable = res.lst[0].responsable;
            req.stateRecord = res.lst[0].stateRecord;

            Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse> response =
                new Tuple<ResponseAdminWareHouseList, RequestAdminWareHouse, ResponseAdminWareHouseDetail, ResponseAdminWareHouse>(res, req, null, null);

            return View(response);
        }
        #endregion
    }
}
