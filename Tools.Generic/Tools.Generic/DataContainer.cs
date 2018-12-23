using System.Collections.Generic;

namespace Tools.Generic
{
    public class DataContainer<TEntity> where TEntity : class
    {
        public List<TEntity> entities { get; set; }
    }
}
