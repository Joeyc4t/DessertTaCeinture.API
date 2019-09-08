using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DessertTaCeinture.DAL.Repositories
{
    public class StatisticsRepository
    {
        private string connString = ConfigurationManager.AppSettings["connString"];

        public Dictionary<string, int> GetUsersCount()
        {
            string query = @"SELECT CASE IsActive WHEN 1 THEN 'Actif'
					                              WHEN 0 THEN 'Inactif' END AS 'Key', COUNT(Id) AS 'Value'
                             FROM [User]
                             GROUP BY IsActive";
            return GenerateDictionary(query);
        }

        public Dictionary<string, int> GetCommentariesCount()
        {
            string query = @"SELECT 'Commentaires' AS 'Key', COUNT(Id) AS 'Value'
                             FROM Rate
                             WHERE Commentary IS NOT NULL";
            return GenerateDictionary(query);
        }

        public Dictionary<string, int> GetRecipesByCategoryCount()
        {
            string query = @"SELECT c.Name AS 'Key', COUNT(r.Id) AS 'Value'
                             FROM Category c
                             LEFT JOIN Recipe r ON r.CategoryId = c.Id
                             GROUP BY c.Name";
            return GenerateDictionary(query);
        }

        public Dictionary<string, int> GetRecipesByOriginCount()
        {
            string query = @"SELECT o.Country AS 'Key', COUNT(r.Id) AS 'Value'
                             FROM Origin o
                             LEFT JOIN Recipe r ON r.OriginId = o.Id
                             GROUP BY o.Country";
            return GenerateDictionary(query);
        }

        public Dictionary<string, int> GetRecipesCount()
        {
            string query = @"SELECT CASE IsValid WHEN 1 THEN 'Publiée'
					                             WHEN 0 THEN 'Refusée' 
                                                 ELSE 'En attente' END AS 'Key', COUNT(Id) AS 'Value'
                             FROM Recipe
                             GROUP BY IsValid";
            return GenerateDictionary(query);
        }

        public Dictionary<string, int> GetRatesCount()
        {
            string query = @"SELECT 'Cotations' AS 'Key', COUNT(Id) AS 'Value'
                             FROM Rate";
            return GenerateDictionary(query);
        }

        private Dictionary<string, int> GenerateDictionary(string query)
        {
            Dictionary<string, int> dico = new Dictionary<string, int>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            dico.Add(rdr.GetString(0), rdr.GetInt32(1));
                        }
                    }
                }
            }

            return dico;
        }
    }
}
