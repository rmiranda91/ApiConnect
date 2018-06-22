using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroMedicoQuirurgico.Models.Entity;
using CentroMedicoQuirurgico.Models.Logic;


namespace CentroMedicoQuirurgico.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/Login
        [HttpGet]
        public ActionResult Login(string message)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ValidateUserRequest valUser)
        {
            ValidateUserResponse response = new ValidateUserResponse();

            if (ModelState.IsValid)
            {    
                AdminUserConnection cnn = new AdminUserConnection();
                response = cnn.validateUser(valUser);

                if (response.code == 0)
                {
                    Session.Add("user", valUser.user);
                    Session.Add("userName", response.userName);
                    return RedirectToAction("Bienvenido", "Home");
                }
            }

            ViewBag.message = response.message;

            // Si llego aquí es porque estaban mal las credenciales
            return View();
        }

        [HttpGet]
        public ActionResult Bienvenido() {
            return View();
        }

        [HttpGet]
        public ActionResult Salir() {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Home");
        }

    }
}
