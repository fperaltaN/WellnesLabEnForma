using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class RecordController : Controller, IGenericController<Record>
    {
        // GET: Record
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Record>(ConfigurationManager.AppSettings["QueryGETRecord"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Record data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(Record data)
        {
            throw new System.NotImplementedException();
        }
    }
}