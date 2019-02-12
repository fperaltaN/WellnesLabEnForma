using System;
namespace GymWebDeploy.Models.Domain
{
    public class Usuarios
    {
        public int ID_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PAT { get; set; }
        public string APELLIDO_MAT { get; set; }
        public int ID_AREA { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public int ID_PERFIL { get; set; }
        public string PERFIL { get; set; }
        public bool ACTIVO { get; set; }
        public DateTime? CREADO { get; set; }
        public string CREADOPOR { get; set; }
        public DateTime? ACTUALIZADO { get; set; }
        public string ACTUALIZADOPOR { get; set; }
    }
}