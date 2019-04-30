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
    /// Origin controller.
    /// </summary>
    public class OriginController : BaseController<OriginModel, int>
    {
        /// <summary>
        /// Delete origin by ID.
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
                return Ok(UOW.OriginRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Select all origins.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<OriginModel> Get()
        {
            List<OriginModel> Models = new List<OriginModel>();

            foreach (var entity in UOW.OriginRepository.GetEntities())
            {
                Models.Add(AutoMapper<OriginEntity, OriginModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select origin by ID.
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
                return Ok(AutoMapper<OriginEntity, OriginModel>.AutoMap(UOW.OriginRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Insert new origin.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(OriginModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.OriginRepository.AddEntity(AutoMapper<OriginModel, OriginEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update origin by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, OriginModel model)
        {
            if (model == null || !id.Equals(model.Id))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.OriginRepository.UpdateEntity(AutoMapper<OriginModel, OriginEntity>.AutoMap(model));

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
            return UOW.OriginRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}