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
    public class Recipe_StepController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IQueryable<Recipe_StepModel> Get()
        {
            List<Recipe_StepModel> Models = new List<Recipe_StepModel>();

            foreach (var entity in UOW.Recipe_StepRepository.GetEntities())
            {
                Models.Add(AutoMapper<Recipe_StepEntity, Recipe_StepModel>.AutoMap(entity));
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
                return Ok(AutoMapper<Recipe_StepEntity, Recipe_StepModel>.AutoMap(UOW.Recipe_StepRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Recipe_StepModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.Recipe_StepRepository.AddEntity(AutoMapper<Recipe_StepModel, Recipe_StepEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Recipe_StepModel model)
        {
            if (model == null || !id.Equals(model.ConcatId))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.Recipe_StepRepository.UpdateEntity(AutoMapper<Recipe_StepModel, Recipe_StepEntity>.AutoMap(model));

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
                return Ok(UOW.Recipe_StepRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool EntityExists(int id)
        {
            return UOW.Recipe_StepRepository.GetEntities().Where(e => e.ConcatId == id).Count() > 0;
        }
    }
}
