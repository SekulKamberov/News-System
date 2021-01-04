namespace NewsSystem.Infrastructure.Common.Persistence
{
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Identity;
    using Events;
    using Infrastructure.ArticleCreation;
    using Infrastructure.Statistics;

    using Domain.Statistics.Models;
    using Domain.ArticleCreation.Models.Articles;
    using Domain.ArticleCreation.Models.Journalists;
    using Domain.Common.Models;

    internal class NewsDbContext : IdentityDbContext<User>,
        IArticleCreationDbContext,
        IStatisticsDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private bool eventsDispatched;

        public NewsDbContext(
            DbContextOptions<NewsDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.eventsDispatched = false;
        }

        public DbSet<Article> Articles { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Comment> Comments { get; set; } = default!;

        public DbSet<Journalist> Journalists { get; set; } = default!;

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public DbSet<ArticleView> ArticleViews { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entriesModified = 0;

            if (!this.eventsDispatched)
            {
                var entities = this.ChangeTracker
                    .Entries<IEntity>()
                    .Select(e => e.Entity)
                    .Where(e => e.Events.Any())
                    .ToArray();

                foreach (var entity in entities)
                {
                    var events = entity.Events.ToArray();

                    entity.ClearEvents();

                    foreach (var domainEvent in events)
                    {
                        await this.eventDispatcher.Dispatch(domainEvent);
                    }
                }

                this.eventsDispatched = true;

                entriesModified = await base.SaveChangesAsync(cancellationToken);
            }

            return entriesModified;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
