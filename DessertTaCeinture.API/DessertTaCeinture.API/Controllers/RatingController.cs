using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class RatingController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<RatingEntity> Get()
        {
            return UOW.RatingRepository.GetEntities();
        }

        [HttpGet]
        public RatingEntity Get(int id)
        {
            return UOW.RatingRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(RatingEntity entity)
        {
            return (UOW.RatingRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, RatingEntity entity)
        {
            if (id.Equals(entity.ConcatId)) return (UOW.RatingRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.RatingRepository.DeleteEntity(id));
        }
    }
}
