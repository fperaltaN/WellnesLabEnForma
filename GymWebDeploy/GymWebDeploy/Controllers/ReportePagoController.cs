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
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"], DateTime.Today.ToShortDateString(), DateTime.Today.ToShortDateString())),
               JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByDate(GenericDataClass data)
        {
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"],data.start,data.end)),
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