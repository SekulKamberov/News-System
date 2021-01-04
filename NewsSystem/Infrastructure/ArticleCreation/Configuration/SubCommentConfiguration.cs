namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Articles;
    using static Domain.ArticleCreation.Models.ModelConstants.Comment;
    using Infrastructure.Identity;

    internal class SubCommentConfiguration : IEntityTypeConfiguration<SubComment>
    {
        public void Configure(EntityTypeBuilder<SubComment> builder)
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
                .HasOne(c => c.Comment)
                .WithMany(c => c.SubComments)
                .HasForeignKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.Restrict);  


        }
    }
}
