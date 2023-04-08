using CounterApp.Shared.Domain;
using System.Collections.Generic;
namespace CounterApp.App.Services
{
    public interface IGameDataService
    {
        Task<IEnumerable<Game>> GetAllGames();
        Task<Game> AddGame(Game game);
        Task<Game> GetGameById(int id);
        Task DeleteGame(int gameId);
    }
}
