using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class ReporteChecadorSocio
    {
        public int id_socio { get; set; }
        public int num_socio { get; set; }
        public string nombre { get; set; }
        public DateTime? entrada { get; set; }
        public DateTime? salida { get; set; }
    }
}