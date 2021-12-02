using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _Object;

        public GenericRepository()
        {
            _Object = context.Set<T>();
        }
        public void Delete(T p)
        {
            _Object.Remove(p);
            context.SaveChanges();
        }

        public void Insert(T p)
        {
            _Object.Add(p);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _Object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _Object.Where(filter).ToList() ;
        }

        public void Update(T p)
        {
            context.SaveChanges();
        }
    }
}
