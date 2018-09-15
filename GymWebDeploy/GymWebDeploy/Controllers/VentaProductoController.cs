using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class VentaProductoController : Controller, IGenericController<VentaProducto>
    {
        // GET: VentaProducto
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<VentaProducto>(ConfigurationManager.AppSettings["QueryGETVentaProducto"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(VentaProducto data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(VentaProducto data)
        {
            throw new System.NotImplementedException();
        }
    }
}