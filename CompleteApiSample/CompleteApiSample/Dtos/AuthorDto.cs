using CompleteApiSample.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CompleteApiSample.Dtos
{
    public class AuthorDto : BaseDto
    {
        [Required, MaxLength(64, ErrorMessage = "First name must not exceed 64 characters.")]
        public required string FirstName { get; set; }

        [Required, MaxLength(64, ErrorMessage = "Last name must not exceed 64 characters.")]
        public required string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<BookDto> Books { get; set; } = Array.Empty<BookDto>();
    }

    public static class AuthorMapper
    {
        public static AuthorDto MapToDto(this Author entity)
        {
            return new AuthorDto
            {
                Id = entity.Id,
                UpdatedAt = entity.UpdatedAt,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
                Books = entity.Books.Select(x => x.MapToDto()).ToArray(),
            };
        }

        public static Author MapToEntity(this AuthorDto dto)
        {
            return new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Id = dto.Id,
                Books = dto.Books.Select(x => x.MapToEntity()).ToArray(),
            };
        }
    }
}
