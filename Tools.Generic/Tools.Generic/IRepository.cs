using System.Collections.Generic;

namespace Tools.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int AddEntity(TEntity entity);
        bool DeleteEntity(int entitykey);
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntity(int entitykey);
        bool UpdateEntity(TEntity entity);
    }
}