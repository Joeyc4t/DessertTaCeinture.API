using DessertTaCeinture.API.Models;
using DessertTaCeinture.API.Tools;
using DessertTaCeinture.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Tools.Generic;

namespace DessertTaCeinture.API.Controllers
{
    /// <summary>
    /// Recipe controller.
    /// </summary>
    public class RecipeController : BaseController<RecipeModel, int>
    {
        /// <summary>
        /// Delete recipe by ID.
        /// </summary>
        /// <param name="id">ID of the recipe.</param>
        public override IHttpActionResult Delete(int id)
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
        /// <summary>
        /// Select all recipes.
        /// </summary>
        public override IQueryable<RecipeModel> Get()
        {
            List<RecipeModel> Models = new List<RecipeModel>();

            foreach (var entity in UOW.RecipeRepository.GetEntities())
            {
                Models.Add(AutoMapper<RecipeEntity, RecipeModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select recipe by ID.
        /// </summary>
        /// <param name="id">ID of the recipe.</param>
        public override IHttpActionResult Get(int id)
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
        /// <summary>
        /// Get 9 last public recipes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Recipe/GetLastPublished")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IQueryable<RecipeModel> GetLastPublished()
        {
            return Get().Where(e => e.IsPublic == true).OrderByDescending(e => e.CreationDate).Take(9);
        }
        /// <summary>
        /// Select all recipes by user ID.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        [HttpGet]
        [Route("api/Recipe/GetUserRecipes")]
        [ApiExplorerSettings(IgnoreApi = true)]
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
        /// <summary>
        /// Get number of published recipes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Recipe/GetRecipeIndexes")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public int[] GetRecipeIndexes()
        {
            List<int> indexes = new List<int>();
            foreach (var item in Get().Where(x => x.IsPublic))
            {
                indexes.Add(item.Id);
            }
            return indexes.ToArray();
        }        
        /// <summary>
        /// Insert new recipe.
        /// </summary>
        /// <param name="model">The recipe model.</param>
        public override IHttpActionResult Post(RecipeModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int inserted = UOW.RecipeRepository.AddEntity(AutoMapper<RecipeModel, RecipeEntity>.AutoMap(model));
                return new CreatedContentActionResult(Request, Url.Link("DefaultApi", new { controller = "Post", inserted = inserted }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update recipe by ID.
        /// </summary>
        /// <param name="id">ID of the recipe.</param>
        /// <param name="model">The recipe model.</param>
        public override IHttpActionResult Put(int id, RecipeModel model)
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
        /// <summary>
        /// Check if entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override bool EntityExists(int id)
        {
            return UOW.RecipeRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}