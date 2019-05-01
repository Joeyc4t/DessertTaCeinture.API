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
    /// User controller.
    /// </summary>
    public class UserController : BaseController<UserModel, string>
    {
        /// <summary>
        /// Delete user by ID.
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
                return Ok(UOW.UserRepository.DeleteEntity(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Select all users.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<UserModel> Get()
        {
            List<UserModel> Models = new List<UserModel>();

            foreach (var entity in UOW.UserRepository.GetEntities())
            {
                Models.Add(AutoMapper<UserEntity, UserModel>.AutoMap(entity));
            }

            return Models.AsQueryable();
        }
        /// <summary>
        /// Select user by EMAIL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override IHttpActionResult Get(string id)
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
        /// <summary>
        /// Insert new user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Post(UserModel model)
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
        /// <summary>
        /// Update user by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public override IHttpActionResult Put(int id, UserModel model)
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
        /// <summary>
        /// Get user by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/GetUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public UserModel GetUser(int id)
        {
            return Get().Where(u => u.Id == id).FirstOrDefault();
        }
        /// <summary>
        /// Check if entity exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected override bool EntityExists(int id)
        {
            return UOW.UserRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }

        private bool EntityExists(string email)
        {
            return UOW.UserRepository.GetEntities().Where(e => e.Email == email).Count() > 0;
        }
    }
}