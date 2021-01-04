namespace NewsSystem.Application.Statistics.Handlers
{
    using System.Threading.Tasks;

    using Common;
    using Domain.ArticleCreation.Events.Journalists;

    public class ArticleAddedEventHandler : IEventHandler<ArticleAddedEvent>
    {
        private readonly IStatisticsRepository statistics;

        public ArticleAddedEventHandler(IStatisticsRepository statistics)
            => this.statistics = statistics;

        public Task Handle(ArticleAddedEvent domainEvent)
            => this.statistics.IncrementArticles();
    }
}
