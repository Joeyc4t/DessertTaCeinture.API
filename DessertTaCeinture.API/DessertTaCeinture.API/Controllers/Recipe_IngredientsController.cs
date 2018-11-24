using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class Recipe_IngredientsController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<Recipe_IngredientsEntity> Get()
        {
            return UOW.Recipe_IngredientsRepository.GetEntities();
        }

        [HttpGet]
        public Recipe_IngredientsEntity Get(int id)
        {
            return UOW.Recipe_IngredientsRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(Recipe_IngredientsEntity entity)
        {
            return (UOW.Recipe_IngredientsRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, Recipe_IngredientsEntity entity)
        {
            if (id.Equals(entity.ConcatId)) return (UOW.Recipe_IngredientsRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.Recipe_IngredientsRepository.DeleteEntity(id));
        }
    }
}
