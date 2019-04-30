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
    /// Category controller.
    /// </summary>
    public class CategoryController : BaseController<CategoryModel, int>
    {
        /// <summary>
        /// Delete category by ID.
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
                return Ok(UOW.CategoryRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Select all categories.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<CategoryModel> Get()
        {
            List<CategoryModel> Models = new List<CategoryModel>();

            foreach (var entity in UOW.CategoryRepository.GetEntities())
            {
                Models.Add(AutoMapper<CategoryEntity, CategoryModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select category by ID.
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
                return Ok(AutoMapper<CategoryEntity, CategoryModel>.AutoMap(UOW.CategoryRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Insert new category.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(CategoryModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.CategoryRepository.AddEntity(AutoMapper<CategoryModel, CategoryEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update category by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, CategoryModel model)
        {
            if (model == null || !id.Equals(model.Id))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.CategoryRepository.UpdateEntity(AutoMapper<CategoryModel, CategoryEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Check if entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override bool EntityExists(int id)
        {
            return UOW.CategoryRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}