using HiperAPI.Domain.Core.Interfaces.Repositorys;
using HiperAPI.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HiperAPI.Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SqlContext _context;

        public BaseRepository(SqlContext Context) => _context = Context;

        public virtual void Add(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetById(int id) => _context.Set<TEntity>().Find(id);

        public virtual IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();

        public virtual void Update(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Remove(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose() => _context.Dispose();
    }
}
