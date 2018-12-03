using GymWebDeploy.Controllers.utils;
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
            try
            {
                return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEPagoRecargo"])), JsonRequestBehavior.AllowGet);
            }
            catch(System.Exception e)
            {
                return null;
            }
        }

        public JsonResult Update(PagoRecargo data)
        {
            throw new System.NotImplementedException();
        }
    }
}