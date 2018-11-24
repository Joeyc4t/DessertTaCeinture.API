using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class IngredientController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<IngredientEntity> Get()
        {
            return UOW.IngredientRepository.GetEntities();
        }

        [HttpGet]
        public IngredientEntity Get(int id)
        {
            return UOW.IngredientRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(IngredientEntity entity)
        {
            return (UOW.IngredientRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, IngredientEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.IngredientRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.IngredientRepository.DeleteEntity(id));
        }
    }
}
