using DessertTaCeinture.DAL.Entities;
using System.Configuration;
using Tools.Generic;

namespace DessertTaCeinture.DAL.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity>
    {
        public RoleRepository() : base(ConfigurationManager.AppSettings["provider"], ConfigurationManager.AppSettings["connString"]) { }
    }
}
