namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Categories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetArticleCategoriesQuery : IRequest<IEnumerable<GetArticleCategoryOutputModel>>
    {
        public class GetArticleCategoriesQueryHandler : IRequestHandler<
            GetArticleCategoriesQuery, 
            IEnumerable<GetArticleCategoryOutputModel>>
        {
            private readonly IArticleRepository articleRepository;

            public GetArticleCategoriesQueryHandler(IArticleRepository articleRepository) 
                => this.articleRepository = articleRepository;

            public async Task<IEnumerable<GetArticleCategoryOutputModel>> Handle(
                GetArticleCategoriesQuery request,
                CancellationToken cancellationToken)
                => await this.articleRepository.GetArticleCategories(cancellationToken);
        }
    }
}
