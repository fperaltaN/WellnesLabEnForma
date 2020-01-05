using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using GymWebDeploy.Models.Domain.Utils;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class CumpleanosController : Controller, IGenericController<Empleado>
    {
        LoginController status = new LoginController();
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Socio>(ConfigurationManager.AppSettings["QueryGETCumple"]), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCumple()
        {
            return Json(new GenericBaseDao().Get<Socio>(ConfigurationManager.AppSettings["QueryGETCumple"]), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCumpleByDate(GenericDataClass data)
        {
            String start = Convert.ToDateTime(data.start).ToString("yyyy - MM - dd") + " 00:00:00";
            String end = Convert.ToDateTime(data.end).ToString("yyyy - MM - dd") + " 23:59:00";
            return Json(new GenericBaseDao().Get<Socio>(string.Format(
               ConfigurationManager.AppSettings["QueryGETCumpleByDate"], start, end)),
               JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {

            if (!status.checkSession())
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }

        }
        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            LoginController logout = new LoginController();
            logout.sessionAbandon();
            return RedirectToAction("Index", "Home");
        }

        public JsonResult Save(Empleado data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Empleado data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult sendBirthDayMail(String data)
        {
            try
            {
                Mail mail = new Mail();
                mail.mail = data;
                mail.send(true);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}