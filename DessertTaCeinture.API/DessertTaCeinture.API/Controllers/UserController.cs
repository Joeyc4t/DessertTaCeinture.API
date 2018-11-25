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
    public class UserController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IQueryable<UserModel> Get()
        {
            List<UserModel> Models = new List<UserModel>();

            foreach (var entity in UOW.UserRepository.GetEntities())
            {
                Models.Add(AutoMapper<UserEntity, UserModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!EntityExists(id))
                return NotFound();

            try
            {
                return Ok(AutoMapper<UserEntity, UserModel>.AutoMap(UOW.UserRepository.GetEntity(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(UserModel model)
        {
            if (model == null)
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UserEntity entity = AutoMapper<UserModel, UserEntity>.AutoMap(model);
                entity.Salt = BCrypt.Net.BCrypt.GenerateSalt();
                entity.Password = BCrypt.Net.BCrypt.HashPassword(model.Password, entity.Salt);

                UOW.UserRepository.AddEntity(entity);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, UserModel model)
        {
            if (model == null || !id.Equals(model.Id))
                return BadRequest("Invalid model");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!EntityExists(id))
                return NotFound();

            try
            {
                UOW.UserRepository.UpdateEntity(AutoMapper<UserModel, UserEntity>.AutoMap(model));

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

            if (!EntityExists(id))
                return NotFound();

            try
            {
                return Ok(UOW.UserRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool EntityExists(int id)
        {
            return UOW.UserRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}
