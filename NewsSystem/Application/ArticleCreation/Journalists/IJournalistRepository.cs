namespace NewsSystem.Application.ArticleCreation.Journalists
{
    using System.Threading;
    using System.Threading.Tasks;

    using Common.Contracts; 

    using Domain.ArticleCreation.Models.Journalists;
    using Application.ArticleCreation.Journalists.Queries.Details;
    using Application.ArticleCreation.Journalists.Queries.Common;
    using NewsSystem.Application.Identity;

    public interface IJournalistRepository : IRepository<Journalist>
    {
        Task<bool> HasArticle(int journalistId, int articleId, CancellationToken cancellationToken = default);

        Task<JournalistDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<JournalistOutputModel> GetDetailsByArticleId(int articleId, CancellationToken cancellationToken = default);

        Task<Journalist> Find(string userId, CancellationToken cancellationToken = default);

        Task<Journalist> FindByUserId(string userId, CancellationToken cancellationToken = default);

        Task<bool> Existed(string userId, CancellationToken cancellationToken = default);
    }
}
