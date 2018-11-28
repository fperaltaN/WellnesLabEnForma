using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymWebDeploy.Controllers
{
    public class InventarioController : Controller, IGenericController<Inventario>
    {
        public JsonResult Get() => Json(new GenericBaseDao().Get<CatalogoInventario>(ConfigurationManager.AppSettings["QueryGETInventario"]), JsonRequestBehavior.AllowGet);
        public JsonResult GetInventarioAsignado() => Json(new GenericBaseDao().Get<InventarioAsignado>(ConfigurationManager.AppSettings["QueryGETInventarioAsignado"]), JsonRequestBehavior.AllowGet);
        public JsonResult SaveAsignado(InventarioAsignado data) => Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySaveInventarioAsignado"],
               data.id_cat_inventario,data.num_control,data.id_socio,1)
               ), JsonRequestBehavior.AllowGet);

        public JsonResult GetById(Inventario data)
        {
            return Json(new GenericBaseDao().Get<Inventario>(String.Format(ConfigurationManager.AppSettings["QueryGETInventario"], data.Id_cat_inventario)), JsonRequestBehavior.AllowGet);
        }
        // GET: Inventario
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(Inventario data) => Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEInventario"],
               data.Id_cat_inventario, data.Num_control)
               ), JsonRequestBehavior.AllowGet);

        public JsonResult Update(Inventario data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATEInventario"])), JsonRequestBehavior.AllowGet);
        }
    }
}