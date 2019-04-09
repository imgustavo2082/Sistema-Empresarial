using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Nomina.Models
{
    public class Nominacontext : DbContext
    {
        public Nominacontext()
            :base("Nomina")
        {
        }

        public DbSet<Empleados> empleados { get; set; }
        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Cargos> cargos { get; set; }
        public DbSet<Calculos> calculos { get; set; }
        public DbSet<Vacaciones> vacaciones { get; set; }
        public DbSet<Licencias> licencias { get; set; }
        public DbSet<Permisos> permisos { get; set; }
        public DbSet<Salida> salida { get; set; }
    }
}