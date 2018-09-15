using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class PaqueteController : Controller, IGenericController<Paquete>
    {
        // GET: Paquete
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Paquete>(
                ConfigurationManager.AppSettings["QueryGETPaquete"]),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Paquete data)
        {
            return Json(Utils.Execute(string.Format(
                ConfigurationManager.AppSettings["QuerySAVEPaquete"],
                data.nombre,
                data.descripcion,
                data.costo,
                data.ID_USUARIO,
                data.activo,
                Utils.FormatDates(DateTime.Today),
                data.diaspaquetes)),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Paquete data)
        {
            return Json(Utils.Execute(string.Format(
                ConfigurationManager.AppSettings["QueryUPDATEPaquete"], 
                data.nombre, 
                data.descripcion, 
                data.costo, 
                data.ID_USUARIO, 
                data.diaspaquetes, 
                data.activo, 
                Utils.FormatDates(DateTime.Today),
                data.id_paquete)), 
                JsonRequestBehavior.AllowGet);
        }
    }
}