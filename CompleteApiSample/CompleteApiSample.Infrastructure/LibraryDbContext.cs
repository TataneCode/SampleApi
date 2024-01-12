using CompleteApiSample.Domain.Entities;
using CompleteApiSample.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CompleteApiSample.Infrastructure
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        /// <summary>
        /// Création du modèle
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
