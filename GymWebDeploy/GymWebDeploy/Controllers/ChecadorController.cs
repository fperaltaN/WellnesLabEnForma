using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class ChecadorController : Controller, IGenericController<Checador>
    {
        // GET: Checador
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Checador>(ConfigurationManager.AppSettings["QueryGETChecador"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Checador data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Checador data)
        {
            throw new System.NotImplementedException();
        }
    }
}