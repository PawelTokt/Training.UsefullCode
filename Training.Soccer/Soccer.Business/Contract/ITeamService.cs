using System.Collections.Generic;

namespace Soccer.Business.Contract
{
    public interface ITeamService
    {
        IEnumerable<TeamDto> GetListTeams();

        TeamDto GetTeam(int id);

        void InsertTeam(TeamDto teamDto);

        void UpdateTeam(TeamDto teamDto);

        void DeleteTeam(int id);
    }
}