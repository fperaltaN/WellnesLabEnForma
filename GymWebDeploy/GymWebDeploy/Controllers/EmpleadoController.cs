using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class EmpleadoController : Controller, IGenericController<Empleado>
    {
        LoginController status = new LoginController();
        // GET: Empleado
        public ActionResult Index()
        {
            if (!status.checkSession())
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        public JsonResult Get()
        {
            return Json(new GenericBaseDao().Get<Empleado>(ConfigurationManager.AppSettings["QueryGETEmpleado"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(Empleado data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEEmpleado"],
                 data.num_empleado,
                 data.nombre,
                 data.ap_paterno,
                 data.ap_materno,
                 data.telefono,
                 data.direccion,
                 Utils.FormatDates(DateTime.Today),
                 Utils.FormatDates(DateTime.Today),
                 data.activo,
                 Utils.FormatDates(DateTime.Today),
                 data.id_perfil
                 )), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Empleado data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATEEmpleado"],
                data.num_empleado,
                data.nombre,
                data.ap_paterno, 
                data.ap_materno,
                data.telefono,
                data.direccion,
                data.id_perfil,
                Utils.FormatDates(DateTime.Today), 
                data.activo,
                data.id_empleado
                )), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetEmpleadoLastNum()
        {
            return Json(new GenericBaseDao().Get<Empleado>(string.Format(
                ConfigurationManager.AppSettings["QueryLASTNumEmpleado"]))
                , JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPerfiles()
        {
            return Json(new GenericBaseDao().Get<Perfiles>(string.Format(ConfigurationManager.AppSettings["QueryGETPerfiles"])), JsonRequestBehavior.AllowGet);
        }
    }
}