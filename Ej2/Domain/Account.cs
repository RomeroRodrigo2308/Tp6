using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    [Table("Account")]
    class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        public double OverdraftLimit { get; set; }

        [Required]
        public Client Client { get; set; }

        public virtual IList<AccountMovement> Movements { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Account()
        {
            Movements = new List<AccountMovement>();
        }
    }
}