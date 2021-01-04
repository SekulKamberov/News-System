namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Articles;
    using static Domain.ArticleCreation.Models.ModelConstants.Comment;
    using Infrastructure.Identity;

    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(MaxTitleLength);

            builder
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(MaxContentLength);

            builder
                .Property(c => c.CreatedBy)
                .IsRequired();

            builder
                .HasOne(typeof(User))
                .WithMany("Comments")
                .HasForeignKey("CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Article)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ArticleId);
        }
    }
}

