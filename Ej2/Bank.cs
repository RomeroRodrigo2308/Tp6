using Ej2.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    /// <summary>
    /// Controlador de Fachada del Banco
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Devuelve las Cuentas cuyo balance es negativo y hayan sobrepasado su Limite de Descubierto
        /// </summary>
        /// <param name="pClientId"></param>
        /// <returns></returns>
        public IEnumerable<AccountDTO> GetClientAccounts(int pClientId)
        {
            List<AccountDTO> mAccountsDTO = new List<AccountDTO>();
            using (UnitOfWork mUnit = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<Account> mAccounts = (List<Account>)mUnit.AccountRepository.GetClientAccounts(pClientId);
                foreach (Account mAccount in mAccounts)
                {
                    mAccountsDTO.Add(new AccountDTO
                    {
                        Balance = mUnit.AccountRepository.GetAccountBalance(mAccount.Id),
                        Id = mAccount.Id,
                        Name = mAccount.Name,
                        OverdraftLimit = mAccount.OverdraftLimit,
                    });
                    mUnit.Complete();
                }
                return mAccountsDTO;
            }
        }

        /// <summary>
        /// Devuelve N los movimientos de la Cuenta
        /// </summary>
        /// <param name="pAccountId"></param>
        /// <returns></returns>
        public IEnumerable<AccountMovementDTO> GetAccountMovements(int pAccountId, int pCantidad)
        {
            List<AccountMovementDTO> mMovements = new List<AccountMovementDTO>();
            using (UnitOfWork mUnit = new UnitOfWork(new AccountManagerDbContext()))
            {
                Account mAccount = mUnit.AccountRepository.Get(pAccountId);
                foreach (AccountMovement mMovement in mAccount.GetAccountMovements(pCantidad)) //Cambiar
                {
                    mMovements.Add(new AccountMovementDTO
                    {
                        Amount = mMovement.Amount,
                        Date = mMovement.Date,
                        Description = mMovement.Description,
                        Id = mMovement.Id
                    });
                }
                mUnit.Complete();
            }
            return mMovements;
        }
        /// <summary>
        /// Crea un nuevo cliente con los siguientes parametros
        /// </summary>
        /// <param name="pFirstName"></param>
        /// <param name="pLastName"></param>
        /// <param name="pType"></param>
        /// <param name="pNumber"></param>
        public int NuevoCliente(string pFirstName, string pLastName, DocumentType pType, string pNumber) 
        {
            Client mClient;
            using (UnitOfWork mUnit = new UnitOfWork(new AccountManagerDbContext()))
            {
                mClient = new Client
                {
                    FirstName = pFirstName,
                    LastName = pLastName,
                    Document = new Document
                    {
                        Type = pType,
                        Number = pNumber
                    }
                };
                mUnit.ClientRepository.Add(mClient);
                mUnit.Complete();
            }
            return mClient.Id;
        }

        /// <summary>
        /// Abre una cuenta para un cliente
        /// </summary>
        /// <param name="pClientId"></param>
        /// <param name="pNombre"></param>
        /// <param name="pOverdraftLimit"></param>
        public int AperturaCuenta(int pClientId, string pNombre, double pOverdraftLimit)
        {
            Account mAccount;
            using (UnitOfWork mUnit = new UnitOfWork(new AccountManagerDbContext()))
            {
                mAccount = new Account
                {
                    Name = pNombre,
                    OverdraftLimit = pOverdraftLimit,
                    Client = mUnit.ClientRepository.Get(pClientId)
                };
                mUnit.AccountRepository.Add(mAccount);
                mUnit.ClientRepository.Get(pClientId).Accounts.Add(mAccount);
                mUnit.Complete();
            }
            return mAccount.Id;
        }

        /// <summary>
        /// Realiza un movimiento para una cuenta
        /// </summary>
        /// <param name="pAccountId"></param>
        /// <param name="pDescripcion"></param>
        /// <param name="pAmount"></param>
        public void RealizarMovimiento(int pAccountId, string pDescripcion, double pAmount)
        {
            using (UnitOfWork mUnit = new UnitOfWork(new AccountManagerDbContext()))
            {
                Account mAccount = mUnit.AccountRepository.Get(pAccountId);
                AccountMovement mMovement = new AccountMovement
                {
                    Description = pDescripcion,
                    Date = DateTime.Now,
                    Amount = pAmount,
                    Account = mAccount
                };
                mAccount.Movements.Add(mMovement);
                mUnit.Complete();
            }
        }

        /// <summary>
        /// Obtiene todas las cuentas cuyo saldo sea negativo y ha superado el limite de descubierto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountDTO> GetOverdrawnAccounts()
        {
            List<AccountDTO> mAccounts = new List<AccountDTO>();
            using (UnitOfWork mUnit = new UnitOfWork(new AccountManagerDbContext()))
            {
                foreach (Account mAccount in mUnit.AccountRepository.GetOverdrawnAccounts()) //cambiar
                {
                    mAccounts.Add(new AccountDTO
                    {
                        Balance = mUnit.AccountRepository.GetAccountBalance(mAccount.Id),
                        Id = mAccount.Id,
                        Name = mAccount.Name,
                        OverdraftLimit = mAccount.OverdraftLimit
                    });
                }
                mUnit.Complete();
            }
            return mAccounts;
        }

        /// <summary>
        /// Devuelve el Id de un cliente buscando por su documento
        /// </summary>
        /// <param name="pDocument"></param>
        /// <returns></returns>
        public int GetClientId(DocumentType pDocumentType, string pNumber)
        {
            Document mDocument = new Document
            {
                Type = pDocumentType,
                Number = pNumber
            };
            int mClientId = new int();
            using (UnitOfWork mUnit = new UnitOfWork(new AccountManagerDbContext()))
            {
                mClientId = mUnit.ClientRepository.GetIdByDocument(mDocument);
                mUnit.Complete();
            }
            return mClientId;
        }
    }
}
