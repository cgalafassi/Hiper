using HiperAPI.Domain.Core.Interfaces.Repositorys;
using HiperAPI.Domain.Core.Interfaces.Services;

using System;
using System.Collections.Generic;

namespace HiperAPI.Domain.Services
{
    public abstract class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> Repository) => _repository = Repository;

        public virtual void Add(TEntity obj) => _repository.Add(obj);

        public virtual void Update(TEntity obj) => _repository.Update(obj);

        public virtual void Remove(TEntity obj) => _repository.Remove(obj);

        public virtual TEntity GetById(int id) => _repository.GetById(id);

        public virtual IEnumerable<TEntity> GetAll() => _repository.GetAll();

        public virtual void Dispose() => _repository.Dispose();
    }
}
