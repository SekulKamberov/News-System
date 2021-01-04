namespace NewsSystem.Infrastructure.ArticleCreation.Repositories
{
    using System.Linq; 
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using AutoMapper;

    using Common.Persistence; 

    using Application.ArticleCreation.Journalists.Queries.Details; 
    using Application.ArticleCreation.Journalists.Queries.Common;
    using Application.ArticleCreation.Journalists;

    using Domain.ArticleCreation.Factories.Journalists;
    using Domain.ArticleCreation.Models.Journalists;
    using NewsSystem.Domain.ArticleCreation.Exceptions;
    using NewsSystem.Infrastructure.Identity;
    using NewsSystem.Application.Identity;

    internal class JournalistRepository : DataRepository<IArticleCreationDbContext, Journalist>, IJournalistRepository
    {
        private readonly IMapper mapper;
        private readonly IJournalistFactory journalistFactory;

        public JournalistRepository(IArticleCreationDbContext db, IMapper mapper, IJournalistFactory journalistFactory)
            : base(db)
        {
            this.mapper = mapper;
            this.journalistFactory = journalistFactory;
        }

        public async Task<bool> HasArticle(int journalistId, int articleId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(j => j.Id == journalistId)
                .AnyAsync(j => j.Articles
                    .Any(c => c.Id == articleId), cancellationToken);

        public async Task<JournalistDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<JournalistDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<JournalistOutputModel> GetDetailsByArticleId(int articleId, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<JournalistOutputModel>(this
                    .All()
                    .Where(d => d.Articles.Any(c => c.Id == articleId)))
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<Journalist> Find(
            string userId,
            CancellationToken cancellationToken = default)
        { 
            var journalist = await base
                .All()
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == userId, cancellationToken);

            if (journalist is null)
            {
                return null!;
            }

            return journalist;
        }

        public async Task<Journalist> FindByUserId(
            string userId,
            CancellationToken cancellationToken = default)
        {
            var journalist = await this
                .All()
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);

            if (journalist == null)
            {
                throw new InvalidUserExceptions("This journalist was not found");
            }

            return journalist;
        }

        public async Task<bool> Existed(string userId, CancellationToken cancellationToken = default)
            => await base
                .All()
                .AnyAsync(c => c.UserId == userId, cancellationToken);

        public new async Task Save(Journalist entity, CancellationToken cancellationToken = default)
        {
            var dbEntity = this.mapper.Map<Journalist>(entity); 

            this.Data.Update(dbEntity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
