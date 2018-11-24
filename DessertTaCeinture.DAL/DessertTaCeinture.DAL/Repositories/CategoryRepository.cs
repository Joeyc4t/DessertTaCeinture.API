using DessertTaCeinture.DAL.Entities;
using System.Configuration;
using Tools.Generic;


namespace DessertTaCeinture.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryEntity>
    {
        public CategoryRepository() : base(ConfigurationManager.AppSettings["provider"], ConfigurationManager.AppSettings["connString"]) { }
    }
}
