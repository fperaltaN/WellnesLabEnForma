using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class CatalogoInventario
    {
        public int Id_cat_inventario { get; set; }
        public bool activo { get; set; }
        public string nombre { get; set; }
    }
}