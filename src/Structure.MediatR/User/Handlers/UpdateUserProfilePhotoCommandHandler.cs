using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Structure.Repository.UnitOfWork;
using Structure.Data;
using Structure.Data.Dto;
using Structure.Domain;
using Structure.Helper;
using Structure.MediatR.CommandAndQuery;

namespace Structure.MediatR.Handlers
{
    public class UpdateUserProfilePhotoCommandHandler : IRequestHandler<UpdateUserProfilePhotoCommand, ServiceResponse<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        IUnitOfWork<StructureDbContext> _uow;
        private UserInfoToken _userInfoToken;
        private readonly ILogger<UpdateUserProfileCommandHandler> _logger;
        public readonly PathHelper _pathHelper;
        private readonly IHostEnvironment _webHostEnvironment;
        public UpdateUserProfilePhotoCommandHandler(
            IMapper mapper,
            IUnitOfWork<StructureDbContext> uow,
            UserInfoToken userInfoToken,
            UserManager<User> userManager,
            ILogger<UpdateUserProfileCommandHandler> logger,
            PathHelper pathHelper,
            IHostEnvironment webHostEnvironment
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _uow = uow;
            _userInfoToken = userInfoToken;
            _logger = logger;
            _pathHelper = pathHelper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ServiceResponse<UserDto>> Handle(UpdateUserProfilePhotoCommand request, CancellationToken cancellationToken)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, _pathHelper.UserProfilePath);
            var appUser = await _userManager.FindByIdAsync(_userInfoToken.Id);
            if (appUser == null)
            {
                _logger.LogError("User does not exist.");
                return ServiceResponse<UserDto>.Return409("User does not exist.");
            }
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            // delete existing file
            if (!string.IsNullOrWhiteSpace(appUser.ProfilePhoto))
            {
                if (File.Exists(Path.Combine(filePath, appUser.ProfilePhoto)))
                {
                    File.Delete(Path.Combine(filePath, appUser.ProfilePhoto));
                }
            }

            // save new file
            if (request.FormFile.Any())
            {
                var profileFile = request.FormFile[0];
                var newProfilePhoto = $"{Guid.NewGuid()}{Path.GetExtension(profileFile.Name)}";
                string fullPath = Path.Combine(filePath, newProfilePhoto);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    profileFile.CopyTo(stream);
                }
                appUser.ProfilePhoto = newProfilePhoto;
            }
            else
            {
                appUser.ProfilePhoto = "";
            }

            // update user
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
