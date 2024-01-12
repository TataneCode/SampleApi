using CompleteApiSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompleteApiSample.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Description).HasMaxLength(1024).HasDefaultValue(string.Empty);
            builder.HasOne(p => p.Author).WithMany(a => a.Books).HasForeignKey(p => p.AuthorId);
        }
    }
}
