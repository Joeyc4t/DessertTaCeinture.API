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
    /// Ingredient controller.
    /// </summary>
    public class IngredientController : BaseController<IngredientModel, int>
    {
        /// <summary>
        /// Delete ingredient by ID.
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
                return Ok(UOW.IngredientRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Select all ingredients.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<IngredientModel> Get()
        {
            List<IngredientModel> Models = new List<IngredientModel>();

            foreach (var entity in UOW.IngredientRepository.GetEntities())
            {
                Models.Add(AutoMapper<IngredientEntity, IngredientModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select ingredient by ID.
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
                return Ok(AutoMapper<IngredientEntity, IngredientModel>.AutoMap(UOW.IngredientRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Insert new ingredient.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(IngredientModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.IngredientRepository.AddEntity(AutoMapper<IngredientModel, IngredientEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update ingredient by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, IngredientModel model)
        {
            if (model == null || !id.Equals(model.Id))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.IngredientRepository.UpdateEntity(AutoMapper<IngredientModel, IngredientEntity>.AutoMap(model));

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
            return UOW.IngredientRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}