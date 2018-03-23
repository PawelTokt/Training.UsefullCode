using AutoMapper;
using Soccer.Data.Entities;
using Soccer.Data.Interfaces;
using Soccer.Business.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Business
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PlayerDto> GetListPLayers()
        {
            return Mapper.Map<IEnumerable<PlayerEntity>, List<PlayerDto>>(_unitOfWork.PlayerRepository.GetList());
        }

        public PlayerDto GetPlayer(int id)
        {
           return Mapper.Map<PlayerEntity, PlayerDto>(_unitOfWork.PlayerRepository.GetById(id));
        }

        public void InsertPlayer(PlayerDto playerDto)
        {
            var player = Mapper.Map<PlayerDto, PlayerEntity>(playerDto);

            var team = _unitOfWork.TeamRepository.GetList().FirstOrDefault(x => x.Name == playerDto.TeamName);

            _unitOfWork.TeamRepository.Update(team);

            team.Players.Add(player);

            _unitOfWork.Save();
        }

        public void UpdatePlayer(PlayerDto playerDto)
        {
            var player = _unitOfWork.PlayerRepository.GetById(playerDto.Id);

            var team = _unitOfWork.TeamRepository.GetList().FirstOrDefault(x => x.Name == playerDto.TeamName);

            player.TeamEntity = team;
            player.Name = playerDto.Name;
            player.Position = playerDto.Position;

            _unitOfWork.PlayerRepository.Update(player);

            _unitOfWork.Save();
        }

        public void DeletePlayer(int id)
        {
            _unitOfWork.PlayerRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}