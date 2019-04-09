using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomina.Models
{
    public class Calculos
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public String año { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public String mes { get; set; }

        public Double total { get; set; }
    }
}