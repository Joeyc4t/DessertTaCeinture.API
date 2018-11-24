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
    public class RecipeController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

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

            if (!UOW.RecipeRepository.GetEntities().ToList().Exists(e => e.Id == id))
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

        [HttpPost]
        public IHttpActionResult Post(RecipeModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.RecipeRepository.AddEntity(AutoMapper<RecipeModel, RecipeEntity>.AutoMap(model));

                return Ok(model);
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

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!UOW.RecipeRepository.GetEntities().ToList().Exists(e => e.Id == id))
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
    }
}
