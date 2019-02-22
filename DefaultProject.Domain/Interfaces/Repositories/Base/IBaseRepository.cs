using DefaultProject.Domain.Entities.Base;
using System.Collections.Generic;

namespace DefaultProject.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity, TId> 
        where TEntity : EntityBase
        where TId : struct
    {
        TEntity Insert(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(TEntity id);

        IList<TEntity> Get();

        TEntity GetById(TId id);
    }
}
