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
    public class CategoryController : ApiController
    {
        private readonly UnitOfWork UOW = new UnitOfWork();

        [HttpGet]
        public IQueryable<CategoryModel> Get()
        {
            List<CategoryModel> Models = new List<CategoryModel>();

            foreach(var entity in UOW.CategoryRepository.GetEntities())
            {
                Models.Add(AutoMapper<CategoryEntity, CategoryModel>.AutoMap(entity));
            }

            return Models.AsQueryable() ;
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
                return Ok(AutoMapper<CategoryEntity, CategoryModel>.AutoMap(UOW.CategoryRepository.GetEntity(id)));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(CategoryModel model)
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

        [HttpPut]
        public IHttpActionResult Put(int id, CategoryModel model)
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
            catch(Exception ex)
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
                return Ok(UOW.CategoryRepository.DeleteEntity(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool EntityExists(int id)
        {
            return UOW.CategoryRepository.GetEntities().Where(e => e.Id == id).Count() > 0;
        }
    }
}
