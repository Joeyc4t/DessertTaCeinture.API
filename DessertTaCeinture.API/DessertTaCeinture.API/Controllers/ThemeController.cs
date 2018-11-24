using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class ThemeController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<ThemeEntity> Get()
        {
            return UOW.ThemeRepository.GetEntities();
        }

        [HttpGet]
        public ThemeEntity Get(int id)
        {
            return UOW.ThemeRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(ThemeEntity entity)
        {
            return (UOW.ThemeRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, ThemeEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.ThemeRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.ThemeRepository.DeleteEntity(id));
        }
    }
}
