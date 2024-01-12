using CompleteApiSample.Domain.Services;
using CompleteApiSample.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CompleteApiSample.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(
            IBookService authorService)
        {
            _bookService = authorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var entity = await _bookService.GetAsync(id);
            var result = entity?.MapToDto();

            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            var model = await _bookService.GetAllPaginatedAsync(pageNumber, pageSize);
            var result = model.PaginatedEntities.Select(x => x.MapToDto());

            return Ok(result);
        }


        [HttpPost()]
        public async Task<IActionResult> AddAuthorAsync([FromBody] BookDto dto)
        {
            var entity = dto.MapToEntity();
            await _bookService.CreateAsync(entity);

            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] BookDto dto)
        {
            var entity = dto.MapToEntity();
            await _bookService.UpdateAsync(entity);

            return Ok();
        }
    }
}
