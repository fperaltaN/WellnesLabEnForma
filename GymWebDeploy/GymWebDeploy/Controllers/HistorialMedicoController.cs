using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HistorialMedicoController : Controller, IGenericController<HistorialMedico>
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
            return Json(new GenericBaseDao().Get<HistorialMedico>(ConfigurationManager.AppSettings["QueryGETHistorialMedico"]),JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(HistorialMedico data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySaveHistorialMedico"],
               data.id_socio, "Historial Medico socio:" + data.id_socio.ToString(), data.activo, Utils.FormatDates(DateTime.Today),
               data.problema_Cardiaco, data.dolor_Pecho, data.asma, data.medicamento, data.neurologicos, data.riesgo_Cardiovascular, 
               data.dolencias, data.enfermedad, data.presion_Alta)), JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(HistorialMedico data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATEHistorialMedico"],
               data.id_historial_medico, data.id_socio, "Historial Medico socio:" + data.id_socio.ToString(), data.activo, Utils.FormatDates(DateTime.Today),
               data.problema_Cardiaco, data.dolor_Pecho, data.asma, data.medicamento, data.neurologicos, data.riesgo_Cardiovascular,
               data.dolencias, data.enfermedad, data.presion_Alta)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSocios()
        {
            return Json(new GenericBaseDao().Get<SocioId>(string.Format(
                ConfigurationManager.AppSettings["QuerySocios"]))
                , JsonRequestBehavior.AllowGet);
        }
    }
}