namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Journalists;
    using MediatR;

    public class ArticleDetailsQuery : EntityCommand<int>, IRequest<ArticleDetailsOutputModel>
    {
        public class ArticleDetailsQueryHandler : IRequestHandler<ArticleDetailsQuery, ArticleDetailsOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly IJournalistRepository journalistRepository;

            public ArticleDetailsQueryHandler(
                IArticleRepository articleRepository, 
                IJournalistRepository journalistRepository)
            {
                this.articleRepository = articleRepository;
                this.journalistRepository = journalistRepository;
            }

            public async Task<ArticleDetailsOutputModel> Handle(
                ArticleDetailsQuery request, 
                CancellationToken cancellationToken)
            {
                var articleDetails = await this.articleRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                articleDetails.Journalist = await this.journalistRepository.GetDetailsByArticleId(
                    request.Id,
                    cancellationToken);

                return articleDetails;
            }
        }
    }
}
