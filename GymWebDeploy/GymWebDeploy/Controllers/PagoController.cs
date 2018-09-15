using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class PagoController : Controller, IGenericController<Pago>
    {
        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSocios()
        {
            return Json(new GenericBaseDao().Get<Socio>(
                ConfigurationManager.AppSettings["QueryGETSocio"]), 
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaqueteID(Paquete data)
        {
            return Json(new GenericBaseDao().Get<Paquete>(string.Format(
                ConfigurationManager.AppSettings["QueryGETPaqueteID"],data.id_paquete))
                ,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get()
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Save(Pago data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Pago data)
        {
            throw new System.NotImplementedException();
        }
    }
}