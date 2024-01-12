using System.ComponentModel.DataAnnotations;

namespace CompleteApiSample.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
