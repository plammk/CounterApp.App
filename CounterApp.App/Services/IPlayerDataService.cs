using CounterApp.Shared.Domain;

namespace CounterApp.App.Services
{
    public interface IPlayerDataService
    {
        Task<IEnumerable<Player>> GetAllPlayers(int gameId);
        Task<Player> AddPlayer(Player player, int id);
        Task UpdatePlayersPoints(int gameId, Player player);
    }
}
