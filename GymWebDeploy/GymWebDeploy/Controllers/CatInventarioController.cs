using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class CatInventarioController : Controller, IGenericController<CatalogoInventario>
    {
        public JsonResult Get() => Json(new GenericBaseDao().Get<CatalogoInventario>(ConfigurationManager.AppSettings["QueryGETCatInventario"]), JsonRequestBehavior.AllowGet);

        // GET: CatInventario
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Save(CatalogoInventario data) => Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySaveCatInventario"],
               data.nombre)
               ), JsonRequestBehavior.AllowGet);


        public JsonResult Update(CatalogoInventario data) => Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATECatInventario"],
                data.nombre,
                data.activo,
                data.Id_cat_inventario)
                ), JsonRequestBehavior.AllowGet);
    }
}
