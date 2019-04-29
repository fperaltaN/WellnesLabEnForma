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
            String toDay = DateTime.Today.ToString("yyyy - MM - dd");
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"], toDay,toDay)),
               JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByDate(GenericDataClass data)
        {
            String start = Convert.ToDateTime(data.start).ToString("yyyy - MM - dd");
            String end = Convert.ToDateTime(data.end).ToString("yyyy - MM - dd");
            return Json(new GenericBaseDao().Get<ReportePago>(string.Format(
               ConfigurationManager.AppSettings["QueryGETReportePago"],Convert.ToDateTime(start), Convert.ToDateTime(end))),
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