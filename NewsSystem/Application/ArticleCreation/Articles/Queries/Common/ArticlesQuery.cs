namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Domain.Common;
    using Domain.ArticleCreation.Models.Articles;
    using Domain.ArticleCreation.Models.Journalists;
    using Domain.ArticleCreation.Specifications.Articles;
    using Domain.ArticleCreation.Specifications.Journalists;

    public abstract class ArticlesQuery
    {
        private const int ArticlesPerPage = 10;  

        public int? Category { get; set; }

        public string? Journalist { get; set; } 

        public string? SortBy { get; set; }

        public string? Order { get; set; }

        public int Page { get; set; } = 1;

        public abstract class ArticlesQueryHandler
        {
            private readonly IArticleRepository articleRepository;

            protected ArticlesQueryHandler(IArticleRepository articleRepository)
                => this.articleRepository = articleRepository;

            protected async Task<IEnumerable<TOutputModel>> GetArticleListings<TOutputModel>(
                ArticlesQuery request,
                bool onlyAvailable = true,
                int? journalistId = default,
                CancellationToken cancellationToken = default)
            {
                var articleSpecification = this.GetArticleSpecification(request, onlyAvailable);

                var journalistSpecification = this.GetJournalistSpecification(request, journalistId);

                var searchOrder = new ArticlesSortOrder(request.SortBy, request.Order);

                var skip = (request.Page - 1) * ArticlesPerPage;

                return await this.articleRepository.GetArticleListings<TOutputModel>(
                    articleSpecification,
                    journalistSpecification,
                    searchOrder,
                    skip,
                    take: ArticlesPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                ArticlesQuery request,
                bool onlyAvailable = true,
                int? journalistId = default,
                CancellationToken cancellationToken = default)
            {
                var articleSpecification = this.GetArticleSpecification(request, onlyAvailable);

                var journalistSpecification = this.GetJournalistSpecification(request, journalistId);

                var totalArticles = await this.articleRepository.Total(
                    articleSpecification,
                    journalistSpecification,
                    cancellationToken);

                return (int)Math.Ceiling((double)totalArticles / ArticlesPerPage);
            }

            private Specification<Article> GetArticleSpecification(ArticlesQuery request, bool onlyAvailable)
                => new ArticleByCategorySpecification(request.Category)
                    .And(new ArticleOnlyAvailableSpecification(onlyAvailable));

            private Specification<Journalist> GetJournalistSpecification(ArticlesQuery request, int? journalistId)
                => new JournalistByIdSpecification(journalistId)
                    .And(new JournalistByNickNameSpecification(request.Journalist));
        }
    }
}
