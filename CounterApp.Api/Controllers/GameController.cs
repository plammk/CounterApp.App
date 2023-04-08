using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CounterApp.Api.Services;
using CounterApp.Shared.Domain;

namespace CounterApp.Api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            return Ok(_gameService.GetAllGames());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var wantedGame = _gameService.GetGameById(id);

            return Ok(wantedGame);
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] Game game)
        {
            if(game == null)
            {
                return BadRequest();
            }

            if(String.IsNullOrWhiteSpace(game.Name))
            {
                ModelState.AddModelError("Name","Enter name of the game");              
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var createdGame = _gameService.AddGame(game);

            return Created("game",createdGame); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            if(id ==0)
            {
                return BadRequest();
            }

            var deletedGame = _gameService.DeleteGame(id); 
            if(deletedGame == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
