using System;
namespace GymWebDeploy.Models.Domain
{
    public class HistorialFisico
    {
        public int id_historial_fisico { get; set; }
        public int id_socio { get; set; }
        public string descripcion { get; set; }
        public int num_socio { get; set; }
        public string nombre_Completo { get; set; }
        public string actividad_Fisica { get; set; }
        public string tiempo_Actividad_Fisica { get; set; }
        public string tipo_Actividad_Fisica { get; set; }
        public string fuma { get; set; }
        public string toma { get; set; }
        public string lesiones { get; set; }
        public string fatigado_ejercicio { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}