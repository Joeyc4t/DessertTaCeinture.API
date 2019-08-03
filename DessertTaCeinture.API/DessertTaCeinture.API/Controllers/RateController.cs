using DessertTaCeinture.API.Models;
using DessertTaCeinture.API.Tools;
using DessertTaCeinture.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace DessertTaCeinture.API.Controllers
{
    /// <summary>
    /// Rate controller.
    /// </summary>
    public class RateController : BaseController<RateModel, int>
    {
        /// <summary>
        /// Delete rate by ID.
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
                return Ok(UOW.RateRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Select all rates.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<RateModel> Get()
        {
            List<RateModel> Models = new List<RateModel>();

            foreach (var entity in UOW.RateRepository.GetEntities())
            {
                Models.Add(AutoMapper<RateEntity, RateModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select rate by ID.
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
                return Ok(AutoMapper<RateEntity, RateModel>.AutoMap(UOW.RateRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Insert new rate.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(RateModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.RateRepository.AddEntity(AutoMapper<RateModel, RateEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update rate by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, RateModel model)
        {
            if (model == null || !id.Equals(model.Id))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.RateRepository.UpdateEntity(AutoMapper<RateModel, RateEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns Top recipes by average.
        /// </summary>
        [HttpGet]
        [Route("api/Rate/GetTopRecipes")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IQueryable<RecipeModel> GetTopRecipes()
        {
            List<RecipeModel> models = new List<RecipeModel>();
            RecipeController controller = new RecipeController();

            var ratedItems = from r in Get().Take(20)
                             group r by r.RecipeId into g
                             select new { RecipeId = g.Key, Average = (g.Sum(x => x.RateOnFive)/g.Count()) };

            Dictionary<int, int> dico = ratedItems.OrderByDescending(r => r.Average).ToDictionary(g => g.RecipeId, g => g.Average);

            foreach(KeyValuePair<int, int> kvp in dico)
            {
                models.Add(controller.SearchById(kvp.Key));
            }

            return models.AsQueryable();
        }
        [HttpGet]
        [Route("api/Rate/RateExists")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public bool RateExists(int userId, int recipeId)
        {
            var rate = Get().FirstOrDefault(r => r.RecipeId == recipeId && r.UserId == userId);
            return rate != null ;
        }
        [HttpGet]
        [Route("api/Rate/GetRateByIDs")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public RateModel GetRateByIDs(int userId, int recipeId)
        {
            return Get().FirstOrDefault(r => r.RecipeId == recipeId && r.UserId == userId) ;
        }
        /// <summary>
        /// Check if entity exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override bool EntityExists(int id)
        {
            return UOW.RateRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}