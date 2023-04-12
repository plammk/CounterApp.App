
using CounterApp.Shared.Domain;

namespace CounterApp.Api.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Player> GetAllPlayers(int gameId);
        Player AddPlayer(Player player, int id);
        Game AddGame(Game game);
        void UpdatePlayersPoints(int gameId, int playerId, int points);
        void MarkGameAsFinished(Game finishedGame);
        Game GetGameById(int id);
        Game DeleteGame(int gameId);
        void DeletePlayer(int gameId, int playerId);

    }
}
