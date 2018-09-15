using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class RecordTicketController : Controller, IGenericController<RecordTicket>
    {
        // GET: RecordTicket
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<RecordTicket>(ConfigurationManager.AppSettings["QueryGETRecordTicket"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(RecordTicket data)
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Update(RecordTicket data)
        {
            throw new System.NotImplementedException();
        }
    }
}