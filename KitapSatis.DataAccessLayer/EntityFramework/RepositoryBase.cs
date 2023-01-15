using KitapSatis.DataAccessLayer;
using KitapSatis.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatis.DataAccesLayer.EntityFramework
{
    public class RepositoryBase
    {
        private static DatabaseContext _db;
        private static object _lockObj = new object();

        protected RepositoryBase() { }
        public static DatabaseContext CreateContext()
        {
            if (_db==null)
            {
                lock (_lockObj)
                {
                    if (_db==null)
                    {
                       _db = new DatabaseContext();
                    }
                }
                
            }
            return _db;
        }
    }
}
