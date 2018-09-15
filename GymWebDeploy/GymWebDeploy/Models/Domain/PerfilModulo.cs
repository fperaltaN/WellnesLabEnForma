using System;
namespace GymWebDeploy.Models.Domain
{
    public class PerfilModulo
    {
        public int ID_REL { get; set; }
        public int ID_PERFIL { get; set; }
        public int ID_MODULO { get; set; }
        public bool CONTROL_TOTAL { get; set; }
        public bool ACTIVO { get; set; }
        public DateTime? CREADO { get; set; }
        public string CREADOPOR { get; set; }
        public DateTime? ACTUALIZADO { get; set; }
        public string ACTUALIZADOPOR { get; set; }
    }
}