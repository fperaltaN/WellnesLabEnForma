using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iText;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Source;
using iText.IO.Image;
using System.Configuration;
using GymWebDeploy.Models.Domain;
using iText.Kernel.Pdf.Action;
using System.Diagnostics;

namespace GymWebDeploy.Models.Domain.Utils
{
    public class PDFTicket
    {
        static String path = "ticketPath";
        public String DEST = ConfigurationManager.AppSettings[path].ToString();
        //public String IMAGEPATH = System.Web.HttpContext.Current.Server.MapPath("LogoOficial.JPG");
        public String IMAGEPATH = "c:/LogoOficial.jpg";
        //System.Web.Hosting.HostingEnvironment.MapPath(path);

        /// <summary>
        /// Generamos el PDF
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public Boolean CreatePdf(String lines, String Nombre, Boolean newPage)
        {
            try
            {
                // Creating a PdfWriter
                PdfWriter writer = new PdfWriter(DEST + Nombre);
                // Creating a PdfDocument
                PdfDocument pdfDoc = new PdfDocument(writer);
                // Adding an empty page
                pdfDoc.AddNewPage();
                //Creating the Image
                Image image = new Image(ImageDataFactory.Create(IMAGEPATH.Replace("DataTicket\\", "")));
                image.ScaleAbsolute(159f, 109f);
                // Creating an Area Break
                Paragraph para = new Paragraph(lines).SetFontSize(10);
                // Creating a Document
                Document document = new Document(pdfDoc, PageSize.LETTER);
                // Adding Image  to the PDF
                document.Add(image);
                // Adding area break to the PDF
                document.Add(para);                
                // Closing the document
                document.Close();
                //Open Document
                 Process.Start(DEST + Nombre);
                //Print
                printPDF(DEST + Nombre);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
        public Boolean printTicketClientRecord(bool complete, String numSocio, String nombreCompleto, String entrenador, RecordTicket registro)
        {
            String lineComplete = " " + "***** PORCENTAJE CARGA  ****** " + Environment.NewLine +
                     " " + "*" + "Pecho: " + registro.porcentajeCargaPecho + Environment.NewLine +
                     " " + "*" + "Pierna: " + registro.porcentajeCargaPierna + Environment.NewLine +
                     "   " + Environment.NewLine +
                     " " + "***** METABOLISMO  ****** " + Environment.NewLine +
                     " " + "*" + "Basal: " + registro.metabolismoBasal +
                    "   " + Environment.NewLine;
            String lines = /*"WELLNESS LAB EN FORMA" + "" + Environment.NewLine +
                     "EXPEDIDO EN:" + Environment.NewLine +*/
                     "CALLE ODONTOLOGÍA NO. 13 LOC. 1 FRACCIONAMIENTO SPUAZ" + Environment.NewLine +
                      "MEXICO, GPE. ZACATECAS" + Environment.NewLine +
                      "TEL: 492-228-5758" + Environment.NewLine +
                      "CORREO: wellnesslabenformamx@gmail.com " + Environment.NewLine +
                     // "FACEBOOK: https://www.facebook.com/pages/Wellness-Lab-en-Forma/ " + Environment.NewLine +
                      " " + Environment.NewLine +
                     " " + "***** DATOS SOCIO  ****** " + Environment.NewLine +
                     "Socio: " + numSocio + " " + nombreCompleto + " " + Environment.NewLine +
                     "Fecha de revisión: " + DateTime.Now.ToShortDateString() + "" + Environment.NewLine +
                     "   " + Environment.NewLine +
                     " " + "***** INICIALES  ****** " + Environment.NewLine +
                     " " + "*" + "Trigliceridos: " + registro.trigliceridos + Environment.NewLine +
                     " " + "*" + "Colesterol: " + registro.Colesterol + Environment.NewLine +
                     " " + "*" + "Glucosa: " + registro.Glucosa + Environment.NewLine +
                     "   " + Environment.NewLine +
                     " " + "***** PLIEGUES  ****** " + Environment.NewLine +
                     " " + "*" + "Tricipal: " + registro.pliegueTricipal + Environment.NewLine +
                     " " + "*" + "Escapular: " + registro.pliegueEscapular + Environment.NewLine +
                     "   " + Environment.NewLine +
                     " " + "***** Presión  ****** " + Environment.NewLine +
                     " " + "*" + "Cardiaca: " + registro.frecuenciaCardiaca + Environment.NewLine +
                     " " + "*" + "Arterial Sisfolica: " + registro.frecuanciArtSisfolica + Environment.NewLine +
                     " " + "*" + "Arterial Diasfolica: " + registro.frecuanciArtDiasfolica + Environment.NewLine +
                     "   " + Environment.NewLine +
                     (complete ? lineComplete : "") +
                     "   " + Environment.NewLine +
                     " " + "***** REGISTRADO POR  ****** " + Environment.NewLine +
                     "ENTRENADOR: " + entrenador + Environment.NewLine +
                     "   " + Environment.NewLine +
                     " " + "TU SALUD ES NUESTRA PASION..." + " " + Environment.NewLine +
                    "VIVE LA EXPERIENCIA WELLNESS LAB EN FORMA" + " " + Environment.NewLine +
                     "GRACIAS POR SU PREFERENCIA" + " ";

            return CreatePdf(lines, @"\Ticket_Progreso_Custom_" + (complete ? "_Completo_" : "_Parcial_") + numSocio + "_Socio_ " + nombreCompleto + "_" + DateTime.Now.ToLongDateString() + ".pdf", complete);
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
        public Boolean printTicketCustom(bool complete, String numSocio, String nombreCompleto, String entrenador, Record registro)
        {
            String lineComplete = " " + "***** PECHO ****** " + Environment.NewLine +
                          " " + "*" + "Inicial: " + registro.circPechoInicial + Environment.NewLine +
                          " " + "*" + "Bajado: " + registro.circPechoBajado + Environment.NewLine +
                          " " + "*" + "Actual: " + registro.circPechoActual + Environment.NewLine +
                          "   " + Environment.NewLine +
                          " " + "***** FRECUENCIA CARDIACA / %  ****** " + Environment.NewLine +
                          " " + "*" + "Maxima: " + registro.frecCardicaMaxima + Environment.NewLine +
                          " " + "*" + "Reposo: " + registro.frecCardicaReposo + Environment.NewLine +
                          " " + "*" + "% Entrenamieto: " + registro.porceEntrenamiento + Environment.NewLine +
                          "   " + Environment.NewLine +
                          " " + "***** IMC / P.I.E  ****** " + Environment.NewLine +
                          " " + "*" + "IMC: " + registro.imc + Environment.NewLine +
                          " " + "*" + "P.I.E: " + registro.pie + Environment.NewLine +
                          "   " + Environment.NewLine;
            String lines = /*"WELLNESS LAB EN FORMA" + Environment.NewLine +
                  "EXPEDIDO EN:" + Environment.NewLine +*/
                  "CALLE ODONTOLOGÍA NO. 13 LOC. 1 FRACCIONAMIENTO SPUAZ" + Environment.NewLine +
                  "MEXICO, GPE. ZACATECAS" + Environment.NewLine +
                  "TEL: 492-228-5758" + Environment.NewLine +
                  "CORREO: wellnesslabenformamx@gmail.com " + Environment.NewLine +
                  //"FACEBOOK: https://www.facebook.com/pages/Wellness-Lab-en-Forma/ " + Environment.NewLine +
                  " " + Environment.NewLine +
                  " " + "***** DATOS SOCIO  ****** " + Environment.NewLine +
                  "Socio: " + numSocio + " " + nombreCompleto + " " + Environment.NewLine +
                  "Fecha de revisión: " + DateTime.Now.ToShortDateString() + "" + Environment.NewLine +
                  "EDAD: " + registro.edad + " TALLA: " + registro.talla + " " + Environment.NewLine +
                  "ALTURA: " + registro.altura + " GRASA CORPORAL: " + registro.grasaCorporal + " " + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "***** PESO  ****** " + Environment.NewLine +
                  " " + "*" + "Inicial: " + registro.pesoInicial + Environment.NewLine +
                  " " + "*" + "Bajado: " + registro.pesoBajado + Environment.NewLine +
                  " " + "*" + "Actual: " + registro.pesoActual + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "***** CADERA ****** " + Environment.NewLine +
                  " " + "*" + "Inicial: " + registro.circCaderaInicial + Environment.NewLine +
                  " " + "*" + "Bajado: " + registro.circCaderaBajado + Environment.NewLine +
                  " " + "*" + "Actual: " + registro.circCaderaActual + Environment.NewLine +
                  "   " + Environment.NewLine +
                  (complete ? lineComplete : "")
                  + " " + "***** OTROS  ****** " + Environment.NewLine +
                  " " + "*" + "Guia: " + registro.guia + Environment.NewLine +
                  " " + "*" + "Observaciones: " + registro.observaciones + Environment.NewLine +
                  " " + "***** REGISTRADO POR  ****** " + Environment.NewLine +
                  "ENTRENADOR: " + entrenador + Environment.NewLine +
                  " " + " " + Environment.NewLine +
                  " " + "TU SALUD ES NUESTRA PASION..." + " " + Environment.NewLine +
                 "VIVE LA EXPERIENCIA WELLNESS LAB EN FORMA" + " " + Environment.NewLine +
                  "GRACIAS POR SU PREFERENCIA" + " ";
            return CreatePdf(lines, @"\Ticket_Progreso_Custom_" + (complete ? "_Completo_" : "_Parcial_") + numSocio + "_Socio_ " + nombreCompleto + "_" + DateTime.Now.ToLongDateString() + ".pdf", complete);
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
        public Boolean printTicketPayment(String numSocio, String nombreCompleto, String entrenador, String paquete, Pago registro)
        {
            String lines = /*"WELLNESS LAB EN FORMA" + Environment.NewLine +
                  "EXPEDIDO EN:" + Environment.NewLine +*/
                  "CALLE ODONTOLOGÍA NO. 13 " + Environment.NewLine + 
                  "FRACCIONAMIENTO SPUAZ" + Environment.NewLine +
                  "MEXICO, GPE. ZACATECAS" + Environment.NewLine +
                  "TEL: 492-228-5758" + Environment.NewLine +
                  "CORREO: wellnesslabenformamx@gmail.com " + Environment.NewLine +
                  //"FACEBOOK: facebook.com/Wellness-Lab-en-Forma " + Environment.NewLine +
                  " " + Environment.NewLine +
                  " " + "***** DATOS SOCIO  ****** " + Environment.NewLine +
                  "Socio: " + numSocio + " " + nombreCompleto + " " + Environment.NewLine +
                  "Fecha de emisión: " + DateTime.Now.ToShortDateString() + "" + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "***** DATOS DEL PAQUETE  ****** " + Environment.NewLine +
                  " " + "*" + "Paquete: " + paquete + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "***** DATOS DEL PAGO  ****** " + Environment.NewLine +
                  " " + "*" + "Fecha de Inicio : " + DateTime.Now.ToShortDateString() + Environment.NewLine +
                  " " + "*" + "Fecha de Vencimiento: " + registro.fecha_pago_vence.ToString().Substring(0, 10) + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "*" + "SUBTOTAL: " + registro.importe + Environment.NewLine +
                  " " + "*" + "IVA : " + 0 + Environment.NewLine +
                  " " + "*" + "TOTAL : " + registro.importe + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "*" + "RECIBIDO : " + registro.importe + Environment.NewLine +
                  " " + "*" + "PENDIENTE : " + registro.pendiente + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "***** REGISTRADO POR  ****** " + Environment.NewLine +
                  entrenador + Environment.NewLine +
                  " " + " " + Environment.NewLine +
                  " " + "TU SALUD ES NUESTRA PASION..." + " " + Environment.NewLine +
                 "VIVE LA EXPERIENCIA WELLNESS LAB EN FORMA" + " " + Environment.NewLine +
                  "GRACIAS POR SU PREFERENCIA!!!";
            return CreatePdf(lines, @"\Ticket_Venta__" + registro.id_pago + numSocio + "_Socio_ " + nombreCompleto + "_" + DateTime.Now.ToLongDateString() + ".pdf", true);
        }
        /// <summary>
        /// 
        /// </summary>
        public void printPDF(String pdfPath)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = pdfPath //put the correct path here
            };
            p.Start();
        }
    }
}