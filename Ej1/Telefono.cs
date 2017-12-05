using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ej1
{
    [Table("Telefono")]
    public class Telefono
    {
        [Key]
        public int TelefonoId { get; set; }

        [Required]
        [StringLength(20)]
        public string Numero { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; }
    }
}