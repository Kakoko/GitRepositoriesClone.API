using GitRepositoriesClone.API.Data;
using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Models;
using GitRepositoriesClone.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitRepositoriesClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
        private readonly IRepositoryRepository _repository;

        public RepositoriesController(IRepositoryRepository repository)
        {
            _repository = repository;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(CreateRepositoryRequest request)
        {
            var repository = new Repository
            {
                Name = request.Name,
                Description = request.Description
          
            };

            await _repository.AddAsync(repository);

            return CreatedAtAction(nameof(GetById), new { id = repository.Id }, repository);
        }  

        //READ (All)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var repositories = await _repository.GetAllAsync();
            return Ok(repositories);
        }

        //READ (by id)
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var repository = await _repository.GetByIdAsync(id);

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
            var repository = await _repository.GetByIdAsync(id);

            if (repository == null)
            {
                return NotFound();
            }

            repository.Name = request.Name;
            repository.Description = request.Description;

            await _repository.UpdateAsync(repository);
            return Ok(repository);
        }

        //DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var repository = await _repository.GetByIdAsync(id);

            if (repository == null)
            {
                return NotFound();
            }


            await _repository.DeleteAsync(repository);
            return NoContent();

        }
    }
}
