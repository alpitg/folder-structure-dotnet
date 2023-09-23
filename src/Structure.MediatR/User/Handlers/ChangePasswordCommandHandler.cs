﻿using Structure.Data;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Structure.Helper;
using Microsoft.Extensions.Logging;

namespace Structure.MediatR.Handlers
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ServiceResponse<UserDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<ChangePasswordCommandHandler> _logger;
        public ChangePasswordCommandHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<ChangePasswordCommandHandler> logger
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<ServiceResponse<UserDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return ServiceResponse<UserDto>.ReturnFailed(404, "UserName not found.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.OldPassword, false);
            if (!result.Succeeded)
            {
                _logger.LogError("Old Password does not match.");
                return ServiceResponse<UserDto>.ReturnFailed(422, "Old Password does not match.");
            }

            var entity = await _userManager.FindByNameAsync(request.UserName);
            string code = await _userManager.GeneratePasswordResetTokenAsync(entity);
            IdentityResult passwordResult = await _userManager.ResetPasswordAsync(entity, code, request.NewPassword);
            if (!passwordResult.Succeeded)
            {
                return ServiceResponse<UserDto>.Return500();
            }
            return ServiceResponse<UserDto>.ReturnSuccess();
        }
    }
}
