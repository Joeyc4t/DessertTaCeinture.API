using DessertTaCeinture.DAL.Entities;
using System.Configuration;
using Tools.Generic;

namespace DessertTaCeinture.DAL.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository() : base(ConfigurationManager.AppSettings["provider"], ConfigurationManager.AppSettings["connString"]) { }
    }
}
