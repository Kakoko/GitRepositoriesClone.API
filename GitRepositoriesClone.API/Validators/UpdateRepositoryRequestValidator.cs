using FluentValidation;
using GitRepositoriesClone.API.Data.Dtos;

namespace GitRepositoriesClone.API.Validators
{
    public class UpdateRepositoryRequestValidator : AbstractValidator<UpdateRepositoryRequest>
    {
        public UpdateRepositoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Repository name is required.")
                .MaximumLength(100).WithMessage("Repository name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        }
    }
}
