using CounterApp.Api.Services;
using CounterApp.App.Pages;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CounterApp.Api.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IGameService _gameService;

        public PlayerController(IGameService gameService)
        {
            _gameService = gameService;
        }

        //GET
        [HttpGet("{id}")]
        public IActionResult GetAllPlayers(int id)
        {
            var list = _gameService.GetAllPlayers(id);
            if (list == null)
            {
                ModelState.AddModelError("Players", "There are currently no players added to the game");
            }

            return Ok(list);
        }

        //POST
        [HttpPost("{id}")]
        public IActionResult CreatePlayer([FromBody] Player player, int id)
        {
            if (player == null)
            {
                return BadRequest();
            }

            if (String.IsNullOrWhiteSpace(player.Name))
            {
                ModelState.AddModelError("Player", "Enter name of the player");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPlayer = _gameService.AddPlayer(player, id);

            return Created("player", createdPlayer);
        }
        
        //PATCH
        [HttpPatch("{gameId}")]
        public IActionResult UpdatePlayersPoints(int gameId,Player player)
        {
            if(gameId == 0 || player.Id == 0) 
            {
                return BadRequest();
            }

            _gameService.UpdatePlayersPoints(gameId, player);

            return NoContent();
        }
    }
}
