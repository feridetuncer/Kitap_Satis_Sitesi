﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.Core.DataAccess
{
     public interface IDataAccess<T>
    {
        List<T> List();

        IQueryable<T> ListQueryable();

        List<T> List(Expression<Func<T, bool>> where);

        int Save();

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        T Find(Expression<Func<T, bool>> where);
    }

    
}
