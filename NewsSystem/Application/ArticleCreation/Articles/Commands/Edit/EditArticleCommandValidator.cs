namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Edit
{
    using Common;
    using FluentValidation;

    public class EditArticleCommandValidator : AbstractValidator<EditArticleCommand>
    {
        public EditArticleCommandValidator(IArticleRepository articleRepository)
            => this.Include(new ArticleCommandValidator<EditArticleCommand>(articleRepository));
    }
}
