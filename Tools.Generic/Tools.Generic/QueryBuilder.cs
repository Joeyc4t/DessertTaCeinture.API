using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tools.Generic
{
    public class QueryBuilder<TEntity> where TEntity : class // Cadenace TEntity en class
    {
        private readonly TEntity _item;

        public QueryBuilder(TEntity item)
        {
            _item = item;
        }

        #region Insert
        public Query GetInsertCommand()
        {
            //On récupère le 2ème morceau de la query
            var query = GetInsertFieldList();
            //On récupère le nom de la table

            var table = GetTableName();
            if (String.IsNullOrEmpty(table))
                throw new Exception("No Table attribute was found.");
            //Ecriture de la requête finale
            query.Text = $"INSERT INTO {table} {query.Text}";
            return query;
        }

        //Construction de la query avec les paramètres
        private Query GetInsertFieldList()
        {
            Query query = new Query();
            //String contenant les colonnes
            StringBuilder sbField = new StringBuilder();
            //String contenant les paramètres
            StringBuilder sbValues = new StringBuilder();
            //On récupère les propriétés de l'entité
            PropertyInfo[] properties = _item.GetType().GetProperties();
            //On récupère la primary key de la table
            string keyField = GetKeyFieldName();
            // Pour chaque propriété de la table, on ajoute dans sbField le nom de colonne et dans
            // sbValues @ + nom de colonne
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (keyField == propertyInfo.Name && IsKeyFieldIdentity()) continue;
                else
                {
                    query.ParametersValues.Add(new KeyValuePair<string, object>($"@{propertyInfo.Name}", propertyInfo.GetValue(_item) ?? DBNull.Value));
                    sbField.Append($"{propertyInfo.Name},");
                    sbValues.Append($"@{propertyInfo.Name},");
                }
            }
            //On construit le string final pour les colonnes et pour les paramètres
            string Fields = sbField.ToString();
            Fields = Fields.Remove(Fields.Length - 1);
            string Values = sbValues.ToString();
            Values = Values.Remove(Values.Length - 1);
            //On construit le 2ème morceau de la query
            query.Text = $"({Fields}) OUTPUT INSERTED.ID values ({Values})";
            return query;
        }

        #endregion Insert

        #region Update
        public Query GetUpdateCommand()
        {
            var query = GetUpdateFieldList();
            var table = GetTableName();
            if (String.IsNullOrEmpty(table))
                throw new Exception("No Table attribute was found.");
            query.Text = $"UPDATE {table} SET {query.Text} WHERE {GetKeyFieldName()}=@{GetKeyFieldName()}";
            return query;
        }

        private string GetFormattedUpdateField(PropertyInfo propertyInfo)
        {
            var result = $"{propertyInfo.Name}=@{propertyInfo.Name},";
            return result;
        }
        //Construction de la query avec les paramètres
        private Query GetUpdateFieldList()
        {
            var query = new Query();
            var sb = new StringBuilder();
            var properties = _item.GetType().GetProperties();
            var keyField = GetKeyFieldName();

            KeyValuePair<string, object> PK = new KeyValuePair<string, object>();
            foreach (var propertyInfo in properties)
            {
                if (keyField == propertyInfo.Name)
                {
                    PK = new KeyValuePair<string, object>($"@{propertyInfo.Name}", propertyInfo.GetValue(_item) ?? DBNull.Value);
                }
                else
                {
                    query.ParametersValues.Add(new KeyValuePair<string, object>($"@{propertyInfo.Name}", propertyInfo.GetValue(_item) ?? DBNull.Value));
                    sb.Append(GetFormattedUpdateField(propertyInfo));
                }
            }
            query.ParametersValues.Add(PK);

            query.Text = sb.ToString();
            query.Text = (query.Text.Remove(query.Text.Length - 1));
            return query;
        }

        #endregion Update

        #region Delete
        public Query GetDeleteCommand(int entitykey)
        {
            var query = new Query();
            var table = GetTableName();
            var keyFieldName = GetKeyFieldName();
            if (String.IsNullOrEmpty(table))
                throw new Exception("No Table attribute was found.");
            query.Text = $"DELETE FROM {table} WHERE {keyFieldName}=@{keyFieldName}";
            query.ParametersValues.Add(new KeyValuePair<string, object>($"@{keyFieldName}", entitykey));
            return query;
        }

        #endregion Delete

        #region Select
        public string GetSelectAllCommand()
        {
            var table = GetTableName();
            if (String.IsNullOrEmpty(table))
                throw new Exception("No Table attribute was found.");
            var query = $"SELECT * FROM {table}";
            return query;
        }
        public Query GetSelectOneCommand(int entitykey)
        {
            var query = new Query();
            var table = GetTableName();
            var keyFieldName = GetKeyFieldName();
            if (String.IsNullOrEmpty(table))
                throw new Exception("No Table attribute was found.");
            query.Text = $"SELECT * FROM {table} WHERE {keyFieldName} = @{keyFieldName}";
            query.ParametersValues.Add(new KeyValuePair<string, object>($"@{keyFieldName}", entitykey));
            return query;
        }

        #endregion Select

        #region Helper methods
        protected string GetTableName()
        {
            var tableAttr = Attribute.GetCustomAttribute(typeof(TEntity), typeof(TableAttribute));

            return tableAttr != null ? (tableAttr as TableAttribute).Name : String.Empty;
        }

        private PropertyInfo GetKeyField()
        {
            var keyField = _item.GetType().GetProperties().FirstOrDefault(e => Attribute.IsDefined(e, typeof(KeyAttribute)));
            if (keyField != null)
            {
                return keyField;
            }
            throw new Exception("Key on a property could not be found");
        }
        private string GetKeyFieldName()
        {
            var result = GetKeyField();
            return result.Name;
        }

        private string GetKeyFieldValue()
        {
            var result = GetKeyField();
            return result.GetValue(_item).ToString();
        }
        private bool IsKeyFieldIdentity()
        {
            return (_item.GetType().GetProperties().FirstOrDefault(e => Attribute.IsDefined(e, typeof(KeyAttribute))).CustomAttributes.LastOrDefault().AttributeType.Name == "KeyAttribute");
        }

        #endregion Helper methods
    }
}