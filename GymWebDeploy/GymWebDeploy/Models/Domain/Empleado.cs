using System;
namespace GymWebDeploy.Models.Domain
{
    public class Empleado
    {
        public int id_empleado { get; set; }
        public int num_empleado { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string direccion { get; set; }
        public DateTime? fecha_registro { get; set; }
        public DateTime? fecha_baja { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public int id_perfil { get; set; }
        public string telefono { get; set; }
    }
}