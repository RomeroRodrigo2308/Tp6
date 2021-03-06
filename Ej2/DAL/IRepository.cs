﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    interface IRepository<TEntity>
    {
        void Add(TEntity pEntity);

        void Remove(TEntity pEntity);

        TEntity Get(int pId);

        IEnumerable<TEntity> GetAll();
    }
}
