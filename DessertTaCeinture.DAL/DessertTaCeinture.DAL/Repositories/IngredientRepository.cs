using DessertTaCeinture.DAL.Entities;
using System.Configuration;
using Tools.Generic;

namespace DessertTaCeinture.DAL.Repositories
{
    public class IngredientRepository : BaseRepository<IngredientEntity>
    {
        public IngredientRepository() : base(ConfigurationManager.AppSettings["provider"], ConfigurationManager.AppSettings["connString"]) { }
    }
}
