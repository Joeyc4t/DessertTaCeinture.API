using DessertTaCeinture.API.Models;
using DessertTaCeinture.API.Tools;
using DessertTaCeinture.DAL.Entities;
using DessertTaCeinture.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    public class Recipe_IngredientsController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IQueryable<Recipe_IngredientsModel> Get()
        {
            List<Recipe_IngredientsModel> Models = new List<Recipe_IngredientsModel>();

            foreach (var entity in UOW.Recipe_IngredientsRepository.GetEntities())
            {
                Models.Add(AutoMapper<Recipe_IngredientsEntity, Recipe_IngredientsModel>.AutoMap(entity));
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
                return Ok(AutoMapper<Recipe_IngredientsEntity, Recipe_IngredientsModel>.AutoMap(UOW.Recipe_IngredientsRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Recipe_IngredientsModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.Recipe_IngredientsRepository.AddEntity(AutoMapper<Recipe_IngredientsModel, Recipe_IngredientsEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Recipe_IngredientsModel model)
        {
            if (model == null || !id.Equals(model.ConcatId))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.Recipe_IngredientsRepository.UpdateEntity(AutoMapper<Recipe_IngredientsModel, Recipe_IngredientsEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!EntityExists(id))
                return NotFound();

            try
            {
                return Ok(UOW.Recipe_IngredientsRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool EntityExists(int id)
        {
            return UOW.Recipe_IngredientsRepository.GetEntities().Where(e => e.ConcatId == id).Count() > 0;
        }
    }
}
