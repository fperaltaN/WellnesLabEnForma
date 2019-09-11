
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymWebDeploy.Models.Domain;
using GymWebDeploy.Models.Dao;
using System.Configuration;
using GymWebDeploy.Controllers.utils;

namespace GymWebDeploy.Controllers
{
    public class ControlInventarioController : Controller, IGenericController<Inventario>
    {
        LoginController status = new LoginController();
        public JsonResult Get() => 
            Json(new GenericBaseDao().Get<CatalogoInventario>(ConfigurationManager.AppSettings["QueryGETInventarioAll"]), JsonRequestBehavior.AllowGet);
        public JsonResult GetControlInventarioAsignado() => Json(new GenericBaseDao().Get<InventarioAsignado>(ConfigurationManager.AppSettings["QueryGETInventarioAsignado"]), JsonRequestBehavior.AllowGet);
        public JsonResult SaveControlInventarioAsignado(InventarioAsignado data) => Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySaveInventarioAsignado"],
               data.id_socio, data.Id_inventario)
               ), JsonRequestBehavior.AllowGet);

        public JsonResult GetById(Inventario data)
        {
            return Json(new GenericBaseDao().Get<Inventario>(String.Format(ConfigurationManager.AppSettings["QueryGETInventario"], data.Id_cat_inventario)), JsonRequestBehavior.AllowGet);
        }
        // GET: Inventario
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

        public JsonResult Save(Inventario data) => Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEInventario"],
               data.Id_cat_inventario, data.Num_control)
               ), JsonRequestBehavior.AllowGet);

        public JsonResult Update(Inventario data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATEInventario"])), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateControlInventario(InventarioAsignado data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryDELETEInventarioAsignado"], data.Id_inventario)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetControlInventario() => Json(new GenericBaseDao().Get<InventarioAsignado>(ConfigurationManager.AppSettings["QueryGETInventarioNow"]), JsonRequestBehavior.AllowGet);

    }
}