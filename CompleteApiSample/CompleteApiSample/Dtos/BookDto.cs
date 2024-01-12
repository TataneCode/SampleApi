using CompleteApiSample.Common.Enums;
using CompleteApiSample.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CompleteApiSample.Dtos
{
    public class BookDto : BaseDto
    {
        [Required, MaxLength(64)]
        public required string Title { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public required BookStyle Style { get; set; }

        public DateTime? WritingDate { get; set; }

        public AuthorDto? Author { get; set; } = null;
    }

    public static class BookMapper
    {
        public static BookDto MapToDto(this Book entity)
        {
            return new BookDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Style = entity.Style,
                WritingDate = entity.WritingDate,
                Author = entity.Author?.MapToDto(),
                UpdatedAt = entity.UpdatedAt,
            };
        }

        public static Book MapToEntity(this BookDto dto)
        {
            return new Book
            {
                Id = dto.Id,
                Style = dto.Style,
                Title = dto.Title,
                AuthorId = dto.Author?.Id ?? 0,
                Description = dto.Description,
                WritingDate = dto.WritingDate,
            };
        }
    }
}
