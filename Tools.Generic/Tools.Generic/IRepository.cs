using System.Linq;

namespace Tools.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetEntities();
        TEntity GetEntity(int entitykey);
        bool AddEntity(TEntity entity);
        bool UpdateEntity(TEntity entity);
        bool DeleteEntity(int entitykey);
    }
}
