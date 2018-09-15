using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class HistorialMedico
    {
        public int id_historial_medico { get; set; }
        public int id_socio { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}