using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class RegistroVisitaController : Controller, IGenericController<RegistroVisita>
    {
        // GET: RegistroVisita
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<RegistroVisita>(ConfigurationManager.AppSettings["QueryGETRegistroVisita"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(RegistroVisita data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(RegistroVisita data)
        {
            throw new System.NotImplementedException();
        }
    }
}