using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitRepositoriesClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
     
        private readonly IRepositoryService _service;

        public RepositoriesController(IRepositoryService service)
        {
            
            _service = service;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(CreateRepositoryRequest request)
        {
            var repository = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = repository.Id }, repository);
        }  

        //READ (All)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var repositories = await _service.GetAllAsync();
            return Ok(repositories);
        }

        //READ (by id)
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var repository = await _service.GetByIdAsync(id);

            if (repository == null)
            {
                return NotFound();
            }

            return Ok(repository);
        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(Guid id , UpdateRepositoryRequest request)
        {
            var repository = await _service.UpdateAsync(id, request);

            if (repository == null)
            {
                return NotFound();
            }

            return Ok(repository);
        }

        //DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
