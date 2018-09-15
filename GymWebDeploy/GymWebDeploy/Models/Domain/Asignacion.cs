using System;
namespace GymWebDeploy.Models.Domain
{
    public class Asignacion
    {
        public int id_asignacion { get; set; }
        public int id_socio { get; set; }
        public int id_paquete { get; set; }
        public DateTime? fecha_asignacion { get; set; }
        public DateTime? fecha_vigencia { get; set; }
        public bool activo { get; set; }
        public DateTime fecha_modificacion{ get; set; }
        public DateTime? fecha_cancelacion { get; set; }
    }
}