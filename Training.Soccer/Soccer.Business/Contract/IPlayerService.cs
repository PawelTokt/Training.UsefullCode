using System.Collections.Generic;

namespace Soccer.Business.Contract
{
    public interface IPlayerService
    {
        IEnumerable<PlayerDto> GetListPLayers();

        PlayerDto GetPlayer(int id);

        void InsertPlayer(PlayerDto playerDto);

        void UpdatePlayer(PlayerDto playerDto);

        void DeletePlayer(int id);
    }
}