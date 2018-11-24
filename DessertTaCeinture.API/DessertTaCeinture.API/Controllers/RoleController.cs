using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class RoleController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<RoleEntity> Get()
        {
            return UOW.RoleRepository.GetEntities();
        }

        [HttpGet]
        public RoleEntity Get(int id)
        {
            return UOW.RoleRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(RoleEntity entity)
        {
            return (UOW.RoleRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, RoleEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.RoleRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.RoleRepository.DeleteEntity(id));
        }
    }
}
