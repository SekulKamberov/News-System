namespace NewsSystem.Application.Identity.Commands.CreateUser
{
    using FluentValidation;
    using static Domain.ArticleCreation.Models.ModelConstants.Common;
    using static Domain.ArticleCreation.Models.ModelConstants.PhoneNumber;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            this.RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MaximumLength(MaxNameLength)
                .NotEmpty(); 
        }
    }
}
