using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class RateController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<RateEntity> Get()
        {
            return UOW.RateRepository.GetEntities();
        }

        [HttpGet]
        public RateEntity Get(int id)
        {
            return UOW.RateRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(RateEntity entity)
        {
            return (UOW.RateRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, RateEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.RateRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.RateRepository.DeleteEntity(id));
        }
    }
}
