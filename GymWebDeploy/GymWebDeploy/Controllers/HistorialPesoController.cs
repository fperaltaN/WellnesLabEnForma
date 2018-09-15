using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HistorialPesoController : Controller, IGenericController<HistorialPeso>
    {
        // GET: HistorialPeso
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<HistorialPeso>(ConfigurationManager.AppSettings["QueryGETHistorialPeso"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(HistorialPeso data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(HistorialPeso data)
        {
            throw new System.NotImplementedException();
        }
    }
}