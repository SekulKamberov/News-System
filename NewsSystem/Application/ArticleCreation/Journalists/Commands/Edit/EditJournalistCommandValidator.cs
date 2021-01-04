namespace NewsSystem.Application.ArticleCreation.Journalists.Commands.Edit
{
    using FluentValidation;
    using static Domain.ArticleCreation.Models.ModelConstants.Common;
    using static Domain.ArticleCreation.Models.ModelConstants.PhoneNumber;

    //public class EditJournalistCommandValidator : AbstractValidator<EditJournalistCommand>
    //{
    //    public EditJournalistCommandValidator()
    //    {
    //        this.RuleFor(u => u.Name)
    //            .MinimumLength(MinNameLength)
    //            .MaximumLength(MaxNameLength)
    //            .NotEmpty();

    //        this.RuleFor(u => u.PhoneNumber)
    //            .MinimumLength(MinPhoneNumberLength)
    //            .MaximumLength(MaxPhoneNumberLength)
    //            .Matches(PhoneNumberRegularExpression)
    //            .NotEmpty();
    //    }
    //}
}
