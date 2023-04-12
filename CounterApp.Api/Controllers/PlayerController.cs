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
        
        //PUT
        [HttpPut("{playerId}/game/{gameId}/points/{points}")]
        public IActionResult UpdatePlayer(int gameId,int playerId,int points)
        {
            if(gameId == 0 || playerId == 0) 
            {
                return BadRequest();
            }

            _gameService.UpdatePlayersPoints(gameId, playerId,points);

            return NoContent();
        }

        //DELETE
        [HttpDelete("{playerId}/game/{gameId}")]
        public IActionResult DeletePlayer(int gameId,int playerId) 
        {
            _gameService.DeletePlayer(gameId, playerId);

            return NoContent();
        }
    }
}
