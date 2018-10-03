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
        public int num_socio { get; set; }
        public string nombre_Completo { get; set; }
        public string problema_Cardiaco { get; set; }
        public string dolor_Pecho { get; set; }
        public string asma { get; set; }
        public string presion_Alta { get; set; }
        public string medicamento { get; set; }
        public string neurologicos { get; set; }
        public string riesgo_Cardiovascular { get; set; }
        public string dolencias { get; set; }
        public string enfermedad { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}