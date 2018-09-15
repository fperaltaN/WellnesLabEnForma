using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class UsuarioController : Controller, IGenericController<Usuarios>
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Usuarios>(ConfigurationManager.AppSettings["QueryGETUsuarios"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Usuarios data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Usuarios data)
        {
            throw new System.NotImplementedException();
        }
    }
}