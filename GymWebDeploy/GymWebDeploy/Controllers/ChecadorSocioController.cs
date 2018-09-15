using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class ChecadorSocioController : Controller, IGenericController<ChecadorSocio>
    {
        // GET: ChecadorSocio
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<ChecadorSocio>(ConfigurationManager.AppSettings["QueryGETChecadorSocio"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(ChecadorSocio data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(ChecadorSocio data)
        {
            throw new System.NotImplementedException();
        }
    }
}