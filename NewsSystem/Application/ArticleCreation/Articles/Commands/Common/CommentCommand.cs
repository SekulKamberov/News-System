namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Common
{
    using Application.Common;

    public class CommentCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string CreatedBy { get; set; } = default!;

        public int ArticleId { get; set; } = default!;

        public int CommentId { get; set; } = default!;
    }
}
