using CompleteApiSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompleteApiSample.Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(64);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(64);
        }
    }
}
