/*''=============================================
'' Autor:	Faleg A. Peralta
'' Modificado por: 
'' Fecha de Modificación: 06.10.2015
'' Descripcion General: Ticket socio
'' =============================================*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;
using GymWebDeploy.Models.Domain;

namespace GymWebDeploy.Models.Domain.Utils
{
    public class TicketSocioFile
    {
        String pathProgreso = "ticketPathProgreso";
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
            String lines = "WELLNESS LAB EN FORMA" + "" + Environment.NewLine+
                     "EXPEDIDO EN:"  + Environment.NewLine+
                     "CALLE ODONTOLOGÍA NO. 13"  + Environment.NewLine+
                     "LOC. 1 COLONIA SPUAZ" + Environment.NewLine +
                     "MEXICO, GPE. ZACATECAS" + Environment.NewLine+
                     " " + Environment.NewLine+
                     " " + "***** DATOS SOCIO  ****** " + Environment.NewLine +
                     "Socio: " + numSocio + " " + nombreCompleto + " " + Environment.NewLine+
                     "Fecha de revisión: " + DateTime.Now.ToShortDateString() + "" + Environment.NewLine+
                     "   " + Environment.NewLine +
                     " " + "***** INICIALES  ****** " + Environment.NewLine+
                     " " + "*" + "Trigliceridos: " + registro.trigliceridos + Environment.NewLine+
                     " " + "*" + "Colesterol: " + registro.Colesterol + Environment.NewLine+
                     " " + "*" + "Glucosa: " + registro.Glucosa + Environment.NewLine+
                     "   " + Environment.NewLine+
                     " " + "***** PLIEGUES  ****** " + Environment.NewLine+
                     " " + "*" + "Tricipal: " + registro.pliegueTricipal + Environment.NewLine+
                     " " + "*" + "Escapular: " + registro.pliegueEscapular + Environment.NewLine+
                     "   " + Environment.NewLine+
                     " " + "***** Presión  ****** " + Environment.NewLine+
                     " " + "*" + "Cardiaca: " + registro.frecuenciaCardiaca + Environment.NewLine+
                     " " + "*" + "Arterial Sisfolica: " + registro.frecuanciArtSisfolica + Environment.NewLine+
                     " " + "*" + "Arterial Diasfolica: " + registro.frecuanciArtDiasfolica + Environment.NewLine+
                     "   " + Environment.NewLine+
                     (complete ? lineComplete : "") +
                     "   " + Environment.NewLine +
                     " " + "***** REGISTRADO POR  ****** " + Environment.NewLine +
                     "ENTRENADOR: " + entrenador + Environment.NewLine +
                     "   " + Environment.NewLine +
                     " " + "TU SALUD ES NUESTRA PASION..." + " " + Environment.NewLine+
                    "VIVE LA EXPERIENCIA WELLNESS LAB EN FORMA" + " " + Environment.NewLine+
                     "GRACIAS POR SU PREFERENCIA" + " ";

            return saveTicket(lines.ToString(), @"\Ticket_Progreso_Registro_"+  (complete ? "_Completo_":"_Parcial_")+ numSocio + "_Socio_ " + nombreCompleto + "_" + DateTime.Now.ToLongDateString() + ".txt");
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
            String lineComplete = " " + "***** PECHO ****** " + Environment.NewLine+
                          " " + "*" + "Inicial: " + registro.circPechoInicial + Environment.NewLine+
                          " " + "*" + "Bajado: " + registro.circPechoBajado + Environment.NewLine+
                          " " + "*" + "Actual: " + registro.circPechoActual + Environment.NewLine+
                          "   " + Environment.NewLine+
                          " " + "***** FRECUENCIA CARDIACA / %  ****** " + Environment.NewLine+
                          " " + "*" + "Maxima: " + registro.frecCardicaMaxima + Environment.NewLine+
                          " " + "*" + "Reposo: " + registro.frecCardicaReposo + Environment.NewLine+
                          " " + "*" + "% Entrenamieto: " + registro.porceEntrenamiento + Environment.NewLine+
                          "   " + Environment.NewLine+
                          " " + "***** IMC / P.I.E  ****** " + Environment.NewLine+
                          " " + "*" + "IMC: " + registro.imc + Environment.NewLine+
                          " " + "*" + "P.I.E: " + registro.pie + Environment.NewLine+
                          "   " + Environment.NewLine ;
            String lines = "WELLNESS LAB EN FORMA" + Environment.NewLine+
                  "EXPEDIDO EN:" + Environment.NewLine+
                  "CALLE ODONTOLOGÍA NO. 13 LOC. 1 COLONIA SPUAZ" + Environment.NewLine+
                  "MEXICO, GPE. ZACATECAS" + Environment.NewLine+
                  " " + Environment.NewLine+
                  " " + "***** DATOS SOCIO  ****** " + Environment.NewLine +                   
                  "Socio: " + numSocio + " " + nombreCompleto + " " + Environment.NewLine+
                  "Fecha de revisión: " + DateTime.Now.ToShortDateString() + "" + Environment.NewLine+
                  "EDAD: " + registro.edad + " TALLA: " + registro.talla + " " + Environment.NewLine +
                  "   " + Environment.NewLine +
                  " " + "***** DATOS SOCIO  ****** " + Environment.NewLine+
                  " " + "*" + "Altura: " + registro.altura + Environment.NewLine+
                  " " + "*" + "Talla: " + registro.talla + Environment.NewLine+
                  " " + "*" + "Grasa Corporal: " + registro.grasaCorporal + Environment.NewLine+
                  "   " + Environment.NewLine+
                  " " + "***** PESO  ****** " + Environment.NewLine+
                  " " + "*" + "Inicial: " + registro.pesoInicial + Environment.NewLine+
                  " " + "*" + "Bajado: " + registro.pesoBajado + Environment.NewLine+
                  " " + "*" + "Actual: " + registro.pesoActual + Environment.NewLine+
                  "   " + Environment.NewLine+
                  " " + "***** CADERA ****** " + Environment.NewLine+
                  " " + "*" + "Inicial: " + registro.circCaderaInicial + Environment.NewLine+
                  " " + "*" + "Bajado: " + registro.circCaderaBajado + Environment.NewLine+
                  " " + "*" + "Actual: " + registro.circCaderaActual + Environment.NewLine+
                  "   " + Environment.NewLine+
                  (complete ? lineComplete : "")
                  + " " + "***** OTROS  ****** " + Environment.NewLine+
                  " " + "*" + "Guia: " + registro.guia + Environment.NewLine+
                  " " + "*" + "Observaciones: " + registro.observaciones + Environment.NewLine+
                  " " + "***** REGISTRADO POR  ****** " + Environment.NewLine +
                  "   " + Environment.NewLine +
                  "ENTRENADOR: " + entrenador + Environment.NewLine +
                  " " + " " + Environment.NewLine+
                  " " + "TU SALUD ES NUESTRA PASION..." + " " + Environment.NewLine+
                 "VIVE LA EXPERIENCIA WELLNESS LAB EN FORMA" + " " + Environment.NewLine+
                  "GRACIAS POR SU PREFERENCIA" + " ";
            return saveTicket(lines, @"\Ticket_Progreso_Custom_" + (complete ? "_Completo_" : "_Parcial_") + numSocio + "_Socio_ " + nombreCompleto + "_" + DateTime.Now.ToLongDateString() + ".txt");
        }
        public Boolean saveTicket(String lines, String nameFile)
        {
            try
            {
                // Set a variable to the My Documents path.
                string mydocpath = ConfigurationManager.ConnectionStrings[pathProgreso].ConnectionString;
                //Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(mydocpath + nameFile))
                {
                    outputFile.WriteLine(lines);
                }
                Console.WriteLine(mydocpath + nameFile);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error:" + ex);
                return false;

            }
        }
    }
}