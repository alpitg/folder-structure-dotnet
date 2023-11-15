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
    public class FacilityController : BaseController
    {

        public IMediator _mediator { get; set; }

        public FacilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddFacility")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityDto))]
        public async Task<IActionResult> AddFacility(AddFacilityCommand addFacilityCommand)
        {
            var result = await _mediator.Send(addFacilityCommand);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("AddFacility", new { id = result.Data.Id }, result.Data);
        }

        [HttpGet("GetFacility/{id}", Name = "GetFacility")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityDto))]
        public async Task<IActionResult> GetFacility(Guid id)
        {
            var getFacilityCommand = new GetFacilityCommand { Id = id };
            var result = await _mediator.Send(getFacilityCommand);
            return ReturnFormattedResponse(result);
        }

        [HttpGet("GetAllFacility")]
        [Produces("application/json", "application/xml", Type = typeof(List<FacilityDto>))]
        public async Task<IActionResult> GetAllFacility()
        {
            var getAllFacilityCommand = new GetAllFacilityCommand { };
            var result = await _mediator.Send(getAllFacilityCommand);
            return Ok(result);
        }

        [HttpPut("Facility/{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityDto))]
        public async Task<IActionResult> UpdateFacility(Guid Id, UpdateFacilityCommand updateFacilityCommand)
        {
            updateFacilityCommand.Id = Id;
            var result = await _mediator.Send(updateFacilityCommand);
            return ReturnFormattedResponse(result);
        }

        [HttpDelete("Facility/{Id}")]
        public async Task<IActionResult> DeleteFacility(Guid Id)
        {
            var deleteFacilityCommand = new DeleteFacilityCommand{ Id = Id };
            var result = await _mediator.Send(deleteFacilityCommand);
            return ReturnFormattedResponse(result);
        }


    }
}