using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class RecargoController : Controller, IGenericController<Recargo>
    {
        // GET: Recargo
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Recargo>(ConfigurationManager.AppSettings["QueryGETRecargo"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Recargo data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Recargo data)
        {
            throw new System.NotImplementedException();
        }
    }
}