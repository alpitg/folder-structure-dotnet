using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Controllers
{
    /// <summary>
    /// Tenant
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TenantController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// Tenant
        /// </summary>
        /// <param name="mediator"></param>
        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get Tenant By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTenant")]
        [Produces("application/json", "application/xml", Type = typeof(TenantDto))]
        public async Task<IActionResult> GetTenant(Guid id)
        {
            var getTenantQuery = new GetTenantQuery { Id = id };
            var result = await _mediator.Send(getTenantQuery);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Get All Tenants
        /// </summary>
        /// <returns>Test</returns>
        /// <response code="200">Returns the newly created item</response>
        [HttpGet]
        [Produces("application/json", "application/xml", Type = typeof(List<TenantDto>))]
        public async Task<IActionResult> GetTenants()
        {
            var getAllTenantQuery = new GetAllTenantQuery { };
            var result = await _mediator.Send(getAllTenantQuery);
            return Ok(result);
        }
        /// <summary>
        /// Create a Tenant
        /// </summary>
        /// <param name="addTenantCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json", "application/xml", Type = typeof(TenantDto))]
        public async Task<IActionResult> AddTenant(AddTenantCommand addTenantCommand)
        {
            var result = await _mediator.Send(addTenantCommand);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetTenant", new { id = result.Data.Id }, result.Data);
        }
        /// <summary>
        /// Update Tenant By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="updateTenantCommand"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Produces("application/json", "application/xml", Type = typeof(TenantDto))]
        public async Task<IActionResult> UpdateTenant(Guid Id, UpdateTenantCommand updateTenantCommand)
        {
            updateTenantCommand.Id = Id;
            var result = await _mediator.Send(updateTenantCommand);
            return ReturnFormattedResponse(result);
        }
        /// <summary>
        /// Delete Tenant By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTenant(Guid Id)
        {
            var deleteTenantCommand = new DeleteTenantCommand { Id = Id };
            var result = await _mediator.Send(deleteTenantCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
