using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Soccer.Business.Contract;
using Soccer.Web.Models;

namespace Soccer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public HomeController(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        public ActionResult IndexTeams()
        {
            var teams = Mapper.Map<IEnumerable<TeamDto>, List<TeamViewModel>>(_teamService.GetListTeams());

            return View(teams);
        }

        public ActionResult IndexPlayers()
        {
            var players = Mapper.Map<IEnumerable<PlayerDto>, List<PlayerViewModel>>(_playerService.GetListPLayers());

            return View(players);
        }

        public ActionResult InsertTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertTeam(TeamViewModel teamViewModel)
        {
            if (ModelState.IsValid)
            {
                var team = Mapper.Map<TeamViewModel, TeamDto>(teamViewModel);

                _teamService.InsertTeam(team);

                return RedirectToAction("IndexTeams");
            }

            return View(teamViewModel);
        }

        public ActionResult InsertPlayer()
        {
            SelectList teams = new SelectList(_teamService.GetListTeams(), "Name", "Name");

            ViewBag.Teams = teams;

            return View();
        }

        [HttpPost]
        public ActionResult InsertPlayer(PlayerViewModel playerViewModel)
        {
            if (ModelState.IsValid)
            {
                var player = Mapper.Map<PlayerViewModel, PlayerDto>(playerViewModel);

                _playerService.InsertPlayer(player);

                return RedirectToAction("IndexPlayers");
            }

            return View(playerViewModel);
        }

        public ActionResult UpdateTeam(int id)
        {

            var teamViewModel = Mapper.Map<TeamDto, TeamViewModel>(_teamService.GetTeam(id));

            return View(teamViewModel);
        }

        [HttpPost]
        public ActionResult UpdateTeam(TeamViewModel teamViewModel)
        {
            if (ModelState.IsValid)
            {
                var team = Mapper.Map<TeamViewModel, TeamDto>(teamViewModel);

                _teamService.UpdateTeam(team);

                return RedirectToAction("IndexTeams");
            }

            return View(teamViewModel);
        }

        public ActionResult UpdatePlayer(int id)
        {
            var playerViewModel = Mapper.Map<PlayerDto, PlayerViewModel>(_playerService.GetPlayer(id));

            SelectList teams = new SelectList(_teamService.GetListTeams(), "Name", "Name");

            ViewBag.Teams = teams;

            return View(playerViewModel);
        }

        [HttpPost]
        public ActionResult UpdatePlayer(PlayerViewModel playerViewModel)
        {
            if (ModelState.IsValid)
            {
                var playerDto = Mapper.Map<PlayerViewModel, PlayerDto>(playerViewModel);

                _playerService.UpdatePlayer(playerDto);

                return RedirectToAction("IndexPlayers");
            }
            return View(playerViewModel);
        }


        public ActionResult DeleteTeam(int id)
        {
            var teamModel = Mapper.Map<TeamDto, TeamViewModel>(_teamService.GetTeam(id));

            if (teamModel != null)
            {
                return View(teamModel);
            }

            return RedirectToAction("IndexTeams");
        }

        [HttpPost, ActionName("DeleteTeam")]
        public ActionResult DeleteTeamConfirmed(int id)
        {
            var teamModel = Mapper.Map<TeamDto, TeamViewModel>(_teamService.GetTeam(id));

            if (teamModel == null)
            {
                return HttpNotFound();
            }

            _teamService.DeleteTeam(id);

            return RedirectToAction("IndexTeams");
        }

        public ActionResult DeletePlayer(int id)
        {
            var playerModel = Mapper.Map<PlayerDto, PlayerViewModel>(_playerService.GetPlayer(id));

            if (playerModel != null)
            {
                return View(playerModel);
            }

            return RedirectToAction("IndexPlayers");
        }

        [HttpPost, ActionName("DeletePlayer")]
        public ActionResult DeletePlayerConfirmed(int id)
        {
            var playerModel = Mapper.Map<PlayerDto, PlayerViewModel>(_playerService.GetPlayer(id));

            if (playerModel == null)
            {
                return HttpNotFound();
            }

            _playerService.DeletePlayer(id);

            return RedirectToAction("IndexPlayers");
        }
    }
}