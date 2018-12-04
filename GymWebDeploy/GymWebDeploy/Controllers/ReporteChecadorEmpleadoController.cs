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
    public class ReporteChecadorEmpleadoController : Controller, IGenericController<ReporteChecadorEmpleado>
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

        // GET: ReporteChecadorEmpleado
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(ReporteChecadorEmpleado data)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(ReporteChecadorEmpleado data)
        {
            throw new NotImplementedException();
        }
    }
}