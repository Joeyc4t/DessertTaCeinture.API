using DessertTaCeinture.DAL.UnitOfWork;
using System.Linq;
using System.Web.Http;

namespace DessertTaCeinture.API.Tools
{
    /// <summary>
    /// Base controller
    /// </summary>
    /// <typeparam name="TEntity">Typeof entity</typeparam>
    /// <typeparam name="TId">Typeof id</typeparam>
    public abstract class BaseController<TEntity, TGetId> : ApiController
    {
        /// <summary>
        /// Unit of work.
        /// </summary>
        protected readonly UnitOfWork UOW = new UnitOfWork();

        /// <summary>
        /// Abstract delete entity method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public abstract IHttpActionResult Delete(int id);
        /// <summary>
        /// Get all entities method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public abstract IQueryable<TEntity> Get();
        /// <summary>
        /// Get entity method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public abstract IHttpActionResult Get(TGetId id);
        /// <summary>
        /// Post entity method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public abstract IHttpActionResult Post(TEntity model);
        /// <summary>
        /// Put entity method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public abstract IHttpActionResult Put(int id, TEntity model);
        /// <summary>
        /// Check if entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected abstract bool EntityExists(int id);
    }
}