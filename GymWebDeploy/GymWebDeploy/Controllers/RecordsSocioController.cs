using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class RecordsSocioController : Controller, IGenericController<RecordsSocio>
    {
        // GET: RecordsSocio
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<RecordsSocio>(ConfigurationManager.AppSettings["QueryGETRecordsSocio"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(RecordsSocio data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(RecordsSocio data)
        {
            throw new System.NotImplementedException();
        }
    }
}