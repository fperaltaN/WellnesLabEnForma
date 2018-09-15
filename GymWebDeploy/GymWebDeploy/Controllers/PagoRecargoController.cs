using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class PagoRecargoController : Controller, IGenericController<PagoRecargo>
    {
        // GET: PagoRecargo
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<PagoRecargo>(ConfigurationManager.AppSettings["QueryGETPagoRecargo"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(PagoRecargo data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(PagoRecargo data)
        {
            throw new System.NotImplementedException();
        }
    }
}