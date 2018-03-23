using AutoMapper;
using Soccer.Web.Models;
using Soccer.Business.Contract;


namespace Soccer.Web.Mappings
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<TeamDto, TeamViewModel>();
            CreateMap<TeamViewModel, TeamDto>();
            CreateMap<PlayerDto, PlayerViewModel>();
            CreateMap<PlayerViewModel, PlayerDto>();
        }
    }
}