﻿using DessertTaCeinture.API.Models;
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
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            if (!EntityExists(id))
                return NotFound();

            try
            {
                return Ok(AutoMapper<UserEntity, UserModel>.AutoMap(UOW.UserRepository.GetEntities().FirstOrDefault(u => u.Email == id)));
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

            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Required field");

            if (string.IsNullOrEmpty(model.Password))
                ModelState.AddModelError("Password", "Required field");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UserEntity entity = AutoMapper<UserModel, UserEntity>.AutoMap(model);

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

        #region Private methods
        private bool EntityExists(string email)
        {
            return UOW.UserRepository.GetEntities().Where(e => e.Email == email).Count() > 0;
        }

        private bool EntityExists(int id)
        {
            return UOW.UserRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
        #endregion
    }
}
