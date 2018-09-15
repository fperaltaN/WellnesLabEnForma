using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class AsignacionController : Controller,IGenericController<Asignacion>
    {
        // GET: Asignacion
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Asignacion>(ConfigurationManager.AppSettings["QueryGETAsignacion"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Asignacion data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Asignacion data)
        {
            throw new System.NotImplementedException();
        }
    }
}