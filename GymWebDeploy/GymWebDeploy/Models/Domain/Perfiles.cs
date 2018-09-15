using System;
namespace GymWebDeploy.Models.Domain
{
    public class Perfiles
    {
        public int ID_PERFIL { get; set; }
        public string PERFIL { get; set; }
        public bool ACTIVO { get; set; }
        public DateTime? CREADO { get; set; }
        public string CREADOPOR { get; set; }
        public DateTime? ACTUALIZADO { get; set; }
        public string ACTUALIZADOPOR { get; set; }
    }
}