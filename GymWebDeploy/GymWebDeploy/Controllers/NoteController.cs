using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class NoteController : Controller, IGenericController<Notes>
    {
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Notes>(ConfigurationManager.AppSettings["QueryGETNote"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCumple()
        {
            return Json(new GenericBaseDao().Get<Socio>(ConfigurationManager.AppSettings["QueryGETCumple"]), JsonRequestBehavior.AllowGet);
        }

        // GET: Note
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(Notes data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryInsertNote"], data.Note)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Notes data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATENote"], data.Note, data.IdNote)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(Notes data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryDELETENote"], data.IdNote)), JsonRequestBehavior.AllowGet);
        }
    }
}