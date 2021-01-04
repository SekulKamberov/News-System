namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
{
    using Common;
    using Models.Articles;

    public interface IArticleFactory : IFactory<Article>
    {
        IArticleFactory WithTitle(string title);

        IArticleFactory WithContent(string content);

        IArticleFactory WithCategory(string name, string description);

        IArticleFactory WithCategory(Category category);

        IArticleFactory WithImageUrl(string imageUrl);

        IArticleFactory WithJournalist(int Id);
    }
}
