using System;
namespace GymWebDeploy.Models.Domain
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public int existencia { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public string clave { get; set; }
    }
}