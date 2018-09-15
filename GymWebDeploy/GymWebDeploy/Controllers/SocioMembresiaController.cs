using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class SocioMembresiaController : Controller, IGenericController<SocioMembresia>
    {
        // GET: SocioMembresia
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<SocioMembresia>(ConfigurationManager.AppSettings["QueryGETSocioMembresia"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(SocioMembresia data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(SocioMembresia data)
        {
            throw new System.NotImplementedException();
        }
    }
}