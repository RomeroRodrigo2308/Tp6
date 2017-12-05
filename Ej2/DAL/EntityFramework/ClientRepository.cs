using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2.DAL.EntityFramework
{
    class ClientRepository : Repository<Client, AccountManagerDbContext>, IClientRepository<Client>
    {
        public ClientRepository(AccountManagerDbContext pContext) : base(pContext) { }

        public int GetIdByDocument(Document pDocument)
        {
            var query = from p in iDbContext.Clients
                        where p.Document.Number == pDocument.Number && p.Document.Type == pDocument.Type
                        select p.Id;
            IEnumerable<int> mclientId = query.ToList();
            return mclientId.First<int>();
        }
    }
}
