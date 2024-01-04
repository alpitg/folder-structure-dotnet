using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.Commands;

namespace Structure.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HolidayCalenderController : BaseController
    {

        public IMediator _mediator { get; set; }

        public HolidayCalenderController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddHolidayCalender")]
        [Produces("application/json", "application/xml", Type = typeof(HolidayCalenderDto))]
        public async Task<IActionResult> AddHolidayCalender(AddHolidayCalenderCommands addHolidayCalenderCommands)
        {
            var result = await _mediator.Send(addHolidayCalenderCommands);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("AddHolidayCalender", new { id = result?.Data?.Id }, result?.Data);
        }


        [HttpGet("GetAllHolidayCalender")]
        [Produces("application/json", "application/xml", Type = typeof(List
            <HolidayCalenderDto>))]
        public async Task<IActionResult> GetAllHolidayCalender()
        {
            //try
            //{
                var getAllHolidayCalender = new GetAllHolidayCalenderCommands { };
                var result = await _mediator.Send(getAllHolidayCalender);
                return Ok(result);

            //}
            //catch
            //{
            //    return BadRequest("hdbvh");
            //}
        }

}
}
