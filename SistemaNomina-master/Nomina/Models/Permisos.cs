using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Nomina.Models
{
    public class Permisos
    {
        public int id { get; set; }
        public String idEmpleado { get; set; }
        public Empleados empleados { get; set; }
        [Required]
        [DisplayName("Fecha de inicio")]
        public String fecha_inicio { get; set; }
        [Required]
        [DisplayName("Fecha de fin")]
        public String fecha_final { get; set; }
        public String comentarios { get; set; }
    }
}