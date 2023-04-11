using CounterApp.Shared.Domain;

namespace CounterApp.Api.Services
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetAllPlayers(int gameId);
    }
}
