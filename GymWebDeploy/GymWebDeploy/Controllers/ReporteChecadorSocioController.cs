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
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"], DateTime.Today.ToShortDateString(), DateTime.Today.ToShortDateString())),
               JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByDate(GenericDataClass data)
        {
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"], Convert.ToDateTime(data.start).ToShortDateString(), Convert.ToDateTime(data.end).ToShortDateString())),
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