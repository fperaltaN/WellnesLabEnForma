using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
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
            LoginStatus status = new LoginStatus();
            if (Membership.ValidateUser(data.user, data.pass))
            {
                FormsAuthentication.SetAuthCookie(data.user, false);
                status.Success = true;
                status.TargetURL = FormsAuthentication.
                                   GetRedirectUrl(data.user, false);
                if (string.IsNullOrEmpty(status.TargetURL))
                {
                    status.TargetURL = FormsAuthentication.DefaultUrl;
                }
                status.Message = "Acesso Correcto!";
            }
            else
            {
                status.Success = false;
                status.Message = "Usuario o contraseña incorrecto";
                status.TargetURL = FormsAuthentication.LoginUrl;
            }
            return Json(status);
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