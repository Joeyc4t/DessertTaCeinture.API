using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class OriginController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<OriginEntity> Get()
        {
            return UOW.OriginRepository.GetEntities();
        }

        [HttpGet]
        public OriginEntity Get(int id)
        {
            return UOW.OriginRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(OriginEntity entity)
        {
            return (UOW.OriginRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, OriginEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.OriginRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.OriginRepository.DeleteEntity(id));
        }
    }
}
