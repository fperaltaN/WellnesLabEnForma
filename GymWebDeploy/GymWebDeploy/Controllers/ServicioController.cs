using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class ServicioController : Controller, IGenericController<Servicio>
    {
        // GET: Servicio
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Servicio>(ConfigurationManager.AppSettings["QueryGETServicio"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Servicio data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Servicio data)
        {
            throw new System.NotImplementedException();
        }
    }
}