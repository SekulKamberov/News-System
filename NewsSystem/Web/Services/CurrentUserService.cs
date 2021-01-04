namespace NewsSystem.Web.Services
{
    using System;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Contracts;
    using Microsoft.AspNetCore.Http;
    using NewsSystem.Application.ArticleCreation.Journalists;

    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            this.UserId = user?.FindFirstValue(ClaimTypes.NameIdentifier)!;
            this.UserName = user?.FindFirstValue(ClaimTypes.Name)!;
            this.Role = user?.FindFirstValue(ClaimTypes.Role)!;
        }

        public string UserId { get; }

        public string UserName { get; }

        public string Role { get; }

        public Task JournalistHasArticle(IJournalistRepository journalistRepository, int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
