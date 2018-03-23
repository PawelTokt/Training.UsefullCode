using AutoMapper;
using Soccer.Data.Entities;
using Soccer.Business.Contract;

namespace Soccer.Business.Mappings
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<TeamEntity, TeamDto>();
            CreateMap<TeamDto, TeamEntity>();
            CreateMap<PlayerEntity, PlayerDto>()
                .ForMember(x => x.TeamName, opt => opt.MapFrom(src => src.TeamEntity.Name));
            CreateMap<PlayerDto, PlayerEntity>();
            CreateMap<PlayerDto, TeamEntity>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.TeamName));
        }
    }
}