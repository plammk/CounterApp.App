
using CounterApp.Shared.Domain;

namespace CounterApp.Api.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAllGames();
        Game AddGame(Game game);
    }
}
