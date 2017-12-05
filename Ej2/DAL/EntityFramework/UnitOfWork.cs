using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2.DAL.EntityFramework
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext iDbContext;

        public IAccountRepository<Account> AccountRepository { get; set; }

        public IClientRepository<Client> ClientRepository { get; set; }

        public UnitOfWork(AccountManagerDbContext pContext)
        {
            iDbContext = pContext;
            AccountRepository = new AccountRepository(pContext);
            ClientRepository = new ClientRepository(pContext);
        }

        public DbContext DbContext { get; }

        public void Complete()
        {
            iDbContext.SaveChanges();
        }

        public void Dispose()
        {
            iDbContext.Dispose();
        }
    }
}
