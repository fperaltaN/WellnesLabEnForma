using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class ModulosController : Controller, IGenericController<Modulos>
    {
        // GET: Modulos
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Modulos>(ConfigurationManager.AppSettings["QueryGETModulos"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Modulos data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Modulos data)
        {
            throw new System.NotImplementedException();
        }
    }
}