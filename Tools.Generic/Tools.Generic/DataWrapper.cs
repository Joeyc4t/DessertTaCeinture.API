namespace Tools.Generic
{
    public class DataWrapper<TEntity> where TEntity : class
    {
        public DataContainer<TEntity> container { get; set; }
    }
}
