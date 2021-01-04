namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;

    using Application.Common;
    using Application.Common.Contracts;
    using Common;

    using MediatR;
    using NewsSystem.Application.ArticleCreation.Journalists;

    public class EditArticleCommand : ArticleCommand<EditArticleCommand>, IRequest<Result>
    {
        public class EditArticleCommandHandler : IRequestHandler<EditArticleCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IArticleRepository articleRepository;
            private readonly IJournalistRepository journalistRepository;

            public EditArticleCommandHandler(
                ICurrentUser currentUser,
                IArticleRepository articleRepository,
                IJournalistRepository journalistRepo)
            {
                this.currentUser = currentUser;
                this.articleRepository = articleRepository;
                this.journalistRepository = journalistRepo;
            }

            public async Task<Result> Handle(
                EditArticleCommand request,
                CancellationToken cancellationToken)
            {
                //var journalistHasArticle = await currentUser.JournalistHasArticle(
                //    this.journalistRepository,
                //    request.Id,
                //    cancellationToken);

                //if (!journalistHasArticle)
                //{
                //    return journalistHasArticle;
                //}

                var category = await this.articleRepository.GetCategory(
                    request.Category,
                    cancellationToken);

                var article = await this.articleRepository
                    .Find(request.Id, cancellationToken);

                article
                    .UpdateTitle(request.Title)
                    .UpdateContent(request.Content)
                    .UpdateCategory(category)
                    .UpdateImageUrl(request.ImageUrl);

                await this.articleRepository.Save(article, cancellationToken);

                return Result.Success;
            }
        }
    }
}
