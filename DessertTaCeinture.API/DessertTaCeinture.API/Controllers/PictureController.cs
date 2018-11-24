using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class PictureController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<PictureEntity> Get()
        {
            return UOW.PictureRepository.GetEntities();
        }

        [HttpGet]
        public PictureEntity Get(int id)
        {
            return UOW.PictureRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(PictureEntity entity)
        {
            return (UOW.PictureRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, PictureEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.PictureRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.PictureRepository.DeleteEntity(id));
        }
    }
}
