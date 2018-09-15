using System;
namespace GymWebDeploy.Models.Domain
{
    public class Recargo
    {
        public int id_recargo { get; set; }
        public int id_socio { get; set; }
        public int id_paquete { get; set; }
        public DateTime? fecha_recargo { get; set; }
        public decimal importe { get; set; }
        public bool liberacion { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}