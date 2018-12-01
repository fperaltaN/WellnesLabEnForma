using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;

namespace GymWebDeploy.Models.Domain
{
    public class Login
    {
        [Required]
        [Display(Name = "Usuario requerido")]
        public string user { get; set; }

        [Required]
        [Display(Name = "Contraseña requerida")]
        public string pass { get; set; }
    }

    public class LoginStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TargetURL { get; set; }
    }
}