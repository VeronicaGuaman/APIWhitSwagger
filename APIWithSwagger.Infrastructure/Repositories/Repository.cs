using APIWhitSwagger.Domain.Interfaces;
using APIWithSwagger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWithSwagger.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext context;
        protected DbSet<T> table;
      
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            this.table = context.Set<T>();
        }
        public void Save() => context.SaveChanges();
        public async Task SaveAsync() => await context.SaveChangesAsync();

        public virtual IEnumerable<T> GetAll()
        {
            return table;
        }

        public virtual IEnumerable<T> GetWithPagination(int numeroPagina, int numeroRegistros)
        {
            return table
                .Skip((numeroPagina - 1) * numeroRegistros)
                .Take(numeroRegistros)
                .ToList();
        }

        public virtual T GetByID(object id)
        {
            return table.Find(id);
        }

        public virtual void Insert(T entity)
        {
            table.Add(entity);
        }

        public virtual void Update(T entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual bool Exists(object id)
        {
            var entity = table.Find(id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
                return true;
            }

            return false;

        }


        public virtual void Delete(object id)
        {
            T entityToDelete = table.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                table.Attach(entityToDelete);
            }
            table.Remove(entityToDelete);
        }
    }
}
