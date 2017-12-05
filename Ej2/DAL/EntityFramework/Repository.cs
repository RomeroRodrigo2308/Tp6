using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> 
        where TEntity : class 
        where TDbContext : DbContext
    {
        protected readonly TDbContext iDbContext;

        public Repository(TDbContext pContext)
        {
            if (pContext == null)
            {
                throw (new ArgumentNullException());
            }
            iDbContext = pContext;
        }

        public void Add(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw (new ArgumentNullException());
            }
            iDbContext.Set<TEntity>().Add(pEntity);
        }

        public TEntity Get(int pId)
        {
            return iDbContext.Set<TEntity>().Find(pId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return iDbContext.Set<TEntity>().ToList<TEntity>();
        }

        public void Remove(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw (new ArgumentNullException());
            }
            iDbContext.Set<TEntity>().Remove(pEntity);
        }
    }
}
