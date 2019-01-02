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
    public class LoginController :  Controller, IGenericController<Login>
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ValidateUser(Login data)
        {
            List<Usuarios> usuarioData = new GenericBaseDao().Get<Usuarios>(ConfigurationManager.AppSettings["QueryGETUsuarios"]);
            Usuarios usuario = usuarioData.Find(x => x.USUARIO == data.user && x.PASSWORD == data.pass);
            LoginStatus status = new LoginStatus();
            if (usuario != null)
            {
                Session["User"] = usuario.USUARIO;
                Session["UserName"] = usuario.NOMBRE +" "+ usuario.APELLIDO_MAT;
                Session["UserRol"] = usuario.ID_PERFIL;
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
                status.TargetURL = "..." ;
                return Json(status);
            }            
        }

        [HttpPost]
        public JsonResult sessionAbandon()
        {
            LoginStatus status = new LoginStatus();
            Session["User"] = null;
            Session["UserName"] = null;
            Session["UserRol"] = null;
            Session["LoggedIn"] = null;
            status.Message = "Hasta luego.. " ;
            status.Success = false;
            status.TargetURL = "Login" ;
            return Json(status);
        }

        [HttpPost]
        public JsonResult sessionStatus()
        {
            if(Session["User"] != null)
                return Json(true);
            else
                return Json(false);
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