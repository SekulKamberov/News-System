namespace NewsSystem.Infrastructure.ArticleCreation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Common;
    using Common.Persistence;
    using ArticleCreation;
    using Application.ArticleCreation.Articles;
    using Application.ArticleCreation.Articles.Queries.Categories;
    using Application.ArticleCreation.Articles.Queries.Common;
    using Application.ArticleCreation.Articles.Queries.Details;

    using Domain.Common;
    using Domain.ArticleCreation.Models.Articles;
    using Domain.ArticleCreation.Models.Journalists;

    internal class ArticleRepository : DataRepository<IArticleCreationDbContext, Article>, IArticleRepository
    {
        private readonly IMapper mapper;

        public ArticleRepository(IArticleCreationDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Article> Find(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<Article> FindComment(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(c => c.Comments.Any(c => c.Id == id))
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var article = await this.Data.Articles.FindAsync(id);

            if (article == null)
            {
                return false;
            }

            this.Data.Articles.Remove(article);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteComment(int Id, int articleId, CancellationToken cancellationToken = default)
        {
            var article = await this.Data.Articles.FindAsync(articleId);

            if (article == null)
            {
                return false;
            }

            var comment = article.Comments.Where(c => c.Id == Id).FirstOrDefault();

            this.Data.Comments.Remove(comment);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetArticleListings<TOutputModel>(
            Specification<Article> articleSpecification,
            Specification<Journalist> journalistSpecification,
            ArticlesSortOrder articlesSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                .ProjectTo<TOutputModel>(this
                    .GetArticlesQuery(articleSpecification, journalistSpecification)
                    .Sort(articlesSortOrder))
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take);

        public async Task<ArticleDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ArticleDetailsOutputModel>(this
                    .All()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default)
            => await this
                .Data
                .Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        public async Task<IEnumerable<GetArticleCategoryOutputModel>> GetArticleCategories(
            CancellationToken cancellationToken = default)
        {
            var categories = await this.mapper
                .ProjectTo<GetArticleCategoryOutputModel>(this.Data.Categories)
                .ToDictionaryAsync(k => k.Id, cancellationToken);

            var articlesPerCategory = await this.All()
                .GroupBy(c => c.Category.Id)
                .Select(gr => new
                {
                    CategoryId = gr.Key,
                    TotalArticles = gr.Count()
                })
                .ToListAsync(cancellationToken);

            articlesPerCategory.ForEach(c => categories[c.CategoryId].TotalArticles = c.TotalArticles);

            return categories.Values;
        }

        public async Task<int> Total(
            Specification<Article> articleSpecification,
            Specification<Journalist> journalistSpecification,
            CancellationToken cancellationToken = default)
            => await this
                .GetArticlesQuery(articleSpecification, journalistSpecification)
                .CountAsync(cancellationToken);

        //private IQueryable<Article> AllAvailable()
        //    => this
        //        .All()
        //        .Where(art => art.IsAvailable);

        private IQueryable<Article> GetArticlesQuery(
            Specification<Article> articleSpecification,
            Specification<Journalist> journalistSpecification)
            => this
                .Data
                .Journalists
                .Where(journalistSpecification)
                .SelectMany(d => d.Articles)
                .Where(articleSpecification);
    }
}
