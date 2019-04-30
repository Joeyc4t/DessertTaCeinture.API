using DessertTaCeinture.API.Models;
using DessertTaCeinture.API.Tools;
using DessertTaCeinture.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DessertTaCeinture.API.Controllers
{
    /// <summary>
    /// Recipe_Step controller.
    /// </summary>
    public class Recipe_StepController : BaseController<Recipe_StepModel, int>
    {
        /// <summary>
        /// Delete link between recipe and step by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override IHttpActionResult Delete(int id)
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
        /// <summary>
        /// Select all links between recipes and steps.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<Recipe_StepModel> Get()
        {
            List<Recipe_StepModel> Models = new List<Recipe_StepModel>();

            foreach (var entity in UOW.Recipe_StepRepository.GetEntities())
            {
                Models.Add(AutoMapper<Recipe_StepEntity, Recipe_StepModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select link between recipe and step by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override IHttpActionResult Get(int id)
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
        /// <summary>
        /// Insert new link between recipe and step.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(Recipe_StepModel model)
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
        /// <summary>
        /// Update link between recipe and step by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, Recipe_StepModel model)
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
        /// <summary>
        /// Check if entity exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override bool EntityExists(int id)
        {
            return UOW.Recipe_StepRepository.GetEntities().Where(e => e.ConcatId == id).Count() > 0;
        }
    }
}