using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Tools.Generic
{
    public static class Mapper<TEntity>
    {
        public static TEntity AutoMap(IDataReader dr)
        {
            TEntity instance = System.Activator.CreateInstance<TEntity>();
            var list = new List<string>();

            for (int i = 0; i < dr.FieldCount; i++)
                list.Add(dr.GetName(i));

            foreach (PropertyInfo pi in instance.GetType().GetProperties())
                if (list.Contains(pi.Name))
                    pi.SetValue(instance, dr[pi.Name] == System.DBNull.Value ? null : dr[pi.Name]);

            return instance;
        }
    }
}
