using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    public class AccountDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double OverdraftLimit { get; set; }

        public double Balance { get; set; }
    }
}
