using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HistorialFisicoController : Controller, IGenericController<HistorialFisico>
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
            return Json(new GenericBaseDao().Get<HistorialFisico>(ConfigurationManager.AppSettings["QueryGETHistorialFisico"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(HistorialFisico data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEHistorialFisico"],
               data.id_socio, "Historial Medico socio:" + data.id_socio.ToString(), data.activo, Utils.FormatDates(DateTime.Today),
               data.actividad_Fisica, data.tiempo_Actividad_Fisica, data.tipo_Actividad_Fisica, data.fuma, data.toma, data.lesiones,data.fatigado_ejercicio)), JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(HistorialFisico data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATEHistorialFisico"],
               data.id_historial_fisico,data.id_socio, "Historial Medico socio:" + data.id_socio.ToString(), data.activo, Utils.FormatDates(DateTime.Today),
               data.actividad_Fisica, data.tiempo_Actividad_Fisica, data.tipo_Actividad_Fisica, data.fuma, data.toma, data.lesiones, data.fatigado_ejercicio)), JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetSocios()
        {
            return Json(new GenericBaseDao().Get<SocioId>(string.Format(
                ConfigurationManager.AppSettings["QuerySociosHistorialFisico"]))
                , JsonRequestBehavior.AllowGet);
        }
    }
}