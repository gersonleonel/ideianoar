using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDev.Infrastructure.Repository
{

    public abstract class BaseRepository<T, E>
        where T : class
        where E : DbContext, new()
    {
        protected E Context = new E();

        public T GetById(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().SingleOrDefault(where);
        }

        public List<T> List()
        {
            return Context.Set<T>().ToList();
        }

        public T Add(T Item)
        {
            var retorno = Context.Set<T>().Add(Item);
            Context.SaveChanges();
            return retorno;
        }

        public int Delete(T Item)
        { 
            Context.Set<T>().Attach(Item);
            Context.Set<T>().Remove(Item);
            return Context.SaveChanges();
        }

        public int Update(T Item)
        {
            //Context.Entry(entity).State = EntityState.Modified;
            Context.Set<T>().AddOrUpdate(Item);
            return Context.SaveChanges();
        }
    }
}