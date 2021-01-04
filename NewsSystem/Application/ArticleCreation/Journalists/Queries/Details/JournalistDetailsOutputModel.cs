namespace NewsSystem.Application.ArticleCreation.Journalists.Queries.Details
{
    using AutoMapper;
    using Common;
    using Domain.ArticleCreation.Models.Journalists;

    public class JournalistDetailsOutputModel : JournalistOutputModel
    {
        public int TotalArticles { get; private set; }

        //public override void Mapping(Profile mapper)
        //    => mapper
        //        .CreateMap<Journalist, JournalistDetailsOutputModel>()
        //        .IncludeBase<Journalist, JournalistOutputModel>()
        //        .ForMember(d => d.TotalArticles, cfg => cfg
        //            .MapFrom(d => d.Articles.Count));
    }
}
