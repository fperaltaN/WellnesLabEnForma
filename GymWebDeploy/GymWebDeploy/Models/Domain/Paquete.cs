using System;
namespace GymWebDeploy.Models.Domain
{
    public class Paquete
    {
        public int id_paquete { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public int ID_USUARIO { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public int diaspaquetes { get; set; }
    }
}