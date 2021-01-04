namespace NewsSystem.Application.ArticleCreation.Journalists.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.ArticleCreation.Models.Journalists;

    public class JournalistOutputModel : IMapFrom<Journalist>
    {
        public int Id { get; private set; }

        public string NickName { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Journalist, JournalistOutputModel>()
                .ForMember(d => d.PhoneNumber, cfg => cfg
                    .MapFrom(d => d.PhoneNumber.Number));
    }
}
