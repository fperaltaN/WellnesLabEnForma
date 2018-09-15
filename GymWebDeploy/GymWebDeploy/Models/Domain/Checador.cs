using System;
namespace GymWebDeploy.Models.Domain
{
    public class Checador
    {
        public int id_entrada_salida { get; set; }
        public int id_empleado { get; set; }
        public DateTime? entrada { get; set; }
        public DateTime? fecha_registro { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modicacion {get;set;}
    }
}