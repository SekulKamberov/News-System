namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Articles;

    using static Domain.ArticleCreation.Models.ModelConstants.Common;
    using static Domain.ArticleCreation.Models.ModelConstants.Article;

    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(MaxTitleLength);

            builder
                .Property(a => a.Content)
                .IsRequired()
                .HasMaxLength(MaxContentLength);

            builder
                .Property(a => a.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            builder
                .Property(a => a.JournalistId)
                .IsRequired();

            builder
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(a => a.Comments)
                .WithOne(a => a.Article);
        }
    }
}
