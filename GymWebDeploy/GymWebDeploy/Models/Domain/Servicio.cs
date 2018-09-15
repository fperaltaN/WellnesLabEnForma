using System;
namespace GymWebDeploy.Models.Domain
{
    public class Servicio
    {
        public int id_servicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}