namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{
    public class CreateCommentOutputModel
    {
        public CreateCommentOutputModel(int articleId)
            => this.ArticleId = articleId;

            public int ArticleId { get; }
    }
}
