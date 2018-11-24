using DessertTaCeinture.DAL.Entities;
using System.Configuration;
using Tools.Generic;

namespace DessertTaCeinture.DAL.Repositories
{
    public class RatingRepository : BaseRepository<RatingEntity>
    {
        public RatingRepository() : base(ConfigurationManager.AppSettings["provider"], ConfigurationManager.AppSettings["connString"]) { }
    }
}
