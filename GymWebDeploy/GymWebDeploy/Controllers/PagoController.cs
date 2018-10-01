﻿using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class PagoController : Controller, IGenericController<Pago>
    {
        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSocios()
        {
            return Json(new GenericBaseDao().Get<Socio>(
                ConfigurationManager.AppSettings["QueryGETSocio"]), 
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaqueteID(Paquete data)
        {
            return Json(new GenericBaseDao().Get<Paquete>(string.Format(
                ConfigurationManager.AppSettings["QueryGETSocioPaquete"],data.id_paquete))
                ,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get()
        {
            throw new System.NotImplementedException();
        }

        public JsonResult Save(Pago data)
        {
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEPago"],
                data.id_paquete,
                data.id_socio,
                data.ID_USUARIO,
                data.importe,
//                data.fecha_pago_vence,
                data.pendiente)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Pago data)
        {
            throw new System.NotImplementedException();
        }
    }
}