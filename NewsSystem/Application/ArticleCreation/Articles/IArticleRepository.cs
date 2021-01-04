namespace NewsSystem.Application.ArticleCreation.Articles
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Common.Contracts;

    using Domain.Common;
    using Domain.ArticleCreation.Models.Articles;
    using Domain.ArticleCreation.Models.Journalists;

    using Application.ArticleCreation.Articles.Queries.Categories;
    using Application.ArticleCreation.Articles.Queries.Common;
    using Application.ArticleCreation.Articles.Queries.Details;

    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> Find(int id, CancellationToken cancellationToken = default);

        Task<Article> FindComment(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

       // Task<bool> DeleteComment(int articleId, int commentId, CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TOutputModel>> GetArticleListings<TOutputModel>(
            Specification<Article> articleSpecification,
            Specification<Journalist> journalistSpecification,
            ArticlesSortOrder articlesSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<ArticleDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<GetArticleCategoryOutputModel>> GetArticleCategories(
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<Article> articleSpecification,
            Specification<Journalist> journalistSpecification,
            CancellationToken cancellationToken = default);
    }
}
