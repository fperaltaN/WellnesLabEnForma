using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class VentaController : Controller, IGenericController<Venta>
    {
        // GET: Venta
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Venta>(ConfigurationManager.AppSettings["QueryGETVenta"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Venta data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Venta data)
        {
            throw new System.NotImplementedException();
        }
    }
}