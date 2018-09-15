using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class PerfilesController : Controller, IGenericController<Perfiles>
    {
        // GET: Perfiles
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Perfiles>(ConfigurationManager.AppSettings["QueryGETPerfiles"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Perfiles data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Perfiles data)
        {
            throw new System.NotImplementedException();
        }
    }
}