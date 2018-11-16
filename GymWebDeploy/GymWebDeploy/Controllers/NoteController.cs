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

        // GET: Note
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(Notes data)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(Notes data)
        {
            throw new NotImplementedException();
        }
    }
}