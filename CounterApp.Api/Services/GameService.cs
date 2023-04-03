using CounterApp.Shared.Domain;

namespace CounterApp.Api.Services
{
    public class GameService : IGameService
    {
        List<Game> list = new List<Game>();

        public IEnumerable<Game> GetAllGames()
        {
            list.Add(new Game
            {
                Name = "igra"
            }); 
            return list;
        }
        public Game AddGame(Game game)
        {
            list.Add(game);
            
            return game;
        }
    }
}
