namespace NewsSystem.Application.Statistics.Queries.ArticleViews
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class GetArticleViewsQuery : IRequest<int>
    {
        public int ArticleId { get; set; }

        public class GetArticleViewsQueryHandler : IRequestHandler<GetArticleViewsQuery, int>
        {
            private readonly IStatisticsRepository statistics;

            public GetArticleViewsQueryHandler(IStatisticsRepository statistics)
                => this.statistics = statistics;

            public Task<int> Handle(
                GetArticleViewsQuery request,
                CancellationToken cancellationToken)
                => this.statistics.GetArticleViews(request.ArticleId, cancellationToken);
        }
    }
}
