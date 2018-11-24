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
        public bool Put(RatingEntity entity)
        {
            return (UOW.RatingRepository.UpdateEntity(entity));
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.RatingRepository.DeleteEntity(id));
        }
    }
}
