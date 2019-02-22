using DefaultProject.Domain.Entities.Base;
using DefaultProject.Domain.Interfaces.Repositories.Base;
using DefaultProject.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DefaultProject.Infra.Data.Repositories
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : EntityBase
        where TId : struct
    {

        protected readonly DefaultContext _context;

        public BaseRepository(DefaultContext context)
        {
            _context = context;
        }

        public IList<TEntity> Get()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Insert(TEntity obj)
        {
            return _context.Set<TEntity>().Add(obj);
        }

        public TEntity Update(TEntity obj)
        {          
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public void Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }
    }
}
