using System;
namespace GymWebDeploy.Models.Domain
{
    public class PaqueteServicio
    {
        public int id_paquete { get; set; }
        public int id_servicio { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}