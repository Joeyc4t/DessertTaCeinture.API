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
    public class OriginController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IQueryable<OriginModel> Get()
        {
            List<OriginModel> Models = new List<OriginModel>();

            foreach (var entity in UOW.OriginRepository.GetEntities())
            {
                Models.Add(AutoMapper<OriginEntity, OriginModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!UOW.OriginRepository.GetEntities().ToList().Exists(e => e.Id == id))
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

        [HttpPost]
        public IHttpActionResult Post(OriginModel model)
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

        [HttpPut]
        public IHttpActionResult Put(int id, OriginModel model)
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

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!UOW.OriginRepository.GetEntities().ToList().Exists(e => e.Id == id))
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
    }
}
