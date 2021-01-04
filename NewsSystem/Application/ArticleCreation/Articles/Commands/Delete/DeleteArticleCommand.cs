namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common;
    using Journalists;
    using MediatR;

    public class DeleteArticleCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IArticleRepository articleRepository;
            private readonly IJournalistRepository journalistRepository;

            public DeleteArticleCommandHandler(
                ICurrentUser currentUser, 
                IArticleRepository articleRepository, 
                IJournalistRepository journalistRepository)
            {
                this.currentUser = currentUser;
                this.articleRepository = articleRepository;
                this.journalistRepository = journalistRepository;
            }

            public async Task<Result> Handle(
                DeleteArticleCommand request, 
                CancellationToken cancellationToken)
            {
                var jurnalist = await this.journalistRepository.FindByUserId(currentUser.UserId);

                var journalistHasArticle = await this.journalistRepository.HasArticle(
                    jurnalist.Id,
                    request.Id,
                    cancellationToken);

                if (!journalistHasArticle)
                {
                    return journalistHasArticle;
                }

                return await this.articleRepository.Delete(
                    request.Id, 
                    cancellationToken);
            }
        }
    }
}
