using System.Collections.Generic;

namespace HiperWebApp.Domain.Core.Interfaces.Repositorys
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();
    }
}
