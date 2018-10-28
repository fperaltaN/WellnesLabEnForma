using System;

namespace GymWebDeploy.Models.Domain
{
    public class ReportePago
    {
        public int id_pago { get; set; }
        public int id_paquete { get; set; }
        public int id_socio { get; set; }
        public int ID_USUARIO { get; set; }
        public String nombre { get; set; }
        public String paquete { get; set; }
        public DateTime? fecha_pago { get; set; }
        public DateTime? fecha_pago_vence { get; set; }
        public int meses { get; set; }
        public String empleado { get; set; }
        public Decimal? importe { get; set; }
        public Decimal? pendiente { get; set; }
        public bool activo { get; set; }
    }
}