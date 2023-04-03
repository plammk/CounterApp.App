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

        [HttpPost]
        public IActionResult CreateGame([FromBody] Game game)
        {
            if(game == null)
            {
                return BadRequest();
            }
            if(game.Name == string.Empty)
            {
                ModelState.AddModelError("Name","Enter name of the game");
                
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdGame = _gameService.AddGame(game);

            return Created("game", createdGame);
            
           
            
        }

        
    }
}
