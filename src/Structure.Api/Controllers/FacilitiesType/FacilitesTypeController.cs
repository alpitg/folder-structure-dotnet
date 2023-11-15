using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using Structure.MediatR.Commands;

namespace Structure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class FacilitesTypeController : BaseController
    {

        public IMediator _mediator { get; set; }

        public FacilitesTypeController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetFacilityType/{id}", Name = "GetFacilityType")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityTypeDto))]
        public async Task<IActionResult> GetFacilityType(Guid id)
        {
            var getFacilityQuery = new GetFacilityTypeQuery { Id = id };
            var result = await _mediator.Send(getFacilityQuery);
            return ReturnFormattedResponse(result);
        }

        [HttpGet("GetFacilityType")]
        [Produces("application/json", "application/xml", Type = typeof(List<FacilityTypeDto>))]
        public async Task<IActionResult> GetFacilityType()
        {
            var getAllFacilityTypeQuery = new GetAllFacilityTypeQuery { };
            var result = await _mediator.Send(getAllFacilityTypeQuery);
            return Ok(result);
        }

        [HttpPost("AddFacilityType")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityTypeDto))]
        public async Task<IActionResult> AddFacilityType(AddFacilityTypeCommands addFacilityCommands)
        {
            var result = await _mediator.Send(addFacilityCommands);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetFacilityType", new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("FacilityType/{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityTypeDto))]
        public async Task<IActionResult> UpdateFacilityType(Guid Id, UpdateFacilityTypeCommands updateFacilityTypeCommands)
        {
            updateFacilityTypeCommands.Id = Id;
            var result = await _mediator.Send(updateFacilityTypeCommands);
            return ReturnFormattedResponse(result);
        }

        [HttpDelete("FacilityType/{Id}")]
        public async Task<IActionResult> DeleteFAcilityType(Guid Id)
        {
            var deleteFacilityTypeCommands = new DeleteFacilityTypeCommands { Id = Id };
            var result = await _mediator.Send(deleteFacilityTypeCommands);
            return ReturnFormattedResponse(result);
        }

    }
}
