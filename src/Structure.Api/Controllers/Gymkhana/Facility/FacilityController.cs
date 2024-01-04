using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Controllers
{
    /// <summary>
    /// Facility
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class FacilityController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// Facility
        /// </summary>
        /// <param name="mediator"></param>
        public FacilityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get Facility By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetFacility")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityDto))]
        public async Task<IActionResult> GetFacility(Guid id)
        {
            var getFacilityQuery = new GetFacilityQuery { Id = id };
            var result = await _mediator.Send(getFacilityQuery);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Get All Facilitys
        /// </summary>
        /// <returns>Test</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("")]
        [Produces("application/json", "application/xml", Type = typeof(List<FacilityDto>))]
        public async Task<IActionResult> GetFacilities()
        {
            var getAllFacilityQuery = new GetAllFacilityQuery { };
            var result = await _mediator.Send(getAllFacilityQuery);
            return Ok(result);
        }
        /// <summary>
        /// Create a Facility
        /// </summary>
        /// <param name="addFacilityCommand"></param>
        /// <returns></returns>
        [HttpPost("")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityDto))]
        public async Task<IActionResult> AddFacility(AddFacilityCommand addFacilityCommand)
        {
            var result = await _mediator.Send(addFacilityCommand);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetFacility", new { id = result.Data.Id }, result.Data);
        }
        /// <summary>
        /// Update Facility By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="updateFacilityCommand"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityDto))]
        public async Task<IActionResult> UpdateFacility(Guid Id, UpdateFacilityCommand updateFacilityCommand)
        {
            updateFacilityCommand.Id = Id;
            var result = await _mediator.Send(updateFacilityCommand);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Delete Facility By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFacility(Guid Id)
        {
            var deleteFacilityCommand = new DeleteFacilityCommand { Id = Id };
            var result = await _mediator.Send(deleteFacilityCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
