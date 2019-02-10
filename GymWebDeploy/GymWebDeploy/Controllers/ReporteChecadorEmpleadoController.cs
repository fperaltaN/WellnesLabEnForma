﻿using System;
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
            return Json(new GenericBaseDao().Get<ReporteChecadorEmpleado>(
                ConfigurationManager.AppSettings["QueryGETChecador"]),
                JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByDate(GenericDataClass data)
        {
            return Json(new GenericBaseDao().Get<ReporteChecadorEmpleado>(string.Format(
               ConfigurationManager.AppSettings["QueryGETChecadorByDate"], Convert.ToDateTime(data.start).ToShortDateString(), Convert.ToDateTime(data.end).ToShortDateString())),
               JsonRequestBehavior.AllowGet);
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