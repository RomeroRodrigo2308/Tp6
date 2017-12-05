using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AgendaContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public DbSet<Telefono> Telefonos { get; set; }

        public AgendaContext():base("MyContext")
        {

        }
    }
}
