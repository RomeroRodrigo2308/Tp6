using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    interface IAccountRepository<Account> : IRepository<Account>
    {
        IEnumerable<Account> GetOverdrawnAccounts();

        IEnumerable<Account> GetClientAccounts(int pClientId);

        double GetAccountBalance(int pAccountId);
    }
}
