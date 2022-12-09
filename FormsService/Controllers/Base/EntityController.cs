using FormsService.DAL.Entities.Base;
using FormsService.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormsService.API.Controllers.Base
{
    [ApiController]
    [Route("/api/[controller]/")]
    public abstract class EntityController<T> : Controller where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        protected EntityController(IRepository<T> repository)
        {
            _repository = repository;
        }

        #region HttpGet

        [HttpGet, Route("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public virtual async Task<IActionResult> GetAllFromDb() =>
            Ok(await _repository.GetAll());

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("getById/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id) =>
            await _repository.FindById(id) is { } item ? Ok(item) : NotFound();

        #endregion HttpGet

        #region HttpPost

        [HttpPost, Route("Add")]
        public async Task<IActionResult> AddToDb([FromBody] T item)
        {
            var response = await _repository.Add(item);
            return Ok(response);
        }

        #endregion HttpPost
    }
}