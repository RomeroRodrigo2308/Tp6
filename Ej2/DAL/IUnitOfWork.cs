using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    interface IUnitOfWork : IDisposable
    {
        IAccountRepository<Account> AccountRepository { get; set; }

        IClientRepository<Client> ClientRepository { get; set; }

        void Complete();
    }
}
