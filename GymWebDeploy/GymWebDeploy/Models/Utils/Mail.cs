using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Net.Mime;
using GymWebDeploy.Models.Domain;

namespace GymWebDeploy.Models.Domain.Utils
{
    public class Mail
    {
        #region Variable
        MailMessage mmsg = new MailMessage();
        Attachment adjuntos;
        SmtpClient cliente = new SmtpClient();
        String archivos = "";
        List<String> destinatario = new List<String>();
        String destinatarioCopia = "";
        String cuerpo = "";
        String footer = "Este mensaje se dirige exclusivamente a su destinatario. " +
            "Contiene información CONFIDENCIAL sometida a secreto profesional o cuya divulgación está prohibida por la ley. " +
            "Si ha recibido este mensaje por error, debe saber que su lectura, copia y uso están prohibidos. " +
            "Le rogamos que nos lo comunique inmediatamente por esta misma vía o por teléfono y proceda a su destrucción.";
        #endregion Variables

        #region funcionality

        /// <summary>
        /// property mail
        /// </summary>
        public string mail { get; set; }

        /// <summary>
        /// Constructor, Asigna el cuerpo
        /// </summary>
        public Mail()
        {
        }

        /// <summary>
        /// Constructor, Asigna el cuerpo
        /// </summary>
        public Mail(String descripcionProgreso)
        {
            cuerpo = "<u><b>Propósito:Comprobante de Progreso</u></b>" +
                         "<br><br>" +
                         "Estimado:Socio <br><br><br>" +
                         "Adjunto podra encontrar la información de su Progreso:" +
                         "<br><br>" +
                         descripcionProgreso +
                         " <br>" +
                         " Favor de revisar tu información, no olvides ponerte en contacto con nosotros para dudas y aclaraciones." +
                         "<br><br>" +
                         "Gracias por ser parte de nuestra familia" +
                         "<br><br>" +
                         "<h6>" + footer + "</h6></br>" +
                         "<h6>/////************************* Por Favor, No respondas este correo  =)   " + DateTime.Now.ToShortDateString() + " SISA - Wellness Lab En Forma 2018. *************************////<br>";
        }

        /// <summary>
        /// Agrega los destinatarios al Objeto del Correo
        /// </summary>
        public void recipients()
        {
            //foreach (var item in destinatario)
            //{
            mmsg.To.Add(mail);
            //}
        }

        /// <summary>
        ///  Envia Correos 
        /// </summary>
        public Boolean send(bool optionHeader)
        {
            try
            {
                // Ahora creamos la vista para clientes que 
                // pueden mostrar contenido HTML...
                string html = "<img src='cid:imagen' />";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html,
                                            Encoding.UTF8,
                                            MediaTypeNames.Text.Html);

                // Creamos el recurso a incrustar. Observa que el ID que le asignamos (arbitrario) está referenciado desde el código HTML como origen
                // de la imagen (resaltado en amarillo)...
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(cuerpo, null, MediaTypeNames.Text.Html);
                LinkedResource img = new LinkedResource(@"C:\globos.jpg", MediaTypeNames.Image.Jpeg);
                img.ContentId = "imagen";

                // Lo incrustamos en la vista HTML...
                htmlView.LinkedResources.Add(img);
                //mmsg = new MailMessage(Usuario, PassWord);
                recipients();
                //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario
                //Asunto
                mmsg.Subject = optionHeader ? "¡Feliz Cumpleaños! " : "Comprobante de Progreso";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                //Cuerpo del Mensaje
                mmsg.Body = cuerpo;
                //if (opcionCabecero)
                //{
                //    mmsg.AlternateViews.Add(htmlView);
                //    mmsg.AlternateViews.Add(plainView);
                //}
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

                //Correo electronico desde la que enviamos el mensaje
                mmsg.From = new MailAddress("wellnesslabenformamx@gmail.com");
                return clienteCorreo();
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///  Guarda el ticket 2 para control del usuario.
        /// </summary>
        /// <param name="complete"></param>
        /// <param name="numSocio"></param>
        /// <param name="nombreCompleto"></param>
        /// <param name="entrenador"></param>
        /// <param name="registro"></param>
        /// <returns></returns>
        public String descriptionProgressRecord(bool complete, String numSocio, String nombreCompleto, String entrenador, RecordTicket registro)
        {
            String lineComplete = " " + "***** PORCENTAJE CARGA  ****** " + "<br>" +
                     " " + "*" + "Pecho: " + registro.porcentajeCargaPecho + "<br>" +
                     " " + "*" + "Pierna: " + registro.porcentajeCargaPierna + "<br>" +
                     "   " + "<br>" +
                     " " + "***** METABOLISMO  ****** " + "<br>" +
                     " " + "*" + "Basal: " + registro.metabolismoBasal;
            String lines = "WELLNESS LAB EN FORMA" + "" + "\n" +
                     "EXPEDIDO EN:" + "<br />" + "\n" +
                     "CALLE ODONTOLOGÍA NO. 13 LOC. 1 COLONIA SPUAZ" + "" + "\n" +
                     "MEXICO, GPE. ZACATECAS" + "\n" +
                     " " + "<br>" +
                     "Socio: " + numSocio + " " + nombreCompleto + " " + "<br>" +
                     "Fecha de revisión: " + DateTime.Now.ToShortDateString() + "" + "<br>" +
                     " " + "***** INICIALES  ****** " + "<br>" +
                     " " + "*" + "Trigliceridos: " + registro.trigliceridos + "<br>" +
                     " " + "*" + "Colesterol: " + registro.Colesterol + "<br>" +
                     " " + "*" + "Glucosa: " + registro.Glucosa + "<br>" +
                     "   " + "<br>" +
                     " " + "***** PLIEGUES  ****** " + "<br>" +
                     " " + "*" + "Tricipal: " + registro.pliegueTricipal + "<br>" +
                     " " + "*" + "Escapular: " + registro.pliegueEscapular + "<br>" +
                     "   " + "<br>" +
                     " " + "***** Presión  ****** " + "<br>" +
                     " " + "*" + "Cardiaca: " + registro.frecuenciaCardiaca + "<br>" +
                     " " + "*" + "Arterial Sisfolica: " + registro.frecuanciArtSisfolica + "<br>" +
                     " " + "*" + "Arterial Diasfolica: " + registro.frecuanciArtDiasfolica + "<br>" +
                     "   " + "<br>" +
                     (complete ? lineComplete : "") +
                     " " + "*" + "<br>" +
                     " " + " " + "<br>" +
                     " " + "TU SALUD ES NUESTRA PASION..." + " " + "<br>" +
                    "VIVE LA EXPERIENCIA WELLNESS LAB EN FORMA" + " " + "<br>" +
                     "GRACIAS POR SU PREFERENCIA" + " ";

            return lines;
        }

        /// <summary>
        ///  Guarda el ticket 1 para control del usuario.
        /// </summary>
        /// <param name="complete"></param>
        /// <param name="numSocio"></param>
        /// <param name="nombreCompleto"></param>
        /// <param name="entrenador"></param>
        /// <param name="registro"></param>
        /// <returns></returns>
        public String descriptionProgressCustom(bool complete, String numSocio, String nombreCompleto, String entrenador, Record registro)
        {
            String lineComplete = " " + "***** PECHO ****** " + "<br>" +
                          " " + "*" + "Inicial: " + registro.circPechoInicial + "<br>" +
                          " " + "*" + "Bajado: " + registro.circPechoBajado + "<br>" +
                          " " + "*" + "Actual: " + registro.circPechoActual + "<br>" +
                          "   " + "<br>" +
                          " " + "***** FRECUENCIA CARDIACA / %  ****** " + "<br>" +
                          " " + "*" + "Maxima: " + registro.frecCardicaMaxima + "<br>" +
                          " " + "*" + "Reposo: " + registro.frecCardicaReposo + "<br>" +
                          " " + "*" + "% Entrenamieto: " + registro.porceEntrenamiento + "<br>" +
                          "   " + "<br>" +
                          " " + "***** IMC / P.I.E  ****** " + "<br>" +
                          " " + "*" + "IMC: " + registro.imc + "<br>" +
                          " " + "*" + "P.I.E: " + registro.pie + "<br>" +
                          "   ";
            String lines = "WELLNESS LAB EN FORMA" + "<br>" +
                  "EXPEDIDO EN:" + "<br>" +
                  "CALLE ODONTOLOGÍA NO. 13 LOC. 1 COLONIA SPUAZ" + "<br>" +
                  "MEXICO, GPE. ZACATECAS" + "<br>" +
                  " " + "<br>" +
                  "Socio: " + numSocio + " " + nombreCompleto + " " + "<br>" +
                  "Fecha de revisión: " + DateTime.Now.ToShortDateString() + "" + "<br>" +
                  " " + "***** DATOS SOCIO  ****** " + "<br>" +
                  " " + "*" + "Altura: " + registro.altura + "<br>" +
                  " " + "*" + "Talla: " + registro.talla + "<br>" +
                  " " + "*" + "Grasa Corporal: " + registro.grasaCorporal + "<br>" +
                  "   " + "<br>" +
                  " " + "***** PESO  ****** " + "<br>" +
                  " " + "*" + "Inicial: " + registro.pesoInicial + "<br>" +
                  " " + "*" + "Bajado: " + registro.pesoBajado + "<br>" +
                  " " + "*" + "Actual: " + registro.pesoActual + "<br>" +
                  "   " + "<br>" +
                  " " + "***** CADERA ****** " + "<br>" +
                  " " + "*" + "Inicial: " + registro.circCaderaInicial + "<br>" +
                  " " + "*" + "Bajado: " + registro.circCaderaBajado + "<br>" +
                  " " + "*" + "Actual: " + registro.circCaderaActual + "<br>" +
                  "   " + "<br>" +
                  (complete ? lineComplete : "")
                  + " " + "***** OTROS  ****** " + "<br>" +
                  " " + "*" + "Guia: " + registro.guia + "<br>" +
                  " " + "*" + "Observaciones: " + registro.observaciones + "<br>" +
                  " " + "*" + "REGISTRADO POR: " + entrenador + "<br>" +
                  "   " + "<br>" +
                  " " + " " + "<br>" +
                  " " + "TU SALUD ES NUESTRA PASION..." + " " + "<br>" +
                 "VIVE LA EXPERIENCIA WELLNESS LAB EN FORMA" + " " + "<br>" +
                  "GRACIAS POR SU PREFERENCIA" + " ";
            return lines;
        }

        /// <summary>
        /// Cliente de configuracion de correo
        /// </summary>
        /// <returns></returns>
        public Boolean clienteCorreo()
        {
            try
            {

                //Creamos un objeto de cliente de correo
                cliente = new SmtpClient();
                //Hay que crear las credenciales del correo emisor
                cliente.Credentials = new NetworkCredential("wellnesslabenformamx@gmail.com", "&Odontologia13");
                /*
                * Cliente SMTP
                * Gmail:  smtp.gmail.com  puerto:587
                * Hotmail: smtp.liva.com  puerto:25
                */
                //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
                cliente.Port = 587;
                cliente.EnableSsl = true;
                //cliente.Port = 465
                cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";

                //Enviamos el mensaje      
                cliente.Send(mmsg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion funcionality
    }
}
