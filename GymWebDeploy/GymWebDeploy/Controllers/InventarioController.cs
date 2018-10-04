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

        // GET: Inventario
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(Inventario data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEInventario"],
               data.id_cat_inventario,data.num_control)
               ), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Inventario data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QueryUPDATEInventario"])),JsonRequestBehavior.AllowGet);
        }
    }
}