using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork(); 

        public IEnumerable<UserEntity> Get()
        {
            return UOW.UserRepository.GetEntities();
        }

        public UserEntity Get(int id)
        {
            return UOW.UserRepository.GetEntity(id);
        }

        public bool Post(UserEntity entity)
        {
            return (UOW.UserRepository.AddEntity(entity));
        }

        public bool Put(int id, UserEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.UserRepository.UpdateEntity(entity));
            else return false;
        }

        public bool Delete(int id)
        {
            return (UOW.UserRepository.DeleteEntity(id));
        }
    }
}
