namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Journalists;
    using Domain.ArticleCreation.Models;

    internal class JournalistConfiguration : IEntityTypeConfiguration<Journalist>
    {
        public void Configure(EntityTypeBuilder<Journalist> builder)
        {
            builder
                .HasKey(j => j.Id);

            builder
                .Property(j => j.NickName)
                .IsRequired(); 

            builder
                .OwnsOne(c => c.Address, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.Value);  
                });


            builder
                .OwnsOne(c => c.PhoneNumber, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.Number);
                }); 

            builder
                .Property(j => j.UserId)
                .IsRequired();

            builder
                .HasMany(j => j.Articles)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("articles");
        }
    }
}
