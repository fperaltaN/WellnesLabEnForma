using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymWebDeploy.Models.Domain;
using GymWebDeploy.Models.Dao;
using System.Configuration;

namespace GymWebDeploy.Controllers
{
    public class ReporteChecadorSocioController : Controller, IGenericController<ReporteChecadorSocio>
    {
        LoginController status = new LoginController();
        // GET: 
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
        public JsonResult Get()
        {
            var jsonResult = Json(new GenericBaseDao().Get<ReporteChecadorSocio>(
             ConfigurationManager.AppSettings["QueryGETChecadorSocio"]),
             JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetByDateSocio(GenericDataClass data)
        {
            String start = Convert.ToDateTime(data.start).ToString("yyyy - MM - dd") + " 00:00:00";
            String end = Convert.ToDateTime(data.end).ToString("yyyy - MM - dd") + " 23:59:00";
            return Json(new GenericBaseDao().Get<ReporteChecadorSocio>(string.Format(
               ConfigurationManager.AppSettings["QueryGETChecadorSocioByDate"], start, end)),
               JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(ReporteChecadorSocio data)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(ReporteChecadorSocio data)
        {
            throw new NotImplementedException();
        }
    }
}