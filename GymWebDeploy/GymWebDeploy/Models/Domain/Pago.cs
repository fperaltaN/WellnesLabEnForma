using System;
namespace GymWebDeploy.Models.Domain
{
    public class Pago
    {
        public int id_pago { get; set; }
        public int id_paquete { get; set; }
        public int id_socio { get; set; }
        public int ID_USUARIO { get; set; }
        public string refTicketVenta { get; set; }
        public decimal? importe { get; set; }
        public DateTime? fecha_pago { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public DateTime? fecha_pago_vence { get; set; }
        public decimal? pendiente { get; set; }
    }
}