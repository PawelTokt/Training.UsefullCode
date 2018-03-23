using AutoMapper;
using Soccer.Data.Entities;
using Soccer.Data.Interfaces;
using Soccer.Business.Contract;
using System.Collections.Generic;

namespace Soccer.Business
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TeamDto> GetListTeams()
        {
            return Mapper.Map<IEnumerable<TeamEntity>, List<TeamDto>>(_unitOfWork.TeamRepository.GetList());
        }

        public TeamDto GetTeam(int id)
        {
            return Mapper.Map<TeamEntity, TeamDto>(_unitOfWork.TeamRepository.GetById(id));
        }

        public void InsertTeam(TeamDto teamDto)
        {
            var teamEntity = Mapper.Map<TeamDto, TeamEntity>(teamDto);

            _unitOfWork.TeamRepository.Insert(teamEntity);

            _unitOfWork.Save();
        }

        public void UpdateTeam(TeamDto teamDto)
        {
            var team = Mapper.Map<TeamDto, TeamEntity>(teamDto);

            _unitOfWork.TeamRepository.Update(team);

            _unitOfWork.Save();
        }

        public void DeleteTeam(int id)
        {
            _unitOfWork.TeamRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}