﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.CommandAndQuery;
using Structure.Repository.UnitOfWork;
using Structure.Repository;
using Microsoft.EntityFrameworkCore;
using Structure.Data;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace Structure.MediatR.Handlers
{
    public class AddTenantCommandHandler : IRequestHandler<AddTenantCommand, ServiceResponse<TenantDto>>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork<StructureDbContext> _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddTenantCommandHandler> _logger;
        public IMediator _mediator { get; set; }

        private readonly UserManager<User> _userManager;
        private readonly UserInfoToken _userInfoToken;


        public AddTenantCommandHandler(
           ITenantRepository tenantRepository,
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            ILogger<AddTenantCommandHandler> logger,
            IMediator mediator,

            UserManager<User> userManager,
            UserInfoToken userInfoToken
            )
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _uow = uow;
            _logger = logger;
            _mediator = mediator;

            _userManager = userManager;
            _userInfoToken = userInfoToken;
        }

        public async Task<ServiceResponse<TenantDto>> Handle(AddTenantCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _tenantRepository.FindBy(c => c.TenancyName == request.TenancyName).FirstOrDefaultAsync();
            if (existingEntity != null)
            {
                _logger.LogError("Tenancy name already exist.");
                return ServiceResponse<TenantDto>.Return409("Tenancy name already exist.");
            }

            #region Add tenant details

            var entity = _mapper.Map<Tenant>(request);
            entity.Id = Guid.NewGuid();
            _tenantRepository.Add(entity);

            if (await _uow.SaveAsync() <= 0)
            {
                _logger.LogError("Save Tenant have Error.");
                return ServiceResponse<TenantDto>.Return500();
            }

            #endregion

            #region Add Admin User

            UserDto userRequest = new UserDto()
            {

                UserName = request.TenancyName,
                Email = request.Email,
                FirstName = request.Name,
                LastName = "",
                PhoneNumber = "",
                IsActive = request.IsActive,
                ShouldChangePasswordOnNextLogin = request.ShouldChangePasswordOnNextLogin,
                Address = request.Address ?? "",

                TenantId = entity.Id,
                UserRoles = new List<UserRoleDto>()
                {
                   new UserRoleDto{ UserId = null, RoleId = new Guid("f8b6ace9-a625-4397-bdf8-f34060dbd8e4")}
                }
            };

            //try
            //{

            //    var appUser = await _userManager.FindByNameAsync(request.Email);
            //    if (appUser != null)
            //    {
            //        _logger.LogError("Email already exist for another user.");
            //        return ServiceResponse<TenantDto>.Return409("Email already exist for another user.");
            //    }
            //    request.Password = CommonUtil.GenerateRandomPassword();

            //    var userEntity = _mapper.Map<User>(userRequest);
            //    userEntity.FirstName = request.TenancyName;
            //    userEntity.LastName = request.TenancyName;
            //    userEntity.PhoneNumber = "";
            //    userEntity.Address = request.Address;
            //    userEntity.IsActive = request.IsActive;
            //    userEntity.CreatedBy = Guid.Parse(_userInfoToken.Id);
            //    userEntity.ModifiedBy = Guid.Parse(_userInfoToken.Id);
            //    userEntity.CreatedDate = DateTime.UtcNow;
            //    userEntity.ModifiedDate = DateTime.UtcNow;
            //    userEntity.Id = Guid.NewGuid();

            //    IdentityResult result = await _userManager.CreateAsync(userEntity);
            //    if (!result.Succeeded)
            //    {
            //        return ServiceResponse<TenantDto>.Return500();
            //    }

            //    if (!string.IsNullOrEmpty(request.Password))
            //    {
            //        string code = await _userManager.GeneratePasswordResetTokenAsync(userEntity);
            //        IdentityResult passwordResult = await _userManager.ResetPasswordAsync(userEntity, code, request.Password);
            //        if (!passwordResult.Succeeded)
            //        {
            //            return ServiceResponse<TenantDto>.Return500();
            //        }
            //    }

            //}
            //catch (Exception e)
            //{
            //    _logger.LogError("Failed to save tenant admin user detail.");
            //    return ServiceResponse<TenantDto>.ReturnException(new Exception("Failed to save tenant admin user detail."));
            //}


            #endregion


            return ServiceResponse<TenantDto>.ReturnResultWith200(_mapper.Map<TenantDto>(entity));
        }
    }
}
