using System.Collections.Generic;

namespace Tools.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntity(int entitykey);
        bool AddEntity(TEntity entity);
        bool UpdateEntity(TEntity entity);
        bool DeleteEntity(int entitykey);
    }
}
