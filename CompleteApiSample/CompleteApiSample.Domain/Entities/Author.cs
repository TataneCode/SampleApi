namespace CompleteApiSample.Domain.Entities
{
    public class Author : AuditableEntity
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Book> Books { get; set; } = Array.Empty<Book>();
    }
}
