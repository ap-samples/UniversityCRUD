using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCRUD.BO;
using System.Data.Entity;
using System.Linq.Expressions;

namespace UniversityCRUD.DA.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public List<T> GetWhere(Func<T, bool> filter)
        {
            using (var ctx = new UniversityContext())
            {
                return ctx.Set<T>().Where(filter).ToList();
            }
        }

        public List<T> GetWhereIncluding(Func<T, bool> filter, params Expression<Func<T, object>>[] includedProperies)
        {
            using (var ctx = new UniversityContext())
            {
                IQueryable<T> dbSet = ctx.Set<T>();

                foreach (var navigationProperty in includedProperies)
                {
                    dbSet = dbSet.Include(navigationProperty);
                }

                return dbSet.Where(filter).ToList();
            }
        }

        public virtual void Add(T item)
        {
            using (var ctx = new UniversityContext())
            {
                ctx.Entry(item).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public virtual void Update(T item)
        {
            using (var ctx = new UniversityContext())
            {
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public virtual void Remove(T item)
        {
            using (var ctx = new UniversityContext())
            {
                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public virtual IQueryable<T> IncludeNavigationProperties(IQueryable<T> dbQuery)
        {
            return dbQuery;
        }
    }
}
