using GymWebDeploy.Controllers.utils;
using GymWebDeploy.Models.Dao;
using GymWebDeploy.Models.Domain;
using GymWebDeploy.Models.Domain.Utils;
using System.Collections.Generic;
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
                data.fecha_pago_vence,
                data.pendiente)), JsonRequestBehavior.AllowGet);
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
            bool impreso = pdfticket.printTicketPayment(socioData[0].num_socio.ToString(),
                socioData[0].nombre + " " + socioData[0].ap_materno + " " + socioData[0].ap_paterno,
                empleadoData[0].nombre + " " + empleadoData[0].ap_materno + " " + empleadoData[0].ap_paterno,
                paqueteData[0].nombre + " " + paqueteData[0].descripcion,
                data); 
            return impreso;
        }

    }
}