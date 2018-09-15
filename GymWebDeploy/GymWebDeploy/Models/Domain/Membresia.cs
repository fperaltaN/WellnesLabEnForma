using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class Membresia
    {
        public int id_membresia { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; } 
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}