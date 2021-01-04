namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{    public class CreateArticleOutputModel
    {
        public CreateArticleOutputModel(int articleId) 
            => this.ArticleId = articleId;

        public int ArticleId { get; }
    }

}
