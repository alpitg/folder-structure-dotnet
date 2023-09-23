﻿using Structure.Data.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Controllers
{
    /// <summary>
    /// UserClaim
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserClaimController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// UserClaim
        /// </summary>
        /// <param name="mediator"></param>
        public UserClaimController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Update User Claim By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addUserCommand"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces("application/json", "application/xml", Type = typeof(UserClaimDto))]
        public async Task<IActionResult> UpdateUserClaim(Guid id, UpdateUserClaimCommand addUserCommand)
        {
            addUserCommand.Id = id;
            var result = await _mediator.Send(addUserCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
