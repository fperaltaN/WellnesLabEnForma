using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class PaqueteServicioController : Controller, IGenericController<PaqueteServicio>
    {
        // GET: PaqueteServicio
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<PaqueteServicio>(ConfigurationManager.AppSettings["QueryGETPaqueteServicio"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(PaqueteServicio data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(PaqueteServicio data)
        {
            throw new System.NotImplementedException();
        }
    }
}