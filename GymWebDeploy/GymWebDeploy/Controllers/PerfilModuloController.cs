using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class PerfilModuloController : Controller, IGenericController<PerfilModulo>
    {
        // GET: Rel_Perfil_Modulo
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<PerfilModulo>(ConfigurationManager.AppSettings["QueryGETPerfilModulo"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(PerfilModulo data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(PerfilModulo data)
        {
            throw new System.NotImplementedException();
        }
    }
}