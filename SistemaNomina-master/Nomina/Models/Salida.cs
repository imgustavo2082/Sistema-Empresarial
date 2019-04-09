using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Nomina.Models
{
    public class Salida
    {
        public int id { get; set; }
        public string empleado { get; set; }
        public Empleados empleados { get; set; }
        [DisplayName("Tipo de salida")]
        public tipo_inactivo tipo { get; set; }
        [Required]
        public string motivo { get; set; }
        [Required]
        [DisplayName("Fecha de salida")]
        public DateTime fechaSalida { get; set; }

        public enum tipo_inactivo
        {
            Renuncia,
            Despido,
            Desahucio
        }
    }
}