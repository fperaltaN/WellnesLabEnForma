using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
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
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEUsuarios"],
                 data.NOMBRE,
                 data.APELLIDO_PAT,
                 data.APELLIDO_MAT,
                 data.USUARIO,
                 data.PASSWORD,
                 data.ID_PERFIL,
                 data.ACTIVO,
                 Utils.FormatDates(DateTime.Today),                 
                 Utils.FormatDates(DateTime.Today)
                 )), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Usuarios data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATEUsuarios"],
                 data.ID_USUARIO,
                 data.NOMBRE,
                 data.APELLIDO_PAT,
                 data.APELLIDO_MAT,
                 data.USUARIO,
                 data.PASSWORD,
                 data.ID_PERFIL,
                 data.ACTIVO,
                 Utils.FormatDates(DateTime.Today),
                 Utils.FormatDates(DateTime.Today)
                 )), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPerfiles()
        {
            return Json(new GenericBaseDao().Get<Perfiles>(string.Format(ConfigurationManager.AppSettings["QueryGETPerfiles"])), JsonRequestBehavior.AllowGet);
        }
    }
}