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
            CreateMap<Data.Action, ActionDto>().ReverseMap();
            CreateMap<AddActionCommand, Data.Action>();
            CreateMap<UpdateActionCommand, Data.Action>();
        }
    }
}
