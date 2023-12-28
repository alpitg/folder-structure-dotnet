using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Controllers
{
    /// <summary>
    /// HolidayCalendar
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class HolidayCalendarController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// HolidayCalendar
        /// </summary>
        /// <param name="mediator"></param>
        public HolidayCalendarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get HolidayCalendar By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetHolidayCalendar")]
        [Produces("application/json", "application/xml", Type = typeof(HolidayCalendarDto))]
        public async Task<IActionResult> GetHolidayCalendar(Guid id)
        {
            var getHolidayCalendarQuery = new GetHolidayCalendarQuery { Id = id };
            var result = await _mediator.Send(getHolidayCalendarQuery);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Get All HolidayCalendars
        /// </summary>
        /// <returns>Test</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("")]
        [Produces("application/json", "application/xml", Type = typeof(List<HolidayCalendarDto>))]
        public async Task<IActionResult> GetHolidayCalendars()
        {
            var getAllHolidayCalendarQuery = new GetAllHolidayCalendarQuery { };
            var result = await _mediator.Send(getAllHolidayCalendarQuery);
            return Ok(result);
        }
        /// <summary>
        /// Create a HolidayCalendar
        /// </summary>
        /// <param name="addHolidayCalendarCommand"></param>
        /// <returns></returns>
        [HttpPost("")]
        [Produces("application/json", "application/xml", Type = typeof(HolidayCalendarDto))]
        public async Task<IActionResult> AddHolidayCalendar(AddHolidayCalendarCommand addHolidayCalendarCommand)
        {
            var result = await _mediator.Send(addHolidayCalendarCommand);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetHolidayCalendar", new { id = result.Data.Id }, result.Data);
        }
        /// <summary>
        /// Update HolidayCalendar By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="updateHolidayCalendarCommand"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(HolidayCalendarDto))]
        public async Task<IActionResult> UpdateHolidayCalendar(Guid Id, UpdateHolidayCalendarCommand updateHolidayCalendarCommand)
        {
            updateHolidayCalendarCommand.Id = Id;
            var result = await _mediator.Send(updateHolidayCalendarCommand);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Delete HolidayCalendar By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteHolidayCalendar(Guid Id)
        {
            var deleteHolidayCalendarCommand = new DeleteHolidayCalendarCommand { Id = Id };
            var result = await _mediator.Send(deleteHolidayCalendarCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
