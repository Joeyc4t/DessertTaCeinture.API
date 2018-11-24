using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IEnumerable<CategoryEntity> Get()
        {
            return UOW.CategoryRepository.GetEntities();
        }

        [HttpGet]
        public CategoryEntity Get(int id)
        {
            return UOW.CategoryRepository.GetEntity(id);
        }

        [HttpPost]
        public bool Post(CategoryEntity entity)
        {
            return (UOW.CategoryRepository.AddEntity(entity));
        }

        [HttpPut]
        public bool Put(int id, CategoryEntity entity)
        {
            if (id.Equals(entity.Id)) return (UOW.CategoryRepository.UpdateEntity(entity));
            else return false;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return (UOW.CategoryRepository.DeleteEntity(id));
        }
    }
}
