using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using GymWebDeploy.Models.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
namespace GymWebDeploy.Controllers
{
    public class PagoController : Controller, IGenericController<Pago>
    {
        LoginController status = new LoginController();
        // GET: 
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

        public JsonResult GetSocios()
        {
            return Json(new GenericBaseDao().Get<Socio>(
                ConfigurationManager.AppSettings["QueryGETSocio"]),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaqueteID(Socio data)
        {
            return Json(new GenericBaseDao().Get<Paquete>(string.Format(
                ConfigurationManager.AppSettings["QueryGETSocioPaquete"], data.id_socio))
                , JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPendiente(Socio data)
        {
            return Json(new GenericBaseDao().Get<Pago>(string.Format(
                ConfigurationManager.AppSettings["QueryGETPendiente"], data.id_socio))
                , JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get()
        {
            return Json("");
        }

        public JsonResult Save(Pago data)
        {
            saveTicket(data);
            return Json(Utils.Execute(string.Format(ConfigurationManager.AppSettings["QuerySAVEPago"],
                data.id_paquete,
                data.id_socio,
                data.ID_USUARIO,
                data.importe,
                Convert.ToDateTime(data.fecha_pago_vence).ToString("yyyy-MM-dd HH:mm:ss"),
                data.pendiente,data.refTicketVenta)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Pago data)
        {
            throw new System.NotImplementedException();
        }

        // <summary>
        /// Guarda el Ticket del socio en formato txt
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool saveTicket(Pago data)
        {
            PDFTicket pdfticket = new PDFTicket();
            List<Socio> socioData = new GenericBaseDao().Get<Socio>(ConfigurationManager.AppSettings["QueryGETSocio"]);
            List<Empleado> empleadoData = new GenericBaseDao().Get<Empleado>(ConfigurationManager.AppSettings["QueryGETEmpleado"]);
            List<Paquete> paqueteData = new GenericBaseDao().Get<Paquete>(ConfigurationManager.AppSettings["QueryGETPaquete"]);
            //lamba para no hacer mas consultas
            Socio socio = socioData.Find(x => x.id_socio == data.id_socio);
            Empleado empleado = empleadoData.Find(x => x.id_empleado == data.ID_USUARIO);
            Paquete paquete = paqueteData.Find(x => x.id_paquete == data.id_paquete);
            bool impreso = pdfticket.printTicketPayment(socio.num_socio.ToString(),
                socio.nombre + " " + socio.ap_materno + " " + socio.ap_paterno,
                empleado.nombre + " " + empleado.ap_materno + " " + empleado.ap_paterno,
                paquete.nombre + " " + paquete.descripcion,
                data);
            data.refTicketVenta = "Ticket_Venta__" + socio.num_socio + "_Socio_ " + socio.nombre + " " + socio.ap_materno + " " + socio.ap_paterno + "_" + DateTime.Now.ToLongDateString() + ".pdf";
            return impreso;
        }

    }
}