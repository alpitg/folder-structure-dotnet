﻿using AutoMapper;
using Structure.Common.UnitOfWork;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.MediatR.CommandAndQuery;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Structure.Helper;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Structure.MediatR.Handlers
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, ServiceResponse<UserDto>>
    {
        private readonly UserManager<User> _userManager;
        IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private UserInfoToken _userInfoToken;
        private readonly ILogger<UpdateUserProfileCommandHandler> _logger;
        public readonly PathHelper _pathHelper;
        public UpdateUserProfileCommandHandler(
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            UserInfoToken userInfoToken,
            UserManager<User> userManager,
            ILogger<UpdateUserProfileCommandHandler> logger,
            PathHelper pathHelper
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _uow = uow;
            _userInfoToken = userInfoToken;
            _logger = logger;
            _pathHelper = pathHelper;
        }

        public async Task<ServiceResponse<UserDto>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByIdAsync(_userInfoToken.Id);
            if (appUser == null)
            {
                _logger.LogError("User does not exist.");
                return ServiceResponse<UserDto>.Return409("User does not exist.");
            }
            appUser.FirstName = request.FirstName;
            appUser.LastName = request.LastName;
            appUser.PhoneNumber = request.PhoneNumber;
            appUser.Address = request.Address;
            IdentityResult result = await _userManager.UpdateAsync(appUser);
            if (await _uow.SaveAsync() <= 0 && !result.Succeeded)
            {
                return ServiceResponse<UserDto>.Return500();
            }
            if (!string.IsNullOrWhiteSpace(appUser.ProfilePhoto))
                appUser.ProfilePhoto = Path.Combine(_pathHelper.UserProfilePath, appUser.ProfilePhoto);
            return ServiceResponse<UserDto>.ReturnResultWith200(_mapper.Map<UserDto>(appUser));
        }
    }

}
