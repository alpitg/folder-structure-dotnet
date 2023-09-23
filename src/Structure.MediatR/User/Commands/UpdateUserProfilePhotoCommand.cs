using MediatR;
using Microsoft.AspNetCore.Http;
using Structure.Data.Dto;
using Structure.Helper;

namespace Structure.MediatR.CommandAndQuery
{
    public class UpdateUserProfilePhotoCommand : IRequest<ServiceResponse<UserDto>>
    {
        public IFormFileCollection FormFile { get; set; }
    }
}
