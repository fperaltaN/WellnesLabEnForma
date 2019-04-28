using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class SocioMembresiaController : Controller, IGenericController<SocioMembresia>
    {
        LoginController status = new LoginController();
        // GET: SocioMembresia
        public ActionResult Index()
        {
            if(!status.checkSession())
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        public JsonResult GetSocios()
        {
            return Json(new GenericBaseDao().Get<SocioId>(
                ConfigurationManager.AppSettings["QuerySociosMembresia"]),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaquetes()
        {
            return Json(new GenericBaseDao().Get<Paquete>(string.Format(
                ConfigurationManager.AppSettings["QueryPaquetesMembresia"]))
                , JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<SocioMembresia>(ConfigurationManager.AppSettings["QueryGETSocioMembresia"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(SocioMembresia data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVESocioMembresia"],
                data.id_socio,
                data.id_paquete,
                Utils.FormatDates(DateTime.Today), 
                Utils.FormatDates(DateTime.Today),
                Utils.FormatDates(DateTime.Today),
                Utils.FormatDates(DateTime.Today))), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(SocioMembresia data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATESocioMembresia"],
                data.id_socio_membresia,
                data.id_socio,
                data.id_paquete,
                Utils.FormatDates(DateTime.Today),
                Utils.FormatDates(DateTime.Today),
                Utils.FormatDates(DateTime.Today),
                data.activo,
                Utils.FormatDates(DateTime.Today))), JsonRequestBehavior.AllowGet);
        }
    }
}