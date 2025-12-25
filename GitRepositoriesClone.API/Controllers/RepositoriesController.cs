using GitRepositoriesClone.API.Data;
using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitRepositoriesClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RepositoriesController(AppDbContext context)
        {
            _context = context;
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

            _context.Repositories.Add(repository);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = repository.Id }, repository);
        }

        //READ (All)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var repositories = await _context.Repositories.ToListAsync();
            return Ok(repositories);
        }

        //READ (by id)
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var repository = await _context.Repositories.FindAsync(id);

            if(repository == null)
            {
                return NotFound();
            }

            return Ok(repository);
        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(Guid id , UpdateRepositoryRequest request)
        {
            var repository = await _context.Repositories.FindAsync(id);

            if(repository == null)
            {
                return NotFound();
            }

            repository.Name = request.Name;
            repository.Description = request.Description;

            await _context.SaveChangesAsync();
            return Ok(repository);
        }

        //DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var repository = await _context.Repositories.FindAsync(id);

            if(repository == null)
            {
                return NotFound();
            }


            _context.Repositories.Remove(repository);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
