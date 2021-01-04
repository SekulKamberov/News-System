namespace NewsSystem.Application.Statistics.Queries.Current
{
    using AutoMapper;
    using Common.Mapping;
    using Domain.Statistics.Models;

    public class GetCurrentStatisticsOutputModel : IMapFrom<Statistics>
    {
        public int TotalArticles { get; private set; }

        public int TotalArticleViews { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Statistics, GetCurrentStatisticsOutputModel>()
                .ForMember(cs => cs.TotalArticles, cfg => cfg
                    .MapFrom(s => s.ArticleViews.Count));
    }
}
