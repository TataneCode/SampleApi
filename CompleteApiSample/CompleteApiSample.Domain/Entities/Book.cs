using CompleteApiSample.Common.Enums;

namespace CompleteApiSample.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public required string Title { get; set; }

        public string Description { get; set; } = string.Empty;

        public required BookStyle Style { get; set; }

        public DateTime? WritingDate { get; set; }

        public long AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;

    }
}
