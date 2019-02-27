using DessertTaCeinture.API.Models;
using DessertTaCeinture.API.Tools;
using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tools.Generic;

namespace DessertTaCeinture.API.Controllers
{
    public class RecipeController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!EntityExists(id))
                return NotFound();

            try
            {
                return Ok(UOW.RecipeRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IQueryable<RecipeModel> Get()
        {
            List<RecipeModel> Models = new List<RecipeModel>();

            foreach (var entity in UOW.RecipeRepository.GetEntities())
            {
                Models.Add(AutoMapper<RecipeEntity, RecipeModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!EntityExists(id))
                return NotFound();

            try
            {
                return Ok(AutoMapper<RecipeEntity, RecipeModel>.AutoMap(UOW.RecipeRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Recipe/GetUserRecipes")]
        public DataWrapper<RecipeModel> GetUserRecipes(int id)
        {
            DataWrapper<RecipeModel> wrapper = new DataWrapper<RecipeModel>();
            wrapper.container = new DataContainer<RecipeModel>();
            wrapper.container.entities = new List<RecipeModel>();

            foreach (RecipeModel model in Get().Where(r => r.CreatorId.Equals(id)))
            {
                wrapper.container.entities.Add(model);
            }

            return wrapper;
        }

        [HttpPost]
        public IHttpActionResult Post(RecipeModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int inserted = UOW.RecipeRepository.AddEntity(AutoMapper<RecipeModel, RecipeEntity>.AutoMap(model));
                return Ok(inserted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, RecipeModel model)
        {
            if (model == null || !id.Equals(model.Id))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.RecipeRepository.UpdateEntity(AutoMapper<RecipeModel, RecipeEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private bool EntityExists(int id)
        {
            return UOW.RecipeRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}