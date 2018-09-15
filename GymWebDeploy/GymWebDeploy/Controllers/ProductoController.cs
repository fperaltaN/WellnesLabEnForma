using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class ProductoController : Controller, IGenericController<Producto>
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Producto>(ConfigurationManager.AppSettings["QueryGETProducto"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Producto data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Producto data)
        {
            throw new System.NotImplementedException();
        }
    }
}