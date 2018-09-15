using System;
namespace GymWebDeploy.Models.Domain
{
    public class RegistroVisita
    {
        public int id_vigencia { get; set; }
        public int id_socio { get; set; }
        public int dias_vigentes { get; set; }
        public DateTime? fecha_entrada { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}