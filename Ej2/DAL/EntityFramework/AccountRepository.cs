using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;
using Ej2.DAL.Comparer;

namespace Ej2.DAL.EntityFramework
{
    class AccountRepository : Repository<Account, AccountManagerDbContext>, IAccountRepository<Account>
    {
        public AccountRepository(AccountManagerDbContext pContext) : base(pContext) { }

        /// <summary>
        /// Devuelve todas las cuentas cuyo balance sea negativo y que hayan sobrepasado su limite de descubierto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountDTO> GetOverdrawnAccounts()
        {
            List<AccountDTO> mListDTO = new List<AccountDTO>();
            var query = from p in iDbContext.Accounts
                        select p;
            List<Account> mList = query.ToList();
            foreach (Account mAccount in mList)
            {
                double mBalance = GetAccountBalance(mAccount.Id);
                if (mBalance < 0 && Math.Abs(mBalance) > mAccount.OverdraftLimit)
                {
                    mListDTO.Add(new AccountDTO
                    {
                        Balance = mBalance,
                        Id = mAccount.Id,
                        Name = mAccount.Name,
                        OverdraftLimit = mAccount.OverdraftLimit,
                    });
                }
            }
            return mListDTO;
        }

        /// <summary>
        /// Devuelve todas las cuentas de un Cliente
        /// </summary>
        /// <param name="pClientId"></param>
        /// <returns></returns>
        public IEnumerable<Account> GetClientAccounts(int pClientId)
        {
            var query = from p in iDbContext.Accounts
                        where p.Client.Id == pClientId
                        select p;
            return query.ToList();
        }

        public IList<AccountMovement> ObtenerMovimientosDeUnaCuenta(int pAccountId)
        {
            var query = from p in iDbContext.Set<AccountMovement>()
                        where p.Account.Id == pAccountId
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// Devuelve el balance de una Cuenta
        /// </summary>
        /// <param name="pAccountId"></param>
        /// <returns></returns>
        public double GetAccountBalance(int pAccountId)
        {
            List<AccountMovement> mList = (List<AccountMovement>)ObtenerMovimientosDeUnaCuenta(pAccountId);
            return mList.Sum(p => p.Amount);
        }

        public IList<AccountMovementDTO> GetAccountMovements(int pAccountId)
        {
            List<AccountMovementDTO> mListDTO = new List<AccountMovementDTO>();
            List<AccountMovement> mList = (List<AccountMovement>)ObtenerMovimientosDeUnaCuenta(pAccountId);
            mList.Sort(new ComparerDate<AccountMovement>());
            foreach (AccountMovement pMovement in mList)
            {
                mListDTO.Add(new AccountMovementDTO
                {
                    Id = pMovement.Id,
                    Date = pMovement.Date,
                    Amount = pMovement.Amount,
                    Description = pMovement.Description
                });
            }
            return mListDTO;
        }
    }
}
