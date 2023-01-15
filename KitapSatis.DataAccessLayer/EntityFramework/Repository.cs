using KitapSatis.Common;
using KitapSatis.Core.DataAccess;
using KitapSatis.DataAccessLayer.EntityFramework;
using KitapSatis.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.DataAccesLayer.EntityFramework
{
    public class Repository<T>: RepositoryBase, IDataAccess<T> where T : class
    {
        private DatabaseContext db;
        private DbSet<T> _objectSet;
        public Repository()
        {
            db = RepositoryBase.CreateContext();
            _objectSet = db.Set<T>();
        }
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }
        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }
        public int Save()
        {
            return db.SaveChanges();
        }
        public int Insert(T obj)
        {
            _objectSet.Add(obj);

            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                DateTime now = DateTime.Now;
                o.Degistirme = now;
                o.Olusturma = now;
                o.DegKullanici = App.Common.GetCurrentUsername();
                
            }

            return Save();
        }
        public int Update(T obj)
        {
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                o.Olusturma = DateTime.Now;
                o.DegKullanici = App.Common.GetCurrentUsername();

            }
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
