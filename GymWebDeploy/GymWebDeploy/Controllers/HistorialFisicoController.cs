using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HistorialFisicoController : Controller, IGenericController<HistorialFisico>
    {
        // GET: HistorialFisico
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<HistorialFisico>(ConfigurationManager.AppSettings["QueryGETHistorialFisico"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(HistorialFisico data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(HistorialFisico data)
        {
            throw new System.NotImplementedException();
        }
        public JsonResult GetSocios()
        {
            return Json(new GenericBaseDao().Get<SocioId>(string.Format(
                ConfigurationManager.AppSettings["QuerySocios"]))
                , JsonRequestBehavior.AllowGet);
        }
    }
}