namespace NewsSystem.Infrastructure.Statistics.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.Statistics.Models;

    public class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            const string id = "Id";

            builder
                .Property<int>(id);

            builder
                .HasKey(id);

            builder
                .HasMany(a => a.ArticleViews)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("articleViews");
        }
    }
}
