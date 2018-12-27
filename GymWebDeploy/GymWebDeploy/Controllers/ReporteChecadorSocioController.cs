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
            return Json(new GenericBaseDao().Get<ReporteChecadorSocio>(string.Format(
               ConfigurationManager.AppSettings["QueryGETChecadorSocioByDate"], Convert.ToDateTime(data.start).ToShortDateString(), Convert.ToDateTime(data.end).ToShortDateString())),
               JsonRequestBehavior.AllowGet);
        }
        // GET: ReporteChecadorSocio
        public ActionResult Index()
        {
            return View();
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