using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace Ej2.DAL.EntityFramework
{
    class AccountRepository : Repository<Account, AccountManagerDbContext>, IAccountRepository<Account>
    {
        public AccountRepository(AccountManagerDbContext pContext) : base(pContext) { }

        /// <summary>
        /// Devuelve todas las cuentas cuyo balance sea negativo y que hayan sobrepasado su limite de descubierto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetOverdrawnAccounts()
        {
            List<Account> mList = new List<Account>();
            foreach (Account mAccount in iDbContext.Accounts)
            {
                Double mBalance = GetAccountBalance(mAccount.Id);
                if (mBalance < 0 && Math.Abs(mBalance) > mAccount.OverdraftLimit)
                {
                    mList.Add(mAccount);
                }
            }
            return mList;
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

        /// <summary>
        /// Devuelve el balance de una Cuenta
        /// </summary>
        /// <param name="pAccountId"></param>
        /// <returns></returns>
        public double GetAccountBalance(int pAccountId)
        {
            double mBalance = 0;
            var query = "SELECT Amount FROM accountmovement WHERE(Account_Id = ?pAccountId)";
            MySqlConnection mConnection = new MySqlConnection("server = localhost; port = 3306; database = Tp6_Ej2.2; uid = root; password = 5kcwphcr");
            mConnection.Open();
            MySqlCommand mCommand = new MySqlCommand(query, mConnection);
            mCommand.Parameters.AddWithValue("?pAccountId", pAccountId);
            MySqlDataReader mReader = mCommand.ExecuteReader();
            
            mConnection.Close();
            return mBalance;
        }
    }
}
