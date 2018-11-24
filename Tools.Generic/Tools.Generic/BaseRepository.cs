using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Tools.Generic
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //L'interface IDbConnection permet à une classe qui hérite d'implémenter une classe Connection représentant une session unique avec une source de données.
        private IDbConnection _connection;

        protected BaseRepository(string InvarianName, string connectionString)
        {
            _connection = DbProviderFactories.GetFactory(InvarianName).CreateConnection();
            _connection.ConnectionString = connectionString;
        }

        #region Public
        public bool AddEntity(TEntity entity)
        {
            var builder = new QueryBuilder<TEntity>(entity);
            return (ExecuteCommand(builder.GetInsertCommand()));
        }

        public bool UpdateEntity(TEntity entity)
        {
            var builder = new QueryBuilder<TEntity>(entity);
            return (ExecuteCommand(builder.GetUpdateCommand()));
        }


        public bool DeleteEntity(int entitykey)
        {
            TEntity instance = Activator.CreateInstance<TEntity>();
            var builder = new QueryBuilder<TEntity>(instance);
            return (ExecuteCommand(builder.GetDeleteCommand(entitykey)));
        }


        public TEntity GetEntity(int entitykey)
        {
            TEntity instance = Activator.CreateInstance<TEntity>();
            var builder = new QueryBuilder<TEntity>(instance);
            return GetOne(builder.GetSelectOneCommand(entitykey));
        }

        public IQueryable<TEntity> GetEntities()
        {
            TEntity instance = Activator.CreateInstance<TEntity>();
            var builder = new QueryBuilder<TEntity>(instance);
            return GetAll(builder.GetSelectAllCommand()).AsQueryable();
        }
        #endregion

        #region Private
        private TEntity GetOne(Query query)
        {
            TEntity entity = null;
            IDbCommand cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query.Text;
            foreach (var queryParam in query.ParametersValues)
            {
                var param = cmd.CreateParameter();
                param.Value = queryParam.Value;
                param.ParameterName = queryParam.Key;
                cmd.Parameters.Add(param);
            }
            _connection.Open();
            try
            {
                var reader = cmd.ExecuteReader();
                reader.Read();
                entity = PopulateEntity(reader);
                reader.Close();
            }
            finally
            {
                _connection.Close();
            }
            return entity;
        }

        protected bool ExecuteCommand(Query query)
        {
            int result = -1;
            //Représente une instruction SQL qui est exécutée alors qu’elle est connectée à une source de données
            IDbCommand cmd = _connection.CreateCommand();
            foreach (var queryParam in query.ParametersValues)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = queryParam.Key;
                param.Value = queryParam.Value;

                cmd.Parameters.Add(param);
            }
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query.Text;
            _connection.Open();
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
            return result > 0;
        }

        //Transformation directe de datareader en entity
        private TEntity PopulateEntity(IDataReader reader)
        {
            return (Mapper<TEntity>.AutoMap(reader));
        }

        private IEnumerable<TEntity> GetAll(string command)
        {
            var list = new List<TEntity>();

            IDbCommand cmd = _connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = command;
            _connection.Open();
            try
            {
                var reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                        list.Add(PopulateEntity(reader));
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }
        #endregion
    }
}
