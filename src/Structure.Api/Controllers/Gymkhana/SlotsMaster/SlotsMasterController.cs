using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Controllers
{
    /// <summary>
    /// SlotsMaster
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class SlotsMasterController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// SlotsMaster
        /// </summary>
        /// <param name="mediator"></param>
        public SlotsMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get SlotsMaster By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSlotsMaster")]
        [Produces("application/json", "application/xml", Type = typeof(SlotsMasterDto))]
        public async Task<IActionResult> GetSlotsMaster(Guid id)
        {
            var getSlotsMasterQuery = new GetSlotsMasterQuery { Id = id };
            var result = await _mediator.Send(getSlotsMasterQuery);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Get All SlotsMasters
        /// </summary>
        /// <returns>Test</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("")]
        [Produces("application/json", "application/xml", Type = typeof(List<SlotsMasterDto>))]
        public async Task<IActionResult> GetSlotsMasters()
        {
            var getAllSlotsMasterQuery = new GetAllSlotsMasterQuery { };
            var result = await _mediator.Send(getAllSlotsMasterQuery);
            return Ok(result);
        }
        /// <summary>
        /// Create a SlotsMaster
        /// </summary>
        /// <param name="addSlotsMasterCommand"></param>
        /// <returns></returns>
        [HttpPost("")]
        [Produces("application/json", "application/xml", Type = typeof(SlotsMasterDto))]
        public async Task<IActionResult> AddSlotsMaster(AddSlotsMasterCommand addSlotsMasterCommand)
        {
            var result = await _mediator.Send(addSlotsMasterCommand);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSlotsMaster", new { id = result.Data.Id }, result.Data);
        }
        /// <summary>
        /// Update SlotsMaster By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="updateSlotsMasterCommand"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(SlotsMasterDto))]
        public async Task<IActionResult> UpdateSlotsMaster(Guid Id, UpdateSlotsMasterCommand updateSlotsMasterCommand)
        {
            updateSlotsMasterCommand.Id = Id;
            var result = await _mediator.Send(updateSlotsMasterCommand);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Delete SlotsMaster By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSlotsMaster(Guid Id)
        {
            var deleteSlotsMasterCommand = new DeleteSlotsMasterCommand { Id = Id };
            var result = await _mediator.Send(deleteSlotsMasterCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
