using Microsoft.AspNetCore.Mvc;
using shoptrack_be.Models;
using shoptrack_be.Repositories;

namespace shoptrack_be.Controllers
{
    [ApiController]
    public abstract class CrudController<TModel, TRepository> : ControllerBase
        where TModel : class, IModel
        where TRepository : IRepository<TModel>
    {
        protected readonly TRepository _repository;

        public CrudController(TRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = model.GetId() }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _repository.UpdateAsync(id, model);
            return Ok("The entity was updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(item);
            return Ok("The entity was deleted successfully.");
        }
    }
}
