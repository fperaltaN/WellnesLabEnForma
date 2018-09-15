using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class ModuloController : Controller, IGenericController<Modulo>
    {
        // GET: Modulo
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Modulo>(ConfigurationManager.AppSettings["QueryGETModulo"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Modulo data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Modulo data)
        {
            throw new System.NotImplementedException();
        }
    }
}