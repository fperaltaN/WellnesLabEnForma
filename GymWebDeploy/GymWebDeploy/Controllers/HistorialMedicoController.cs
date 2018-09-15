using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class HistorialMedicoController : Controller, IGenericController<HistorialMedico>
    {
        // GET: HistorialMedico
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<HistorialMedico>(ConfigurationManager.AppSettings["QueryGETHistorialMedico"]),JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(HistorialMedico data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(HistorialMedico data)
        {
            throw new System.NotImplementedException();
        }
    }
}