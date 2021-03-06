﻿using System;
namespace GymWebDeploy.Models.Domain
{
    public class SocioMembresia
    {
        public int id_socio_membresia { get; set; }
        public int id_socio { get; set; }
        public int id_paquete { get; set; }
        public int num_socio { get; set; }
        public String nombre { get; set; }
        public String paquete { get; set; }
        public String descripcion { get; set; }
        public DateTime? fecha_vinculacion { get; set; }
        public DateTime? fecha_renovacion { get; set; }
        public DateTime? fecha_expiracion { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}