using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.MediatR.Commands;

namespace Structure.Api.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class FacilityCourtController : BaseController 
    {

        public IMediator _mediator { get; set; }

        public FacilityCourtController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        [Produces("application/json", "application/xml", Type = typeof(FacilityCourtsDto))]
        public async Task<IActionResult> AddFacilityCourt(AddFacilityCourtsCommands addFacilityCourtsCommands)
        {
            var result = await _mediator.Send(addFacilityCourtsCommands);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("AddFacilityCourt", new { id = result.Data.Id },result.Data);
        }

        [HttpGet("FacilityCourt/{id}", Name = "GetFacilityCourt")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityCourtsDto))]
        public async Task<IActionResult> GetFacilityCourt(Guid id)
        {
            var getFacilityCourtCommand = new GetFacilityCourtCommand { Id = id };
            var result = await _mediator.Send(getFacilityCourtCommand);
            return ReturnFormattedResponse(result);
        }

        [HttpGet("GetFacilityCourt")]
        [Produces("application/json", "application/xml", Type = typeof(List<FacilityCourtsDto>))]
        public async Task<IActionResult> GetFacilityCourt()
        {
            var getAllFacilityCourtCommand = new GetAllFacilityCourtCommand { };
            var result = await _mediator.Send(getAllFacilityCourtCommand);
            return Ok(result);
        }

        [HttpPut("FacilityCourt/{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityCourtsDto))]
        public async Task<IActionResult> UpdateFacilityCourt(Guid Id, UpdateFacilityCourtCommand updateFacilityCourtCommand)
        {
            updateFacilityCourtCommand.Id = Id;
            var result = await _mediator.Send(updateFacilityCourtCommand);
            return ReturnFormattedResponse(result);
        }

        [HttpDelete("FacilityCourt/{Id}")]
        public async Task<IActionResult> DeleteFacilityCourt(Guid Id)
        {
            var deleteFacilityCourtCommand = new DeleteFacilityCourtCommand { Id = Id };
            var result = await _mediator.Send(deleteFacilityCourtCommand);
            return ReturnFormattedResponse(result);
        }

    }
}
