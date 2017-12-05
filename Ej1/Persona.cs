using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Apellido { get; set; }

        public virtual IList<Telefono> Telefonos { get; set; }
    }
}
