namespace NewsSystem.Infrastructure.Identity.Configuration
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(a => a.Comments)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("comments");
        }
    }
}
