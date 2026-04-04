using FluentValidation;
using GitRepositoriesClone.API.Models;
using GitRepositoriesClone.API.Repositories;
using MediatR;

namespace GitRepositoriesClone.API.Features.Repositories.Commands
{
    public class CreateRepositoryHandler  : IRequestHandler<CreateRepositoryCommand , Repository>
    {
        private readonly IRepositoryRepository _repository;
        private readonly IValidator<CreateRepositoryCommand> _validator;

        public CreateRepositoryHandler(
            IRepositoryRepository repository,
            IValidator<CreateRepositoryCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Repository> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
        {
           // await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var repository = new Repository
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repository.AddAsync(repository);

            return repository;
        }

        //public async Task<Repository> Handle(CreateRepositoryCommand command)
        //{
        //    await _validator.ValidateAndThrowAsync(command);

        //    var repository = new Repository
        //    {
        //        Name = command.Name,
        //        Description = command.Description
        //    };

        //    await _repository.AddAsync(repository);

        //    return repository;
        //}
    }
}
