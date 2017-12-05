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
        /// Devuelve el balance de la cuenta
        /// </summary>
        /// <returns></returns>
        public double GetBalance()
        {
            return Movements.Sum(pMovement => pMovement.Amount);
        }

        /// <summary>
        /// Devuelve todos los movimientos de la cuenta
        /// </summary>
        /// <param name="pCount"></param>
        /// <returns></returns>
        public IEnumerable<AccountMovement> GetAccountMovements(int pCount)
        {
            return Movements.OrderBy(pMovement => pMovement.Date).Take(pCount);
        }
    }
}