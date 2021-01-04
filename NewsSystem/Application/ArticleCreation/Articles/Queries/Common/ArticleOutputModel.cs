namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Dealerships.Models.Articles;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class ArticleOutputModel : IMapFrom<Article>
    {
        public int Id { get; private set; } 

        public string Title { get; private set; } = default!;

        public string Content { get; private set; } = default!;

        public string Category { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public virtual void Mapping(Profile mapper) 
            => mapper
                .CreateMap<Article, ArticleOutputModel>()
                .ForMember(ad => ad.Category, cfg => cfg
                    .MapFrom(ad => ad.Category.Name));
    }
}
