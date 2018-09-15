using System;
namespace GymWebDeploy.Models.Domain
{
    public class PagoRecargo
    {
        public int id_pago_recargo { get; set; }
        public int id_pago { get; set; }
        public int id_recargo { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}