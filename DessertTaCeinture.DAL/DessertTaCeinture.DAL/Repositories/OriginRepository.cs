using DessertTaCeinture.DAL.Entities;
using System.Configuration;
using Tools.Generic;

namespace DessertTaCeinture.DAL.Repositories
{
    public class OriginRepository : BaseRepository<OriginEntity>
    {
        public OriginRepository() : base(ConfigurationManager.AppSettings["provider"], ConfigurationManager.AppSettings["connString"]) { }
    }
}
