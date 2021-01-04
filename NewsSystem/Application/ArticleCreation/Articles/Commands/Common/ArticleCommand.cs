namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Common
{
    using Application.Common;
    using Domain.ArticleCreation.Models.Articles;

    public abstract class ArticleCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public int Category { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
    }
}
