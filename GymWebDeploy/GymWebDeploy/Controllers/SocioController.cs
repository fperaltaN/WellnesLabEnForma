using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class SocioController : Controller, IGenericController<Socio>
    {
        LoginController status = new LoginController();
        // GET: Socio
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
            return Json(new GenericBaseDao().Get<Socio>(ConfigurationManager.AppSettings["QueryGETSocio"]), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(Socio data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySaveSocio"], 
                data.num_socio,
                data.nombre, 
                data.ap_paterno, data.ap_materno, data.direccion, Utils.FormatDates(DateTime.Today), Utils.FormatDates(DateTime.Today), data.activo, Utils.FormatDates(DateTime.Today), data.telefono, Utils.FormatDates(data.fecha_nacimiento), data.compEstudios, data.mail)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Socio data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATESocio"], data.nombre, data.ap_paterno, data.ap_materno, data.direccion, Utils.FormatDates(DateTime.Today), data.activo, Utils.FormatDates(DateTime.Today), data.telefono, Utils.FormatDates(data.fecha_nacimiento), data.compEstudios, data.mail, data.id_socio)),JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSocioLastNum()
        {
            return Json(new GenericBaseDao().Get<Socio>(string.Format(
                ConfigurationManager.AppSettings["QueryLASTNumSocio"]))
                , JsonRequestBehavior.AllowGet);
        }
    }
}