using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class RecipeController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<RecipeEntity> Get()
        {
            return UOW.RecipeRepository.GetEntities();
        }

        [HttpGet]
        public RecipeEntity Get(int id)
        {
            return UOW.RecipeRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(RecipeEntity entity)
        {
            return (UOW.RecipeRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, RecipeEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.RecipeRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.RecipeRepository.DeleteEntity(id));
        }
    }
}
