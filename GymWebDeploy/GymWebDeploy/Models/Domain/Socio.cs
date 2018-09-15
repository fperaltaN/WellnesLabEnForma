using System;
namespace GymWebDeploy.Models.Domain
{
    public class Socio
    {
        public int id_socio { get; set; }
        public int num_socio { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string direccion { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_baja { get; set; }
        public bool activo { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string compEstudios { get; set; }
        public string mail { get; set; }
    }
}