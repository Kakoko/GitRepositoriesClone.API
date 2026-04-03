using FluentValidation;

namespace GitRepositoriesClone.API.Features.Repositories.Commands
{
    public class CreateRepositoryCommandValidator : AbstractValidator<CreateRepositoryCommand>
    {
        public CreateRepositoryCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Repository name is required.")
            .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot be more than 500 characters");
        }
    }
}
