namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Details
{
    using AutoMapper;
    using Common;
    using Journalists.Queries.Common;
    using Domain.Common.Models;
    using Domain.Dealerships.Models.Articles;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class ArticleDetailsOutputModel : ArticleOutputModel
    {
        public JournalistOutputModel Journalist { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, ArticleDetailsOutputModel>()
                .IncludeBase<Article, ArticleOutputModel>();   
    }
}
