using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2.DAL.Comparer
{
    class ComparerDate<T> : IComparer<AccountMovement>
    {
        public int Compare(AccountMovement pMov1, AccountMovement pMov2)
        {
            return DateTime.Compare(pMov1.Date, pMov2.Date);
        }
    }
}
