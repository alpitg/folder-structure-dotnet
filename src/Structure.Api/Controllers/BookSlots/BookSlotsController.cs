using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.Commands;

namespace Structure.Api.Controllers.BookSlots
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookSlotsController : BaseController
    {

        public IMediator _mediatore { get; set; }

        public BookSlotsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddBookSlots")]
        [Produces("application/json", "application/xml", Type = typeof(BookSlotDto))]
        public async Task<IActionResult> AddBookSlots(AddBookSlots addBookSlots)
        {
            var result = await _mediator.Send(addBookSlots);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);

            }
            return CreatedAtAction("GetBookSlots", new { id = result?.Data?.Id }, result?.Data);

        }

        [HttpGet("GetBookSlots")]
        [Produces("application/json", "application/xml", Type = typeof(List<BookSlotDto>))]
        public async Task<IActionResult> GetALlBookSlots()
        {
            var getAllBookSlots = new GetAllBookSlots { };
            var result = await _mediator.Send(getAllBookSlots);
            return Ok(result);
        }
    }
}
