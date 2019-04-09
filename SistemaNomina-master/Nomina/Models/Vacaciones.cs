using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomina.Models
{
    public class Vacaciones
    {
        public int id { get; set; }

        public string idEmpleado { get; set; }
        public Empleados empleados { get; set; }
        

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Fecha de inicio")]
        public String fecha_inicio { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayName("Fecha de fin")]
        public String fecha_final { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public String año { get; set; }
        public String comentarios { get; set; }

    }
}