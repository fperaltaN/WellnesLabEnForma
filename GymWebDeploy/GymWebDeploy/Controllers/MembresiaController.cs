using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class MembresiaController : Controller, IGenericController<Membresia>
    {
        // GET: Membresia
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Membresia>(ConfigurationManager.AppSettings["QueryGETMembresia"]), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Save(Membresia data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySaveMembresia"], data.nombre, data.descripcion, data.costo, data.activo, data.fecha_modificacion)),JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Membresia data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUpdateMembresia"], data.nombre, data.descripcion, data.costo, data.activo, data.fecha_modificacion, data.id_membresia)),JsonRequestBehavior.AllowGet);
        }
    }
}