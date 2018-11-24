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
    public class RatingController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IQueryable<RatingModel> Get()
        {
            List<RatingModel> Models = new List<RatingModel>();

            foreach (var entity in UOW.RatingRepository.GetEntities())
            {
                Models.Add(AutoMapper<RatingEntity, RatingModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!UOW.RatingRepository.GetEntities().ToList().Exists(e => e.ConcatId == id))
                return NotFound();

            try
            {
                return Ok(AutoMapper<RatingEntity, RatingModel>.AutoMap(UOW.RatingRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(RatingModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.RatingRepository.AddEntity(AutoMapper<RatingModel, RatingEntity>.AutoMap(model));

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, RatingModel model)
        {
            if (model == null || !id.Equals(model.ConcatId))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UOW.RatingRepository.UpdateEntity(AutoMapper<RatingModel, RatingEntity>.AutoMap(model));

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

            if (!UOW.RatingRepository.GetEntities().ToList().Exists(e => e.ConcatId == id))
                return NotFound();

            try
            {
                return Ok(UOW.RatingRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
