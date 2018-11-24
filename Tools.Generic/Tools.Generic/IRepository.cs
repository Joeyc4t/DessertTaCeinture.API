using System.Collections.Generic;

namespace Tools.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool AddEntity(TEntity entity);
        bool UpdateEntity(TEntity entity);
        bool DeleteEntity(int entitykey);
        TEntity GetEntity(int entitykey);
        IEnumerable<TEntity> GetEntities();
    }
}
