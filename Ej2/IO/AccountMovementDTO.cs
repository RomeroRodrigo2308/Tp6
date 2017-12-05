using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    public class AccountMovementDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }
    }
}
