using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIWhitSwagger.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Save();
        Task SaveAsync();
        IEnumerable<T> GetAll();

        T GetByID(string id);

        void Insert(T entity);

        void Update(T entityToUpdate);
        bool Exists(object id);
        void Delete(object id);
        void Delete(T entityToDelete);
    }
}
