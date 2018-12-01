using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Get() => Json(new GenericBaseDao().Get<InventarioAsignado>(ConfigurationManager.AppSettings["QueryGETInventarioNow"]), JsonRequestBehavior.AllowGet);
    }
}