namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Categories
{
    using Application.Common.Mapping;

    using Domain.ArticleCreation.Models.Articles;

    public class GetArticleCategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalArticles { get; set; }
    }
}
