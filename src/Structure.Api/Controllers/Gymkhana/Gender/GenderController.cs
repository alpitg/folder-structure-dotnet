using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Controllers
{
    /// <summary>
    /// Gender
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class GenderController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        /// <param name="mediator"></param>
        public GenderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get Gender By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGender")]
        [Produces("application/json", "application/xml", Type = typeof(GenderDto))]
        public async Task<IActionResult> GetGender(Guid id)
        {
            var getGenderQuery = new GetGenderQuery { Id = id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Get All Genders
        /// </summary>
        /// <returns>Test</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet("")]
        [Produces("application/json", "application/xml", Type = typeof(List<GenderDto>))]
        public async Task<IActionResult> GetGenders()
        {
            var getAllGenderQuery = new GetAllGenderQuery { };
            var result = await _mediator.Send(getAllGenderQuery);
            return Ok(result);
        }
        /// <summary>
        /// Create a Gender
        /// </summary>
        /// <param name="addGenderCommand"></param>
        /// <returns></returns>
        [HttpPost("")]
        [Produces("application/json", "application/xml", Type = typeof(GenderDto))]
        public async Task<IActionResult> AddGender(AddGenderCommand addGenderCommand)
        {
            var result = await _mediator.Send(addGenderCommand);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetGender", new { id = result.Data.Id }, result.Data);
        }
        /// <summary>
        /// Update Gender By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="updateGenderCommand"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(GenderDto))]
        public async Task<IActionResult> UpdateGender(Guid Id, UpdateGenderCommand updateGenderCommand)
        {
            updateGenderCommand.Id = Id;
            var result = await _mediator.Send(updateGenderCommand);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Delete Gender By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGender(Guid Id)
        {
            var deleteGenderCommand = new DeleteGenderCommand { Id = Id };
            var result = await _mediator.Send(deleteGenderCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
