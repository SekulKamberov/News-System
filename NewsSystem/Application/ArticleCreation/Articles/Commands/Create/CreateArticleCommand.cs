namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common;
    using Application.Common.Contracts;
    using Application.ArticleCreation.Journalists;

    using Domain.ArticleCreation.Factories.Articles;
    using Domain.Common.Models;
    using Domain.ArticleCreation.Models.Articles;

    public class CreateArticleCommand : ArticleCommand<CreateArticleCommand>, IRequest<CreateArticleOutputModel>
    {
        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IJournalistRepository journalistRepository;
            private readonly IArticleRepository articleRepository;
            private readonly IArticleFactory articleFactory;

            public CreateArticleCommandHandler(
                ICurrentUser currentUser,
                IJournalistRepository journalistRepository,
                IArticleRepository articleRepository,
                IArticleFactory articleFactory)
            {
                this.currentUser = currentUser;
                this.journalistRepository = journalistRepository;
                this.articleRepository = articleRepository;
                this.articleFactory = articleFactory;
            }

            public async Task<CreateArticleOutputModel> Handle(
                CreateArticleCommand request,
                CancellationToken cancellationToken)
            {
                var journalist = await this.journalistRepository.FindByUserId(
                    this.currentUser.UserId,
                    cancellationToken);

                var category = await this.articleRepository.GetCategory(
                    request.Category,
                    cancellationToken);

                var article = this.articleFactory
                    .WithTitle(request.Title)
                    .WithContent(request.Content)
                    .WithCategory(category)
                    .WithImageUrl(request.ImageUrl)
                    .WithJournalist(journalist.Id)
                    .Build();

                await this.articleRepository.Save(article, cancellationToken);

                return new CreateArticleOutputModel(article.Id);
            }
        }
    }
}
