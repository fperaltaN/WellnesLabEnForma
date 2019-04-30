using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class ReportePagoController : Controller, IGenericController<ReportePago>
    {
        public JsonResult Get()
        {
            String toDayStart = DateTime.Today.ToString("yyyy - MM - dd") + " 00:00:00";
            String toDayEnd = DateTime.Today.ToString("yyyy - MM - dd") + " 23:59:00";
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"], toDayStart, toDayEnd)),
               JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByDate(GenericDataClass data)
        {
            String start = Convert.ToDateTime(data.start).ToString("yyyy - MM - dd") + " 00:00:00";
            String end = Convert.ToDateTime(data.end).ToString("yyyy - MM - dd") + " 23:59:00";
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"],start, end)),
               JsonRequestBehavior.AllowGet);
        }

        // GET: ReportePago
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(ReportePago data)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(ReportePago data)
        {
            throw new NotImplementedException();
        }
    }
}