using System;
namespace GymWebDeploy.Models.Domain
{
    public class HistorialFisico
    {
        public int id_historial_fisico { get; set; }
        public int id_socio { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}