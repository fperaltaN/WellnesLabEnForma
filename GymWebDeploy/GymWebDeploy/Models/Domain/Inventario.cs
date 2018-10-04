using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class Inventario
    {
        public int id_inventario { get; set; }
        public int id_cat_inventario { get; set; }
        public int num_control { get; set; }
        public int id_socio { get; set; }
    }
}