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
    /// Recipe_Ingredients controller.
    /// </summary>
    public class Recipe_IngredientsController : BaseController<Recipe_IngredientsModel, int>
    {
        /// <summary>
        /// Delete link between recipe and ingredient by ID.
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
                return Ok(UOW.Recipe_IngredientsRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Select all links between recipe and ingredient.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<Recipe_IngredientsModel> Get()
        {
            List<Recipe_IngredientsModel> Models = new List<Recipe_IngredientsModel>();

            foreach (var entity in UOW.Recipe_IngredientsRepository.GetEntities())
            {
                Models.Add(AutoMapper<Recipe_IngredientsEntity, Recipe_IngredientsModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select link between recipes and ingredients by ID.
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
                return Ok(AutoMapper<Recipe_IngredientsEntity, Recipe_IngredientsModel>.AutoMap(UOW.Recipe_IngredientsRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Insert new link between recipe and ingredient.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(Recipe_IngredientsModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int inserted = UOW.Recipe_IngredientsRepository.AddEntity(AutoMapper<Recipe_IngredientsModel, Recipe_IngredientsEntity>.AutoMap(model));
                return Ok(inserted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update link between recipe and ingredient by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, Recipe_IngredientsModel model)
        {
            if (model == null || !id.Equals(model.Id))
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
        /// <summary>
        /// Check if entity exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override bool EntityExists(int id)
        {
            return UOW.Recipe_IngredientsRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}