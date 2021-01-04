namespace NewsSystem.Infrastructure.Statistics.Configuration
{ 
    using Domain.Statistics.Models;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class ArticleViewConfiguration : IEntityTypeConfiguration<ArticleView>
    {
        public void Configure(EntityTypeBuilder<ArticleView> builder)
        {
            builder
                .HasKey(cav => cav.Id);

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Article>()
                .WithMany()
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
