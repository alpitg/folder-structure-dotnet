using AutoMapper;
using Structure.Data.Dto;
using Structure.MediatR.CommandAndQuery;

namespace Structure.Api.Helpers.Mapping
{
    /// <summary>
    /// Action Profiler
    /// </summary>
    public class ActionProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ActionProfile()
        {
            CreateMap<Domain.Entities.Action, ActionDto>().ReverseMap();
            CreateMap<AddActionCommand, Domain.Entities.Action>();
            CreateMap<UpdateActionCommand, Domain.Entities.Action>();
        }
    }
}
