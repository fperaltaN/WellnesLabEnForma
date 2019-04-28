using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace GymWebDeploy.Controllers
{
    public class LoginController : Controller, IGenericController<Login>
    {
        private static Usuarios usuario;
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.UserRol = "0";
            Session["UserRol"] = "0";
            sessionAbandon();
            return View();
        }
        [HttpPost]
        public JsonResult ValidateUser(Login data)
        {
            List<Usuarios> usuarioData = new GenericBaseDao().Get<Usuarios>(ConfigurationManager.AppSettings["QueryGETUsuarios"]);
            usuario = usuarioData.Find(x => x.USUARIO.Trim() == data.User.Trim() && x.PASSWORD.Trim() == data.Password.Trim());
            LoginStatus status = new LoginStatus();
            if (usuario != null)
            {
                Session["User"] = usuario.USUARIO;
                Session["UserName"] = usuario.NOMBRE + " " + usuario.APELLIDO_MAT;
                Session["UserRol"] = usuario.ID_PERFIL;
                ViewBag.UserRol = usuario.ID_PERFIL;
                Session["LoggedIn"] = "ok";
                status.Message = "Bienvenid@ " + usuario.USUARIO;
                status.Success = true;
                status.TargetURL = "Home" + "/" + "Index";
                return Json(status);
            }
            else
            {
                status.Message = "El nombre y/o contraseña son incorrectos";
                status.Success = false;
                status.TargetURL = "...";
                return Json(status);
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login data)
        {

            // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
            // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
            List<Usuarios> usuarioData = new GenericBaseDao().Get<Usuarios>(ConfigurationManager.AppSettings["QueryGETUsuarios"]);
            usuario = usuarioData.Find(x => x.USUARIO.Trim() == data.User.Trim() && x.PASSWORD.Trim() == data.Password.Trim());
            LoginStatus status = new LoginStatus();

            if (usuario != null)
            {
                Session["User"] = usuario.USUARIO;
                Session["UserName"] = usuario.NOMBRE + " " + usuario.APELLIDO_MAT;
                Session["UserRol"] = usuario.ID_PERFIL;
                ViewBag.UserRol = usuario.ID_PERFIL;
                Session["LoggedIn"] = "ok";
                status.Message = "Bienvenid@ " + usuario.USUARIO;
                status.Success = true;
                status.TargetURL = "Home" + "/" + "Index";
                //return Json(status);
                return RedirectToLocal(status.TargetURL);
            }
            else
            {
                status.Message = "El nombre y/o contraseña son incorrectos";
                status.Success = false;
                status.TargetURL = "...";
                //return Json(status);
                return View("Index");
            }
        }
        [HttpPost]
        public JsonResult sessionAbandon()
        {
            LoginStatus status = new LoginStatus();
            try
            {
                Session["User"] = null;
                Session["UserName"] = null;
                Session["UserRol"] = null;
                Session["LoggedIn"] = null;
                status.Message = "Hasta luego.. ";
                status.Success = false;
                status.TargetURL = "Login";
                Session.Abandon();

                usuario = null;
            }
            catch (Exception) { RedirectToAction("Index", "Login"); }
            return Json(status);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public Boolean checkSession()
        {
            if (usuario != null)
            {
                return true;
            }
            else
            {
                sessionAbandon();
                return false;
            }
        }

        [HttpPost]
        public JsonResult sessionStatus()
        {
            if (Session["User"] != null)
                return Json(true);
            else
                return Json(false);
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            sessionAbandon();
            return RedirectToAction("Index", "Home");
        }


        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Login>(ConfigurationManager.AppSettings["QueryGET"]), JsonRequestBehavior.AllowGet);
            //return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryDELETENote"], data.user, data.pass)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Login data)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(Login data)
        {
            throw new NotImplementedException();
        }
        public JsonResult Delete(Login data)
        {
            throw new NotImplementedException();
        }
    }
}