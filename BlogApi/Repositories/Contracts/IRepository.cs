using System.Collections.Generic;
using BlogApi.Entities;

namespace BlogApi.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        
        TEntity Get(object search);
        
        TEntity Create(TEntity entity);
    }
}