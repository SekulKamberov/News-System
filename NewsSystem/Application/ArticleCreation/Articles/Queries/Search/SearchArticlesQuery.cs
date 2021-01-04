namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class SearchArticlesQuery : ArticlesQuery, IRequest<SearchArticlesOutputModel>
    {
        public class SearchArticlesQueryHandler : ArticlesQueryHandler, IRequestHandler<
            SearchArticlesQuery,
            SearchArticlesOutputModel>
        {
            public SearchArticlesQueryHandler(IArticleRepository articleRepository)
                : base(articleRepository)
            {
            }

            public async Task<SearchArticlesOutputModel> Handle(
                SearchArticlesQuery request,
                CancellationToken cancellationToken)
            {
                var articleListings = await base.GetArticleListings<ArticleOutputModel>(
                    request,
                    cancellationToken: cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchArticlesOutputModel(articleListings, request.Page, totalPages);
            }
        }
    }
}
