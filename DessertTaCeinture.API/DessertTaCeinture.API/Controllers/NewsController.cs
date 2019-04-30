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
    /// News controller.
    /// </summary>
    public class NewsController : BaseController<NewsModel, int>
    {
        /// <summary>
        /// Delete news by ID.
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
                return Ok(UOW.NewsRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Select all news.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<NewsModel> Get()
        {
            List<NewsModel> Models = new List<NewsModel>();

            foreach (var entity in UOW.NewsRepository.GetEntities())
            {
                Models.Add(AutoMapper<NewsEntity, NewsModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select news by ID.
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
                return Ok(AutoMapper<NewsEntity, NewsModel>.AutoMap(UOW.NewsRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Insert new news.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(NewsModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.NewsRepository.AddEntity(AutoMapper<NewsModel, NewsEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update news by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, NewsModel model)
        {
            if (model == null || !id.Equals(model.Id))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.NewsRepository.UpdateEntity(AutoMapper<NewsModel, NewsEntity>.AutoMap(model));

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
            return UOW.NewsRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}