using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Sql;

namespace Nomina.Models
{
    public class Empleados
    {
        public List<Empleados> empleados;
        public int id { get; set; }
        [Required (ErrorMessage ="Debe introducir el codigo del empleado")]
        public String codigo { get; set; }
        [Required]
        public String nombre { get; set; }
        [Required]
        public String apellido { get; set; }
        [Required]
        public String telefono { get; set; }
        public String departamento { get; set; }
        public Departamentos departamentos { get; set; }
        public String cargo { get; set; }
        public Cargos cargos { get; set; }
        [Required]
        [DisplayName("Fecha de entrada")]
        public DateTime fechaentrada { get; set; }
        [Required]
        public Double salario { get; set; }
        [Required]
        public String estado { get; set; }
    }
}