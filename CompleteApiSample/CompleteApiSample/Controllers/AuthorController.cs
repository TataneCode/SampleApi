using CompleteApiSample.Domain.Services;
using CompleteApiSample.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CompleteApiSample.Controllers
{
    [Route("author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(
            IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var entity = await _authorService.GetAsync(id);
            var result = entity?.MapToDto();

            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(ICollection<AuthorDto>))]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            var model = await _authorService.GetAllPaginatedAsync(pageNumber, pageSize);
            var result = model.PaginatedEntities.Select(x => x.MapToDto());

            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(200)]
        public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorDto dto)
        {
            var entity = dto.MapToEntity();
            await _authorService.CreateAsync(entity);

            return Ok();
        }

        [HttpPut()]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorDto dto)
        {
            var entity = dto.MapToEntity();
            await _authorService.UpdateAsync(entity);

            return Ok();
        }
    }
}
