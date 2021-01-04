using NewsSystem.Application.ArticleCreation.Journalists;
using System.Threading;
using System.Threading.Tasks;

namespace NewsSystem.Application.Common.Contracts
{
    public interface ICurrentUser
    {
        string UserId { get; }

        string UserName { get; }

        string Role { get; }

        Task JournalistHasArticle(IJournalistRepository journalistRepository, int id, CancellationToken cancellationToken);
    }
}
