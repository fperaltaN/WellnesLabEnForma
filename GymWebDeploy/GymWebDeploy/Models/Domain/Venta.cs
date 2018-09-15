using System;
namespace GymWebDeploy.Models.Domain
{
    public class Venta
    {
        public int id_venta { get; set; }
        public int folio_diario { get; set; }
        public DateTime? fecha { get; set; }
        public decimal total { get; set; }
        public int ID_USUARIO { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}