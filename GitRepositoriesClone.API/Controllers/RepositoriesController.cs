using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Features.Repositories.Commands;
using GitRepositoriesClone.API.Features.Repositories.Queries;
using GitRepositoriesClone.API.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GitRepositoriesClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriesController : ControllerBase
    {
        private readonly IRepositoryService _service;
        private readonly IMediator _mediator;

        public RepositoriesController( IRepositoryService service,
            IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        
        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(CreateRepositoryCommand command)
        {
            //var repository = await _service.CreateAsync(request);

            //var result = await _createHandler.Handle(command);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        //READ (All)
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //var repositories = await _service.GetAllAsync();

            //var result = await _getAllHandler.Handle();

            var result = await _mediator.Send(new GetAllRepositoriesQuery());
            return Ok(result);
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
                return NotFound();

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
