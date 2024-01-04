using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Controllers
{
    /// <summary>
    /// FacilityType
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class FacilityTypeController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// FacilityType
        /// </summary>
        /// <param name="mediator"></param>
        public FacilityTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get FacilityType By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetFacilityType")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityTypeDto))]
        public async Task<IActionResult> GetFacilityType(Guid id)
        {
            var getFacilityTypeQuery = new GetFacilityTypeQuery { Id = id };
            var result = await _mediator.Send(getFacilityTypeQuery);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Get All FacilityTypes
        /// </summary>
        /// <returns>Test</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("FacilityTypes")]
        [Produces("application/json", "application/xml", Type = typeof(List<FacilityTypeDto>))]
        public async Task<IActionResult> GetFacilities()
        {
            var getAllFacilityTypeQuery = new GetAllFacilityTypeQuery { };
            var result = await _mediator.Send(getAllFacilityTypeQuery);
            return Ok(result);
        }
        /// <summary>
        /// Create a FacilityType
        /// </summary>
        /// <param name="addFacilityTypeCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json", "application/xml", Type = typeof(FacilityTypeDto))]
        public async Task<IActionResult> AddFacilityType(AddFacilityTypeCommand addFacilityTypeCommand)
        {
            var result = await _mediator.Send(addFacilityTypeCommand);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("AddFacilityType", new { id = result.Data.Id }, result.Data);
        }
        /// <summary>
        /// Update FacilityType By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="updateFacilityCommand"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(FacilityTypeDto))]
        public async Task<IActionResult> UpdateFacility(Guid Id, UpdateFacilityTypeCommand updateFacilityTypeCommand)
        {
            updateFacilityTypeCommand.Id = Id;
            var result = await _mediator.Send(updateFacilityTypeCommand);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Delete FacilityType By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFacility(Guid Id)
        {
            var deleteFacilityTypeCommand = new DeleteFacilityTypeCommand { Id = Id };
            var result = await _mediator.Send(deleteFacilityTypeCommand);
            return ReturnFormattedResponse(result);
        }
    }
}