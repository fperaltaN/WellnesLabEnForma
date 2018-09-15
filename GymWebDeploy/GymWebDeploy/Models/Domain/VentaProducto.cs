using System;
namespace GymWebDeploy.Models.Domain
{
    public class VentaProducto
    {
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public decimal costo { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public int cantidad { get; set; }
    }
}